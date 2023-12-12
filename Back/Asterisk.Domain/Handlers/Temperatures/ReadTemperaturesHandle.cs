using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Domain.Queries.Temperaturas;
using Asterisk.Shared.Handlers.Contracts;
using Asterisk.Shared.Queries;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Temperatures
{
    public class ReadTemperaturesHandle : Notifiable<Notification>, IHandlerQuery<ReadTemperaturesQuery>
    {
        private readonly ITemperatureRepository _temperatureRepository;

        public ReadTemperaturesHandle(ITemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }

        public IQueryResult Handler(ReadTemperaturesQuery query)
        {
            IEnumerable<Temperature> list = _temperatureRepository.Read();

            return new GenericQueryResult(true, "Temperatures found!", list);
        }
    }
}
