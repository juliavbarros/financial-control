using FluentValidation.Results;
using JVB.FinancialControl.Data.Entities;
using JVB.FinancialControl.Data.Interfaces;
using MediatR;

namespace JVB.FinancialControl.Domain.Commands.Users
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>,
        IRequestHandler<RemoveUserCommand, ValidationResult>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = new User(0, message.Username, message.Password, message.Email, message.FirstName, message.LastName, message.BirthDate, message.GrossSalary, message.NetSalary, message.UserTypeId);

            if (await _userRepository.GetByEmail(user.Email) != null)
            {
                AddError("The user e-mail has already been taken.");
                return ValidationResult;
            }

            _userRepository.Add(user);

            return await Commit(_userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = new User(message.Id, message.Username, message.Password, message.Email, message.FirstName, message.LastName, message.BirthDate, message.GrossSalary, message.NetSalary, message.UserTypeId);
            
            var existingUser = await _userRepository.GetByEmail(user.Email);

            if (existingUser != null && existingUser.Id != user.Id)
            {
                if (!existingUser.Equals(user))
                {
                    AddError("The user e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _userRepository.Update(user);

            return await Commit(_userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = await _userRepository.GetById(message.Id);

            if (user is null)
            {
                AddError("The user doesn't exists.");
                return ValidationResult;
            }

            _userRepository.Remove(user);

            return await Commit(_userRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}