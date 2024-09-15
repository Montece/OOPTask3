using OOPTask3.GameCell;
using OOPTask3.Map;
using Xunit;

namespace OOPTask3.Tests;

public class Map2dTests
{
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
            var map = new Map2d<Cell>(width, height);
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

        Assert.Equal(cell.Number, number);
    }

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
}