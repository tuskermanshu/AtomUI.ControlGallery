using AtomUI.Controls;
using Avalonia.Controls;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.ViewModels;

public class ListViewModel : ReactiveObject, IRoutableViewModel
{
    public static TreeNodeKey ID = "List";
    
    public IScreen HostScreen { get; }
    
    public string UrlPathSegment { get; } = ID.ToString();
    
    private List<IListBoxItemData>? _listItems;
    
    public List<IListBoxItemData>? ListItems
    {
        get => _listItems;
        set => this.RaiseAndSetIfChanged(ref _listItems, value);
    }
    
    private List<IListBoxItemData>? _listItemsWidthDisabled = [];
    
    public List<IListBoxItemData>? ListItemsWidthDisabled
    {
        get => _listItemsWidthDisabled;
        set => this.RaiseAndSetIfChanged(ref _listItemsWidthDisabled, value);
    }

    private SelectionMode _selectionMode;
    
    public SelectionMode SelectionMode
    {
        get => _selectionMode;
        set => this.RaiseAndSetIfChanged(ref _selectionMode, value);
    }
    
    public ListViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}