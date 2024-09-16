using Xunit;

namespace OOPTask3.Tests;

public sealed class GameLogicTests
{
    [Fact]
    public void GameLogic_Ctor_InitialState_Width()
    {
        var gameLogic = new GameLogic();

        Assert.Equal(0, gameLogic.Width);
    }

    [Fact]
    public void GameLogic_Ctor_InitialState_Height()
    {
        var gameLogic = new GameLogic();

        Assert.Equal(0, gameLogic.Height);
    }

    [Fact]
    public void GameLogic_Ctor_InitialState_MaxBombsCount()
    {
        var gameLogic = new GameLogic();

        Assert.Equal(0, gameLogic.MaxBombsCount);
    }

    [Fact]
    public void GameLogic_Ctor_InitialState_State()
    {
        var gameLogic = new GameLogic();

        Assert.Equal(GameState.NotStarted, gameLogic.State);
    }
    
    [Fact]
    public void GameLogic_Start_Width()
    {
        var gameLogic = new GameLogic();
        gameLogic.Start(10, 15, 20);
        
        Assert.Equal(10, gameLogic.Width);
    }

    [Fact]
    public void GameLogic_Start_Height()
    {
        var gameLogic = new GameLogic();
        gameLogic.Start(10, 15, 20);

        Assert.Equal(15, gameLogic.Height);
    }

    [Fact]
    public void GameLogic_Start_MaxBombsCount()
    {
        var gameLogic = new GameLogic();
        gameLogic.Start(10, 15, 20);

        Assert.Equal(gameLogic.Width * gameLogic.Height, gameLogic.MaxBombsCount);
    }

    [Theory]
    [InlineData(7, 9)]
    [InlineData(3, 2)]
    [InlineData(0, 0)]
    [InlineData(9, 14)]
    public void GameLogic_Start_RandomCellCheck(int x, int y)
    {
        var gameLogic = new GameLogic();
        gameLogic.Start(10, 15, 20);
        var cell = gameLogic.GetCell(new(x, y));

        Assert.NotNull(cell);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    public void GameLogic_Start_CurrentBombsCount_Correct(int maxBombsCount)
    {
        var gameLogic = new GameLogic();
        gameLogic.Start(10, 15, maxBombsCount);

        var cells = gameLogic.GetCells();

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
        var gameLogic = new GameLogic();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            gameLogic.Start(10, 15, maxBombsCount);
        });
    }

    [Fact]
    public void Map2d_GetElements_Correct()
    {
        var gameLogic = new GameLogic();
        gameLogic.Start(10, 15, 20);

        var cells = gameLogic.GetCells();

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

        Assert.Equal(gameLogic.Width * gameLogic.Height, cells.Length);
    }
}