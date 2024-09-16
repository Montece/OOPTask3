using OOPTask3.GameCell;
using OOPTask3.Map;
using Xunit;

namespace OOPTask3.Tests;

public class Map2dTests
{
    private Map2d<Cell> InitMap(int width, int height)
    {
        var map = new Map2d<Cell>(width, height);

        for (var w = 0; w < map.Width; w++)
        {
            for (var h = 0; h < map.Height; h++)
            {
                map.SetElement(new(w, h), new());
            }
        }

        return map;
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1000, 1000)]
    public void Map2d_Ctor_Success(int width, int height)
    {
        var map = new Map2d<Cell>(width, height);

        Assert.NotNull(map);
    }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(-999, -999)]
    [InlineData(-999, 999)]
    [InlineData(999, -999)]
    [InlineData(999, 0)]
    [InlineData(0, 999)]
    [InlineData(0, 0)]
    public void Map2d_Ctor_Exception(int width, int height)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var _ = new Map2d<Cell>(width, height);
        });
    }

    [Fact]
    public void Map2d_GetElement_Correct()
    {
        var map = InitMap(10, 10);

        var cell = new Cell();
        var number = CellNumber.Five;
        cell.SetNumber(number);
        map.SetElement(new(5, 5), cell);

        cell = map.GetElement(new(5, 5));

        if (cell is null)
        {
            Assert.Fail("Cell is null!");
        }

        Assert.Equal(number, cell.Number);
    }


    [Fact]
    public void Map2d_GetElement_Null()
    {
        var map = new Map2d<Cell>(10, 10);

        var cell = map.GetElement(new(5, 5));

        Assert.Null(cell);
    }

    [Theory]
    [InlineData(-1, 5)]
    [InlineData(5, -1)]
    [InlineData(-5, -5)]
    public void Map2d_GetElement_LessThenZero(int x, int y)
    {
        var map = InitMap(10, 10);

        var cell = map.GetElement(new(x, y));

        Assert.Null(cell);
    }

    [Theory]
    [InlineData(50, 5)]
    [InlineData(5, 50)]
    [InlineData(50, 50)]
    public void Map2d_GetElement_OutOfBounds(int x, int y)
    {
        var map = InitMap(10, 10);

        var cell = map.GetElement(new(x, y));

        Assert.Null(cell);
    }

    [Fact]
    public void Map2d_GetElements_Correct()
    {
        var map = InitMap(10, 10);

        var cells = map.GetElements();

        foreach (var cell in cells)
        {
            if (cell is null)
            {
                Assert.Fail("Cell is null!");
            }
        }

        Assert.Equal(map.Width * map.Height, cells.Length);
    }

    [Fact]
    public void Map2d_SetElement_SetNormalValue()
    {
        var map = InitMap(10, 10);
        var cell = new Cell();

        map.SetElement(new(3, 3), cell);

        var cellFromMap = map.GetElement(new(3, 3));

        Assert.Equal(cell, cellFromMap);
    }

    [Theory]
    [InlineData(Direction.Upper, 0, 1)]
    [InlineData(Direction.Lower, 0, -1)]
    [InlineData(Direction.Right, 1, 0)]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.UpperRight, 1, 1)]
    [InlineData(Direction.LowerRight, 1, -1)]
    [InlineData(Direction.UpperLeft, -1, 1)]
    [InlineData(Direction.LowerLeft, -1, -1)]
    public void Map2d_GetElementNeighbour_Upper_Correct(Direction direction, int offsetToDirectionX, int offsetToDirectionY)
    {
        var map = InitMap(10, 10);
        var mainCell = new Cell();
        var directionCell = new Cell();

        var mainCellPosition = new Point(5, 5);

        var directionCellPosition = new Point(mainCellPosition.X + offsetToDirectionX, mainCellPosition.Y + offsetToDirectionY);

        map.SetElement(mainCellPosition, mainCell);
        map.SetElement(directionCellPosition, directionCell);

        var tryGetDirectionCell = map.GetElementNeighbour(mainCellPosition, direction);

        Assert.Equal(directionCell, tryGetDirectionCell);
    }
}