using System.Diagnostics.CodeAnalysis;
using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public abstract class ConsoleLayout
{
    public abstract string ID { get; }
    public abstract ConsoleLayoutContext Context { get; }
    public abstract ConsoleCommandsManager CommandsManager { get; }
    public LayoutManager LayoutManager { get; }

    private const string TITLE = "=== Minesweeper ===";

    public ConsoleLayout(LayoutManager layoutManager)
    {
        LayoutManager = layoutManager;
    }

    public void Show()
    {
        System.Console.WriteLine(TITLE);
        ShowImpl();
    }

    protected abstract void ShowImpl();

    public void Hide()
    {
        System.Console.Clear();
        HideImpl();
    }

    protected abstract void HideImpl();

    public void ProvideInput(string input)
    {
        if (Context != null)
        {
            Context.ConsoleLayout = this;
        }

        var executeResult = CommandsManager.TryExecute(Context, input);

        if (!executeResult)
        {
            ProvideInputImpl(input);
        }
    }

    protected abstract void ProvideInputImpl(string input);
}
