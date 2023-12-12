using Asterisk.Domain.Interfaces;
using Asterisk.Domain.Queries.Alerts;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Queries;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Alerts
{
    public class ListByOrderHandle : Notifiable<Notification>, IHandlerQuery<ListByOrderQuery>
    {
        private readonly IAlertRepository _alertRepository;

        public ListByOrderHandle(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public IQueryResult Handler(ListByOrderQuery query)
        {
            var lista = _alertRepository.ReadByOrder(query.Order);

            if (lista == null)
                return new GenericQueryResult(false, "No alerts found", "");

            return new GenericQueryResult(true, "Alerts found", lista);
        }
    }
}
