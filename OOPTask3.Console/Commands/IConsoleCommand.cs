using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public interface IConsoleCommand
{
    public bool IsMatch(string input);

    public void Execute(ConsoleLayoutContext context, string input);
}