using System.Windows;

namespace OOPTask3.WPF;

public sealed class CellControl
{
    public Thickness Border { get; }
    public Cell Value { get; set; }
    public string ShowValue => Value.State.ToString();

    public int Row { get; }
    public int Column { get; }

    public CellControl(int row, int column, Thickness border, Cell value)
    {
        Row = row;
        Column = column;
        Border = border;
        Value = value;
    }
}

