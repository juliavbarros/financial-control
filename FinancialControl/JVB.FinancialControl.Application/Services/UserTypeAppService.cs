using AutoMapper;
using FluentValidation.Results;
using JVB.FinancialControl.Application.Interfaces;
using JVB.FinancialControl.Application.ViewModels;
using JVB.FinancialControl.Common.Bus;
using JVB.FinancialControl.Data.Interfaces;
using JVB.FinancialControl.Domain.Commands.UserTypes;

namespace JVB.FinancialControl.Application.Services
{
    public class UserTypeAppService : IUserTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMediatorHandler _mediator;

        public UserTypeAppService(IMapper mapper,
                                  IUserTypeRepository userTypeRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _userTypeRepository = userTypeRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<UserTypeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserTypeViewModel>>(await _userTypeRepository.GetAll());
        }

        public async Task<UserTypeViewModel> GetById(int id)
        {
            return _mapper.Map<UserTypeViewModel>(await _userTypeRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(UserTypeViewModel userTypeViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserTypeCommand>(userTypeViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(UserTypeViewModel userTypeViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserTypeCommand>(userTypeViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new RemoveUserTypeCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}