using AtomUI.Controls;
using AtomUIGallery.ShowCases.ViewModels;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.Views;

public partial class ListShowCase : ReactiveUserControl<ListViewModel>
{
    public ListShowCase()
    {
        this.WhenActivated(disposables =>
        {
            if (DataContext is ListViewModel viewModel)
            {
                viewModel.ListItems = [
                    new ListItemData()
                    {
                        Content = "Blue"
                    },
                    new ListItemData()
                    {
                        Content = "Green"
                    },
                    new ListItemData()
                    {
                        Content = "Red"
                    },
                    new ListItemData()
                    {
                        Content = "Yellow"
                    }
                ];
                viewModel.ListItemsWidthDisabled = [
                    new ListItemData()
                    {
                        Content = "Blue"
                    },
                    new ListItemData()
                    {
                        Content = "Green"
                    },
                    new ListItemData()
                    {
                        Content = "Red"
                    },
                    new ListItemData()
                    {
                        Content = "Yellow",
                        IsEnabled = false
                    }
                ];
                viewModel.SelectionMode = SelectionMode.Single;
            }
        });
        InitializeComponent();
        SelectionModeOptionGroup.OptionCheckedChanged += HandleSelectionModeOptionCheckedChanged;
    }

    private void HandleSelectionModeOptionCheckedChanged(object? sender, OptionCheckedChangedEventArgs e)
    {
        if (DataContext is ListViewModel viewModel)
        {
            if (e.CheckedOption.IsChecked == true && e.CheckedOption.Tag is SelectionMode selectionMode)
            {
                viewModel.SelectionMode = selectionMode;
            }
        }
    }
}
