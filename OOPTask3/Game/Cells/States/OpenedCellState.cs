﻿using OOPTask3.Map;

namespace OOPTask3.Game.Cells.States;

public sealed class OpenedCellState(Cell cell) : CellState(cell)
{
    public override string Id => "Opened";
    public override string[] AvailableToChangeIds { get; } = [];
    public override CellState? PrimaryNextState => null;
    public override CellState? SecondaryNextState => null;
    public override char Mnemonics => cell.BombsCount.Value.ToString().FirstOrDefault();
}