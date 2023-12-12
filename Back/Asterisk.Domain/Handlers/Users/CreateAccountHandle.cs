using Asterisk.Domain.Commands.Users;
using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Shared.Commands;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Services;
using Asterisk.Shared.Utils;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Users
{
    public class CreateAccountHandle : Notifiable<Flunt.Notifications.Notification>, IHandlerCommand<CreateAccountCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;

        public CreateAccountHandle(IUserRepository userRepository, IMailService mailService)
        {
            _userRepository = userRepository;
            _mailService = mailService;
        }

        public ICommandResult Handler(CreateAccountCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Correctly enter user data", command.Notifications);
            }

            var emailExists = _userRepository.SearchByEmail(command.Email);

            if (emailExists != null)
            {
                return new GenericCommandResult(false, "Existing e-mail", "Enter another e-mail");
            }

            command.Password = Password.Encrypt(command.Password);

            //_mailService.SendAlertEmail(command.Email);

            User newUser = new User(command.Name, command.Email, command.Password, command.UserType);

            if (!newUser.IsValid)
            {
                return new GenericCommandResult(false, "Invalid user data", newUser.Notifications);
            }

            _userRepository.Add(newUser);

            return new GenericCommandResult(true, "User created successfully!", "user-token");
        }
    }
}
