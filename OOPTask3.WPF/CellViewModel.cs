using System.Collections.ObjectModel;

namespace OOPTask3.WPF;

public sealed class CellViewModel
{
    public ObservableCollection<CellControl?> Cells { get; } = [];
}