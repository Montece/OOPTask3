﻿using OOPTask3.StateMachine;

namespace OOPTask3.Game.Cells.States;

public sealed class CellStateMachine(CellState initialState) : StateMachine<CellState>(initialState)
{
    public bool ExecutePrimaryTransition()
    {
        if (CurrentState.PrimaryNextState is null)
        {
            return false;
        }

        return ChangeStateTo(CurrentState.PrimaryNextState);
    }

    public bool ExecuteSecondaryTransition()
    {
        if (CurrentState.SecondaryNextState is null)
        {
            return false;
        }

        return ChangeStateTo(CurrentState.SecondaryNextState);
    }
}