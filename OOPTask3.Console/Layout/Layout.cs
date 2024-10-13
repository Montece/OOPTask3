using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public abstract class ConsoleLayout
{
    public abstract string Id { get; }
    protected abstract ConsoleLayoutContext Context { get; }
    protected abstract ConsoleCommandsManager CommandsManager { get; }
    public LayoutManager LayoutManager { get; }

    private const string TITLE = "=== Minesweeper ===";

    public ConsoleLayout(LayoutManager layoutManager)
    {
        LayoutManager = layoutManager;
    }

    public void ReShow()
    {
        Hide();
        Show();
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

    public bool ProvideInput(string input)
    {
        Context.ConsoleLayout = this;

        var executeResult = CommandsManager.TryExecute(Context, input);

        if (!executeResult)
        {
            var provideInputResult = ProvideInputImpl(input);

            if (!provideInputResult)
            {
                return false;
            }
        }

        return true;
    }

    protected abstract bool ProvideInputImpl(string input);
}
