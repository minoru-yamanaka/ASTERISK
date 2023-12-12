using Asterisk.Domain.Commands.Temperatures;
using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Shared.Commands;
using Asterisk.Shared.Enums;
using Asterisk.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Temperatures
{
    public class CreateTemperatureHandle : Notifiable<Notification>, IHandlerCommand<CreateTemperatureCommand>
    {
        private readonly ITemperatureRepository _temperatureRepository;

        public CreateTemperatureHandle(ITemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }

        public ICommandResult Handler(CreateTemperatureCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Correctly enter temperature data", command.Notifications);

            switch (command.Degrees)
            {
                case <= 0 or <= 26:
                    command.AddStatus(EnTemperatureStatus.Safe);
                    break;

                case > 26 and <= 35:
                    command.AddStatus(EnTemperatureStatus.Caution);
                    break;

                case > 35:
                    command.AddStatus(EnTemperatureStatus.Danger);
                    break;
            }

            Temperature temperature = new Temperature(
                command.Degrees,
                command.ReturnStatus()
            );

            if (!temperature.IsValid)
                return new GenericCommandResult(false, "Correctly enter temperature data", temperature.Notifications);

            _temperatureRepository.Create(temperature);

            return new GenericCommandResult(true, "Temperature created successfully", temperature);
        }
    }
}
