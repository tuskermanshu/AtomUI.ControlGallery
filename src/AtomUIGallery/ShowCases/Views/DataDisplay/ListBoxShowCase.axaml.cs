using AtomUI.Controls;
using AtomUIGallery.ShowCases.ViewModels;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.Views;

public partial class ListBoxShowCase : ReactiveUserControl<ListBoxViewModel>
{
    public ListBoxShowCase()
    {
        this.WhenActivated(disposables =>
        {
            if (DataContext is ListBoxViewModel viewModel)
            {
                viewModel.ListItems = [
                    new ListBoxItemData()
                    {
                        Content = "Blue"
                    },
                    new ListBoxItemData()
                    {
                        Content = "Green"
                    },
                    new ListBoxItemData()
                    {
                        Content = "Red"
                    },
                    new ListBoxItemData()
                    {
                        Content = "Yellow"
                    }
                ];
                viewModel.SelectionMode = SelectionMode.Single;
            }
        });
        InitializeComponent();
        // SelectionModeOptionGroup.OptionCheckedChanged += HandleSelectionModeOptionCheckedChanged;
    }

    private void HandleSelectionModeOptionCheckedChanged(object? sender, OptionCheckedChangedEventArgs e)
    {
        if (DataContext is ListBoxViewModel viewModel)
        {
            if (sender is OptionButton optionButton && optionButton.IsChecked == true && optionButton.Tag is SelectionMode selectionMode)
            {
                viewModel.SelectionMode = selectionMode;
            }
        }
    }
}
