using Flunt.Notifications;

namespace Asterisk.Shared.Entities
{
    public abstract class Base : Notifiable<Notification>
    {
        public Base()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
