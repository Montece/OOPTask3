using OOPTask3.Game;
using OOPTask3.Game.States;
using OOPTask3.Random;
using Xunit;

namespace OOPTask3.Tests;

public sealed class GameLogicTests
{
    private const int RANDOM_SEED = 100;

    private GameLogic CreateGameLogic()
    {
        var gameLogic = new GameLogic(new StandardRandomGenerator(RANDOM_SEED), [], []);

        return gameLogic;
    }

    [Fact]
    public void GameLogic_State_NotStarted()
    {
        var gameLogic = CreateGameLogic();

        var gameState = gameLogic.CurrentState as NotStartedGameState;

        Assert.NotNull(gameState);
    }

    [Fact]
    public void GameLogic_State_Running()
    {
        var gameLogic = CreateGameLogic();
        gameLogic.Start(9, 10, 11);

        var runningGame = gameLogic.CurrentState as RunningGameState;

        Assert.NotNull(runningGame);
    }

    [Fact]
    public void GameLogic_Start_Width()
    {
        var gameLogic = CreateGameLogic();
        gameLogic.Start(9, 10, 11);

        var runningGame = gameLogic.CurrentState as RunningGameState;

        Assert.NotNull(runningGame);
        Assert.Equal(9, runningGame.Width);
    }

    [Fact]
    public void GameLogic_Start_Height()
    {
        var gameLogic = CreateGameLogic();
        gameLogic.Start(9, 10, 11);

        var runningGame = gameLogic.CurrentState as RunningGameState;

        Assert.NotNull(runningGame);
        Assert.Equal(10, runningGame.Height);
    }

    [Fact]
    public void GameLogic_Start_MaxBombsCount()
    {
        var gameLogic = CreateGameLogic();
        gameLogic.Start(9, 10, 11);

        var runningGame = gameLogic.CurrentState as RunningGameState;

        Assert.NotNull(runningGame);
        Assert.Equal(11, runningGame.Height);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    public void GameLogic_Start_CurrentBombsCount_Correct(int maxBombsCount)
    {
        var gameLogic = CreateGameLogic();
        gameLogic.Start(10, 15, maxBombsCount);

        var runningGame = gameLogic.CurrentState as RunningGameState;
        var cells = runningGame.GetCells();

        if (cells is null)
        {
            Assert.Fail("Cells are null!");
        }

        var bombsCount = 0;

        foreach (var cell in cells)
        {
            if (cell is null)
            {
                continue;
            }

            bombsCount += cell.HasBomb ? 1 : 0;
        }

        Assert.Equal(maxBombsCount, bombsCount);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(-10)]
    [InlineData(200)]
    public void GameLogic_Start_CurrentBombsCount_Incorrect(int maxBombsCount)
    {
        var gameLogic = CreateGameLogic();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            gameLogic.Start(10, 15, maxBombsCount);
        });
    }

    [Fact]
    public void Map2d_GetElements_Correct()
    {
        var gameLogic = CreateGameLogic();
        gameLogic.Start(10, 15, 20);

        var runningGame = gameLogic.CurrentState as RunningGameState;
        var cells = runningGame.GetCells();

        if (cells is null)
        {
            Assert.Fail("Cells are null!");
        }

        foreach (var cell in cells)
        {
            if (cell is null)
            {
                Assert.Fail("Cell is null!");
            }
        }

        Assert.Equal(runningGame.Width * runningGame.Height, cells.Length);
    }
}