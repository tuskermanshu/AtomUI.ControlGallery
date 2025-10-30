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
                InitializeGroupItems(viewModel);
                viewModel.SelectionMode = SelectionMode.Single;
            }
        });
        InitializeComponent();
        // SelectionModeOptionGroup.OptionCheckedChanged += HandleSelectionModeOptionCheckedChanged;
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

    private void InitializeGroupItems(ListViewModel viewModel)
    {
        viewModel.GroupListItems = [
            new ListItemData()
            {
                Content = "Red",
                Group = "Basic Colors"
            },
            new ListItemData()
            {
                Content = "Orange",
                Group = "Basic Colors"
            },
            
            new ListItemData()
            {
                Content = "Green",
                Group   = "Basic Colors"
            },
            new ListItemData()
            {
                Content = "Blue",
                Group   = "Basic Colors"
            },
            new ListItemData()
            {
                Content = "Purple",
                Group   = "Basic Colors"
            },
            new ListItemData()
            {
                Content = "Pink",
                Group   = "Basic Colors"
            },
            new ListItemData()
            {
                Content = "Yellow",
                Group   = "Basic Colors"
            },
            new ListItemData()
            {
                Content = "Brown",
                Group   = "Neutral Colors"
            },
            new ListItemData()
            {
                Content = "White",
                Group   = "Neutral Colors"
            },
            new ListItemData()
            {
                Content = "Black",
                Group   = "Neutral Colors"
            },
           
            new ListItemData()
            {
                Content = "Gray",
                Group   = "Neutral Colors"
            },
            new ListItemData()
            {
                Content = "Turquoise",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Violet",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Magenta",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Maroon",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Navy",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Beige",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Cyan",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Lavender",
                Group   = "Specific Shades"
            },
            new ListItemData()
            {
                Content = "Olive",
                Group   = "Specific Shades"
            },
         
        ];
    }
}
