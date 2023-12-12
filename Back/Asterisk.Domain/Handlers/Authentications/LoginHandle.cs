using Asterisk.Domain.Commands.Authentications;
using Asterisk.Domain.Interfaces;
using Asterisk.Shared.Commands;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Utils;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Authentications
{
    public class LoginHandle : Notifiable<Flunt.Notifications.Notification>, IHandlerCommand<LoginCommand>
    {
        private readonly IUserRepository _userRepository;

        public LoginHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Handler(LoginCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Enter the data correctly", command.Notifications);
            }

            var searchedUser = _userRepository.SearchByEmail(command.Email);

            if (searchedUser == null)
            {
                return new GenericCommandResult(false, "Invalid e-mail or password", "");
            }

            if (!Password.ValidateHashes(command.Password, searchedUser.Password))
            {
                return new GenericCommandResult(false, "Invalid e-mail or password", "");
            }

            return new GenericCommandResult(true, "Successfully logged in!", searchedUser);
        }
    }
}
