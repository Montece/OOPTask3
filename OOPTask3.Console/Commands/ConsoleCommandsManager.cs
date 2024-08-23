using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class ConsoleCommandsManager
{
    private readonly IConsoleCommand[] _commands;

    public ConsoleCommandsManager(IConsoleCommand[] commands)
    {
        _commands = commands;
    }

    public bool TryExecute(ConsoleLayoutContext context, string input)
    {
        foreach (var command in _commands)
        {
            if (!command.IsMatch(input))
            {
                continue;
            }

            command.Execute(context, input);

            return true;
        }

        return false;
    }
}