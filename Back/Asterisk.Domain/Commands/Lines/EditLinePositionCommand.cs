using Asterisk.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Asterisk.Domain.Commands.Lines
{
    public class EditLinePositionCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; private set; }
        public decimal Width { get; set; }
        public decimal MarginTop { get; set; }
        public decimal MarginLeft { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract<Notification>()
                   .IsGreaterThan(Width, 0, "Width", "The 'Width' field cannot be null")
                   .IsNotNull(Id, "Id", "The 'Id' field cannot be null")
                   .IsNotNull(MarginTop, "MarginTop", "The 'MarginTop' field cannot be null")
                   .IsNotNull(MarginLeft, "MarginLeft", "The 'MarginLeft' field cannot be null")
               );
        }

        public void AdicionarId(Guid id)
        {
            Id = id;
        }
    }
}
