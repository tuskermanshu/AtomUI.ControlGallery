using AtomUI.Controls;
using Avalonia.Controls;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.ViewModels;

public class ListBoxViewModel : ReactiveObject, IRoutableViewModel
{
    public static TreeNodeKey ID = "ListBox";
    
    public IScreen HostScreen { get; }
    
    public string UrlPathSegment { get; } = ID.ToString();
    
    private List<IListBoxItemData> _listItems = [];
    
    public List<IListBoxItemData> ListItems
    {
        get => _listItems;
        set => this.RaiseAndSetIfChanged(ref _listItems, value);
    }

    private SelectionMode _selectionMode;
    
    public SelectionMode SelectionMode
    {
        get => _selectionMode;
        set => this.RaiseAndSetIfChanged(ref _selectionMode, value);
    }
    
    public ListBoxViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}