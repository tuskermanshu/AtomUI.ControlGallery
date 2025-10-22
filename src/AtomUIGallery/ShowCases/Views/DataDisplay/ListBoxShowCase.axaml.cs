using AtomUI.Controls;
using AtomUIGallery.ShowCases.ViewModels;
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
            }
        });
        InitializeComponent();
    }
}
