namespace OOPTask3.Console.Layout;

public sealed class LayoutManager
{
    private ConsoleLayout? CurrentLayout { get; set; }

    private readonly ConsoleLayout[] _layouts;

    public LayoutManager()
    {
        _layouts =
        [
            new MenuLayout(this),
            new AboutLayout(this),
            new GameLayout(this),
        ];
    }

    public void ShowLayout(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return;
        }

        var layout = _layouts.FirstOrDefault(l => l.Id.Equals(id));

        if (layout == null)
        {
            return;
        }

        CurrentLayout?.Hide();

        CurrentLayout = layout;

        CurrentLayout.Show();
    }

    public bool ProvideInput(string input)
    {
        if (CurrentLayout == null || string.IsNullOrEmpty(input))
        {
            return false;
        }
        
        var provideInputResult = CurrentLayout.ProvideInput(input);

        return provideInputResult;
    }
}