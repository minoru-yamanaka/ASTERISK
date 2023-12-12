using Asterisk.Domain.Interfaces;
using Asterisk.Domain.Queries.Users;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Queries;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Users
{
    public class ListAccountHandle : Notifiable<Notification>, IHandlerQuery<ListAccountQuery>
    {
        private readonly IUserRepository _userRepository;

        public ListAccountHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryResult Handler(ListAccountQuery query)
        {
            var list = _userRepository.List();

            return new GenericQueryResult(true, "Users found!", list);
        }

    }
}
