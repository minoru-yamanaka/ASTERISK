using Asterisk.Shared.Queries;

namespace Asterisk.Domain.Queries.Alerts
{
    public class ListByOrderQuery : IQuery
    {
        public string Order { get; set; }

        public ListByOrderQuery()
        {

        }

        public ListByOrderQuery(string order)
        {
            Order = order;
        }

        public void Validate()
        {
            
        }
    }
}
