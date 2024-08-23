using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public sealed class GameLayout : ConsoleLayout
{
    public override string ID => "Game";

    public override ConsoleLayoutContext Context => throw new NotImplementedException();

    public override ConsoleCommandsManager CommandsManager => throw new NotImplementedException();
    

    public override void ProvideInput(string input)
    {
        throw new NotImplementedException();
    }

    public override void Show()
    {
        throw new NotImplementedException();
    }
}
