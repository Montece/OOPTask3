using System.Windows;
using OOPTask3.Game.Cells;

namespace OOPTask3.WPF;

public sealed class CellControl(int row, int column, Thickness border, Cell value)
{
    public Thickness Border { get; } = border;
    public Cell Value { get; } = value;
    public string ShowValue => Value.State.ToString();

    public int Row { get; } = row;
    public int Column { get; } = column;
}

