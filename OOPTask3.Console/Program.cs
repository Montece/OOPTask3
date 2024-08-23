using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout;

Console.Title = "OOPTask3";

var layoutManager = new LayoutManager();
layoutManager.ShowLayout("Menu");

var isExecuting = true;

while (isExecuting)
{
    var input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        continue;
    }

    layoutManager.ProvideInput(input);
}

Console.WriteLine("Press ENTER to exit...");
Console.ReadLine();