using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public abstract class ConsoleLayout
{
    public abstract string ID { get; }
    public abstract ConsoleLayoutContext Context { get; }
    public abstract ConsoleCommandsManager CommandsManager { get; }

    public abstract void Show();

    public abstract void ProvideInput(string input);
}
