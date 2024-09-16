using OOPTask3.GameCell;
using Xunit;

namespace OOPTask3.Tests;

public class CellTests
{
    [Fact]
    public void Cell_Ctor_NoThrow()
    {
        try
        {
            var cell = new Cell();
            Assert.NotNull(cell);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Cannot create cell! {ex}");
        }
    }

    [Fact]
    public void Cell_PlaceBomb_Success()
    {
        var cell = new Cell();

        var bombStateBeforePlace = cell.HasBomb;
        cell.PlaceBomb();
        var bombStateAfterPlace = cell.HasBomb;

        Assert.NotEqual(bombStateBeforePlace, bombStateAfterPlace);
    }

    [Fact]
    public void Cell_ChangeStateTo_SuccessAllVarieties()
    {
        var cell = new Cell();

        foreach (CellState targetState in Enum.GetValues(typeof(CellState)))
        {
            var oldState = cell.State;
            cell.ChangeStateTo(targetState);
            var newState = cell.State;

            if (oldState != targetState && newState == oldState)
            {
                Assert.Fail($"Cannot change cell state: {oldState} -> {newState}");
            }
        }
    }

    [Fact]
    public void Cell_SetNumber_SuccessAllVarieties()
    {
        var cell = new Cell();

        foreach (CellNumber targetNumber in Enum.GetValues(typeof(CellNumber)))
        {
            var oldState = cell.Number;
            cell.SetNumber(targetNumber);
            var newState = cell.Number;

            if (oldState != targetNumber && newState == oldState)
            {
                Assert.Fail($"Cannot change cell number: {oldState} -> {newState}");
            }
        }
    }
}