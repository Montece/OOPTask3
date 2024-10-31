using OOPTask3.Game;
using OOPTask3.Random;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OOPTask3.WPF.GameStateViews;

namespace OOPTask3.WPF;

public sealed partial class MainWindow
{
    private readonly GameLogic _gameLogic;

    public MainWindow()
    {
        InitializeComponent();

        var viewModel = GetCellViewModel();

        _gameLogic = new(new StandardRandomGenerator(100),
        [
            new MvvmNotStartedGameStateView(viewModel),
            new MvvmRunningGameStateView(viewModel),
            new MvvmLoseGameStateView(viewModel),
            new MvvmWinGameStateView(viewModel)
        ], []);
    }

    private CellViewModel GetCellViewModel()
    {
        return Resources["ViewModel"] as CellViewModel ?? throw new InvalidOperationException("Resource ViewModel not found!");
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        _gameLogic.Start(3, 3, 1);
        _gameLogic.Render();
    }

    private void CellButton_OnClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is not Button button || button.DataContext is not CellControl cellControl)
        {
            return;
        }

        var pressed = false;

        if (e.LeftButton == MouseButtonState.Pressed)
        {
            cellControl.Value.ChangeStateToNextPrimary();
            pressed = true;
        }

        if (e.RightButton == MouseButtonState.Pressed)
        {
            cellControl.Value.ChangeStateToNextSecondary();
            pressed = true;
        }

        if (!pressed)
        {
            return;
        }

        _gameLogic.CheckEnd();
        _gameLogic.Render();

        var index = cellControl.Value.Point.X + cellControl.Value.Point.Y * cellControl.Value.CellsMap.Width;
        var viewModel = GetCellViewModel();
        viewModel.Cells[index] = null;
        viewModel.Cells[index] = cellControl;
    }
}