using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Domain.Queries.Alerts;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Queries;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Alerts
{
    public class ListAlertHandle : Notifiable<Notification>, IHandlerQuery<ListAlertQuery>
    {
        private readonly IAlertRepository _alertRepository;

        public ListAlertHandle(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public IQueryResult Handler(ListAlertQuery query)
        {
            IEnumerable<Alert> list = _alertRepository.Read();

            return new GenericQueryResult(true, "Alerts found!", list);
        }

    }
}
