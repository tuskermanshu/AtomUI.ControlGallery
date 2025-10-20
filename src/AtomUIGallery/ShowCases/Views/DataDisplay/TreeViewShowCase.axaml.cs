using AtomUI.Controls.Primitives;
using AtomUIGallery.ShowCases.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.Views;

public partial class TreeViewShowCase : ReactiveUserControl<TreeViewViewModel>
{
    public TreeViewShowCase()
    {
        this.WhenActivated(disposables =>
        {
            if (DataContext is TreeViewViewModel viewModel)
            {
                InitBasicTreeViewData(viewModel);
            }
        });
        InitializeComponent();
    }

    private void InitBasicTreeViewData(TreeViewViewModel viewModel)
    {
        viewModel.BasicTreeViewDefaultExpandedPaths = [
            new TreeNodePath("0-0/0-0-0"),
            new TreeNodePath("0-0/0-0-1/0-0-1-1")
        ];
        
        viewModel.BasicTreeViewDefaultSelectedPaths =
        [
            new TreeNodePath("0-0/0-0-1")
        ];
        
        viewModel.BasicTreeViewDefaultCheckedPaths =
        [
            new TreeNodePath("0-0/0-0-0"),
            new TreeNodePath("0-0/0-0-1")
        ];
    }
}