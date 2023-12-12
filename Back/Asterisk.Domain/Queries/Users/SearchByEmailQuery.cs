﻿using Asterisk.Shared.Enums;
using Asterisk.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;

namespace Asterisk.Domain.Queries.Users
{
    public class SearchByEmailQuery : Notifiable<Notification>, IQuery
    {
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(Email, "email", "Enter a valid email address")
                );
        }

        public class SearchByEmailResult
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public EnUserType UserType { get; set; }
            public DateTime CreatedDate { get; set; }
        }
    }
}
