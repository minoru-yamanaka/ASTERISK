using Asterisk.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Asterisk.Domain.Commands.Authentications
{
    public class LoginCommand : Notifiable<Notification>, ICommand
    {
        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "email", "Enter a valid email address")
                .IsGreaterThan(Password, 6, "The 'password' field must have at least 6 characters")
            );
        }
    }
}
