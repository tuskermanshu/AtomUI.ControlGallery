using AtomUI.Controls;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.ViewModels;

public class ListBoxViewModel : ReactiveObject, IRoutableViewModel
{
    public const string ID = "ListBox";
    
    public IScreen HostScreen { get; }
    
    public string UrlPathSegment { get; } = ID;
    
    private List<IListBoxItemData> _listItems = [];
    
    public List<IListBoxItemData> ListItems
    {
        get => _listItems;
        set => this.RaiseAndSetIfChanged(ref _listItems, value);
    }

    public ListBoxViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}