using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public sealed class AboutLayout : ConsoleLayout
{
    public override string ID => "About";
    public override ConsoleLayoutContext Context { get; } = new ConsoleLayoutContext();
    public override ConsoleCommandsManager CommandsManager { get; } = new(
    [
        new MenuCommand(BACK_SHORTCUT),
    ]);

    private const int BACK_SHORTCUT = 1;

    public AboutLayout(LayoutManager layoutManager) : base(layoutManager)
    {
    }

    protected override void ShowImpl()
    {
        System.Console.WriteLine("Developer: Montece");
        System.Console.WriteLine();
        System.Console.WriteLine($"{BACK_SHORTCUT}. Back");
    }

    protected override void HideImpl()
    {
    }

    protected override void ProvideInputImpl(string input)
    {
        
    }
}