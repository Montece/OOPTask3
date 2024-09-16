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

    var provideInputResult = layoutManager.ProvideInput(input);

    if (!provideInputResult)
    {
        switch (input)
        {
            case "force exit":
                isExecuting = false;
                break;
            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}

Console.WriteLine("Press ENTER to exit...");
Console.ReadLine();