using OOPTask3.Game.Cells;

namespace OOPTask3.WPF;

public sealed class CellControl(Cell value)
{
    public Cell Value { get; } = value;

    public char ShowValue => Value.State.Mnemonics;
}