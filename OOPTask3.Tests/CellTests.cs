using OOPTask3.Game;
using OOPTask3.Game.Cells;
using OOPTask3.Game.Cells.States;
using OOPTask3.StateMachine;
using Xunit;

namespace OOPTask3.Tests;

public class CellTests
{
    private readonly CellsMap _mockMap = new(10, 10, []);
    private readonly List<StateView> _cellViews = [];

    [Fact]
    public void Cell_Ctor_Throw()
    {
        Assert.Throws<ArgumentNullException>(() => { _ = new Cell(null, null, null); });
    }

    [Fact]
    public void Cell_Ctor_NoThrow()
    {
        try
        {
            var cell = new Cell(_mockMap, new(0, 0), _cellViews);
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
        var cell = new Cell(_mockMap, new(0, 0), _cellViews);

        var bombStateBeforePlace = cell.HasBomb;
        cell.PlaceBomb();
        var bombStateAfterPlace = cell.HasBomb;

        Assert.NotEqual(bombStateBeforePlace, bombStateAfterPlace);
    }

    [Fact]
    public void Cell_ChangeStateToNextPrimary_SuccessFullChain()
    {
        var cell = new Cell(_mockMap, new(0, 0), _cellViews);

        var oldState = cell.State;

        if (oldState.Id != "Clear")
        {
            Assert.Fail($"Wrong initial cell state: {oldState.Id}");
        }

        var changeResult = cell.ChangeStateToNextPrimary();

        var newState = cell.State;

        if (!changeResult || newState.Id != "Opened")
        {
            Assert.Fail($"Cannot change cell state: {newState.Id}");
        }

        changeResult = cell.ChangeStateToNextPrimary();

        newState = cell.State;

        if (changeResult)
        {
            Assert.Fail($"Wrong change cell state: {newState.Id}");
        }
    }

    [Fact]
    public void Cell_ChangeStateToNextSecondary_SuccessFullChain()
    {
        var cell = new Cell(_mockMap, new(0, 0), _cellViews);

        var oldState = cell.State;

        if (oldState.Id != "Clear")
        {
            Assert.Fail($"Wrong initial cell state: {oldState.Id}");
        }

        var changeResult = cell.ChangeStateToNextSecondary();

        var newState = cell.State;

        if (!changeResult || newState.Id != "Flag")
        {
            Assert.Fail($"Cannot change cell state: {newState.Id}");
        }

        changeResult = cell.ChangeStateToNextSecondary();

        newState = cell.State;

        if (!changeResult || newState.Id != "Question")
        {
            Assert.Fail($"Cannot change cell state: {newState.Id}");
        }

        changeResult = cell.ChangeStateToNextSecondary();

        newState = cell.State;

        if (!changeResult || newState.Id != "Clear")
        {
            Assert.Fail($"Cannot change cell state: {newState.Id}");
        }
    }
}