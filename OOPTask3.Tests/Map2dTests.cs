using OOPTask3.Game;
using OOPTask3.Game.Cells;
using OOPTask3.Map;
using Xunit;

namespace OOPTask3.Tests;

public class Map2dTests
{
    private static CellsMap InitMap(int width, int height)
    {
        var map = new CellsMap(width, height, []);

        for (var w = 0; w < map.Width; w++)
        {
            for (var h = 0; h < map.Height; h++)
            {
                map.SetElement(new(w, h), new(map, new(w, h), []));
            }
        }

        return map;
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1000, 1000)]
    public void Map2d_Ctor_Success(int width, int height)
    {
        var map = new CellsMap(width, height, []);

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
        Assert.Throws<ArgumentOutOfRangeException>(() => { _ = new CellsMap(width, height, []); });
    }

    [Fact]
    public void Map2d_GetElement_Correct()
    {
        var map = InitMap(10, 10);
        var position = new Point(0, 0);

        var cell = new Cell(map, position, []);
        map.SetElement(position, cell);
        cell = map.GetElement(position);

        if (cell is null)
        {
            Assert.Fail("Cell is null!");
        }

        Assert.Equal(position, cell.Point);
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

        Assert.Equal(map.Width * map.Height, cells.Length);
    }

    [Fact]
    public void Map2d_SetElement_SetNormalValue()
    {
        var map = InitMap(10, 10);
        var position = new Point(3, 3);
        var cell = new Cell(map, position, []);

        map.SetElement(position, cell);

        var cellFromMap = map.GetElement(position);

        Assert.Equal(cell, cellFromMap);
    }
}