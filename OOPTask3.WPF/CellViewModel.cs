using System.Collections.ObjectModel;
using System.Windows;
using OOPTask3.GameCell;

namespace OOPTask3.WPF;

public sealed class CellViewModel
{
    public ObservableCollection<CellControl> Cells { get; } =
        [
            new CellControl(0, 0, new Thickness(3), new Cell()), 
            new CellControl(0, 0, new Thickness(3), new Cell()), 
            new CellControl(0, 0, new Thickness(3), new Cell()),
            new CellControl(0, 0, new Thickness(3), new Cell()),
            new CellControl(0, 0, new Thickness(3), new Cell()),
            new CellControl(0, 0, new Thickness(3), new Cell()),
            new CellControl(0, 0, new Thickness(3), new Cell()),
            new CellControl(0, 0, new Thickness(3), new Cell()),
            new CellControl(0, 0, new Thickness(3), new Cell()),
        ];
}
