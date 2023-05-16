using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.UserTypes
{
    public class UserTypeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserTypeCommand, ValidationResult>,
        IRequestHandler<UpdateUserTypeCommand, ValidationResult>,
        IRequestHandler<RemoveUserTypeCommand, ValidationResult>
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeCommandHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewUserTypeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var userType = new UserType(0, message.Name);

            if (await _userTypeRepository.GetByName(userType.Name) != null)
            {
                AddError("The userType name has already been taken.");
                return ValidationResult;
            }

            _userTypeRepository.Add(userType);

            return await Commit(_userTypeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateUserTypeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var userType = new UserType(message.Id, message.Name);

            var existingUserType = await _userTypeRepository.GetByName(userType.Name);

            if (existingUserType != null && existingUserType.Id != userType.Id)
            {
                if (!existingUserType.Equals(userType))
                {
                    AddError("The userType e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _userTypeRepository.Update(userType);

            return await Commit(_userTypeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveUserTypeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var userType = await _userTypeRepository.GetById(message.Id);

            if (userType is null)
            {
                AddError("The userType doesn't exists.");
                return ValidationResult;
            }

            _userTypeRepository.Remove(userType);

            return await Commit(_userTypeRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _userTypeRepository.Dispose();
        }
    }
}