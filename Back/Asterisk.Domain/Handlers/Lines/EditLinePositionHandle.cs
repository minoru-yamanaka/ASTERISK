using Asterisk.Domain.Commands.Lines;
using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Shared.Commands;
using Asterisk.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace Asterisk.Domain.Handlers.Lines
{
    public class EditLinePositionHandle : Notifiable<Notification>, IHandlerCommand<EditLinePositionCommand>
    {
        private readonly ILineRepository _lineRepository;

        public EditLinePositionHandle(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public ICommandResult Handler(EditLinePositionCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Correctly enter alert data", command.Notifications);

            Line line = _lineRepository.SearchById(command.Id);

            if (line == null)
                return new GenericCommandResult(false, "Line not found", "");

            line.AdicionarDados(
                command.Width,
                command.MarginTop,
                command.MarginLeft
            );

            _lineRepository.Update(line);

            return new GenericCommandResult(true, "Line has been edited", line);
        }
    }
}
