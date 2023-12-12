using Asterisk.Shared.Commands;

namespace Asterisk.Shared.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
