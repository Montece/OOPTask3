using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

internal abstract class ConsoleCommand : IConsoleCommand
{
    public abstract bool IsMatch(string input);

    public void Execute(ConsoleLayoutContext context, string input)
    {
        if (!IsMatch(input))
        {
            return;
        }

        ExecuteInternal(context, input);
    }

    protected abstract void ExecuteInternal(ConsoleLayoutContext context, string input);
}