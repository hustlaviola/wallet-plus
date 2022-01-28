using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Common.Exceptions;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Handlers.Customers.AddCustomer
{
    public class AddCustomerCommandHandler : BaseHandler, IRequestHandler<AddCustomerCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            var emailExists = await _unitOfWork.CustomerRepository.EmailExists(command.Email);
            if (emailExists) throw new ConflictException(nameof(Customer), command.Email);

            var phoneExists = await _unitOfWork.CustomerRepository.PhoneNumberExists(command.PhoneNumber);

            if (phoneExists) throw new ConflictException(nameof(Customer), command.PhoneNumber);

            var customer = new Customer(
                command.FirstName,
                command.LastName,
                command.Email,
                command.PhoneNumber
            );

            await _unitOfWork.CustomerRepository.AddAsync(customer);
            await _unitOfWork.SaveAsync();

            var wallet = new Wallet(customer.Id, customer.CustomerReference);
            
            await _unitOfWork.WalletRepository.AddAsync(wallet);
            await _unitOfWork.SaveAsync();


            return HandleResponse(new CustomerDto
            {
                CustomerReference = customer.CustomerReference,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.Email,
                PhoneNumber = customer.PhoneNumber
            }, ResponseStatus.CREATED);
        }
    }
}