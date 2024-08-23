namespace OOPTask3.Console.Layout;

public sealed class LayoutManager
{
    public ConsoleLayout CurrentLayout { get; private set; }

    private readonly ConsoleLayout[] _layouts =
    [
        new MenuLayout(),
        new GameLayout(),
    ];

    public void ShowLayout(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return;
        }

        var layout = _layouts.FirstOrDefault(l => l.ID.Equals(id));

        if (layout == null)
        {
            return;
        }

        CurrentLayout = layout;

        CurrentLayout.Show();
    }

    public void ProvideInput(string input)
    {
        if (CurrentLayout == null || string.IsNullOrEmpty(input))
        {
            return;
        }
        
        CurrentLayout.ProvideInput(input);
    }
}