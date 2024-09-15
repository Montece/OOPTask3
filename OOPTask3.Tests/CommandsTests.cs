using OOPTask3.Console.Commands;
using Xunit;

namespace OOPTask3.Tests;

public sealed class CommandsTests
{
    private const string MATCH_TEXT_COMMENT_PATTERN = "The text '{0}' cannot call the target command";
    private const string MATCH_SHORTCUT_COMMENT_PATTERN = "The shortcut '{0}' cannot call the target command";

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(15454712)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-100)]
    [InlineData(-1000)]
    [InlineData(-15454712)]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    public void ConsoleCommand_Shortcut(int shortcut)
    {
        var command = new AboutCommand(shortcut);
        var text = shortcut.ToString();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_SHORTCUT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("about")]
    public void AboutCommand_Match(string text)
    {
        var command = new AboutCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("clear")]
    public void ClearCommand_Match(string text)
    {
        var command = new ClearCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("exit")]
    [InlineData("quit")]
    [InlineData("stop")]
    [InlineData("close")]
    public void ExitCommand_Match(string text)
    {
        var command = new ExitCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("hi")]
    public void HiCommand_Match(string text)
    {
        var command = new HiCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("back")]
    public void MenuCommand_Match(string text)
    {
        var command = new MenuCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("start")]
    [InlineData("start game")]
    public void StartGameCommand_Match(string text)
    {
        var command = new StartGameCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("toggle cell -5 -5")]
    [InlineData("toggle cell 0 0")]
    [InlineData("toggle cell 5 5")]
    [InlineData("toggle cell 99 99")]
    public void ToggleCellCommand_Match(string text)
    {
        var command = new ToggleCellCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("open cell -5 -5")]
    [InlineData("open cell 0 0")]
    [InlineData("open cell 5 5")]
    [InlineData("open cell 99 99")]
    public void OpenCellCommand_Match(string text)
    {
        var command = new OpenCellCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }

    [Theory]
    [InlineData("restart")]
    [InlineData("restart game")]
    public void RestartGameCommand_Match(string text)
    {
        var command = new RestartGameCommand();
        var matchResult = command.IsMatch(text);

        Assert.True(matchResult, string.Format(MATCH_TEXT_COMMENT_PATTERN, text));
    }
}