using Asterisk.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Asterisk.Domain.Commands.Users
{
    public class UpdateAccountCommand : Notifiable<Notification>, ICommand
    {
        public UpdateAccountCommand() { }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Id, "id", "The 'id' field cannot be empty")
                .IsNotEmpty(Name, "name", "The 'name' field cannot be empty")
            );
        }
    }
}
