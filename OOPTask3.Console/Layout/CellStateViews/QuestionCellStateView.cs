using OOPTask3.Game.Cells.States;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.CellStateViews;

internal sealed class QuestionCellStateView : StateView
{
    public override string Id => "Question";

    public override void Render(State state)
    {
        if (state is not QuestionCellState questionCellState)
        {
            return;
        }

        System.Console.Write(questionCellState.Mnemonics);
    }
}