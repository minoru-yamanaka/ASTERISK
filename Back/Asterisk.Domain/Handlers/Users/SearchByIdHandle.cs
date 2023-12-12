using Asterisk.Domain.Interfaces;
using Asterisk.Domain.Queries.Users;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Queries;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Users
{
    public class SearchByIdHandle : Notifiable<Notification>, IHandlerQuery<SearchByIdQuery>
    {
        private readonly IUserRepository _userRepository;

        public SearchByIdHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryResult Handler(SearchByIdQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Correctly enter user data", query.Notifications);
            }

            var searchedUser = _userRepository.SearchById(query.Id);

            if (searchedUser == null)
            {
                return new GenericQueryResult(false, "User not found", query.Notifications);
            }

            return new GenericQueryResult(true, "Users found!", searchedUser);
        }

    }
}
