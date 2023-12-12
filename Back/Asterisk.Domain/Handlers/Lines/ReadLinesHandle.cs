using Asterisk.Domain.Interfaces;
using Asterisk.Domain.Queries.Lines;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Queries;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Lines
{
    public class ReadLinesHandle : Notifiable<Notification>, IHandlerQuery<ReadLinesQuery>
    {
        private readonly ILineRepository _lineRepository;

        public ReadLinesHandle(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public IQueryResult Handler(ReadLinesQuery query)
        {
            var lines = _lineRepository.Read();

            return new GenericQueryResult(true, "Lines found!", lines);
        }
    }
}
