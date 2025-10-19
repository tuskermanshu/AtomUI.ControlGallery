using AtomUI.Controls;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.ViewModels;

public class BreadcrumbViewModel : ReactiveObject, IRoutableViewModel
{
    public const string ID = "Breadcrumb";
    
    public IScreen HostScreen { get; }
    
    public string UrlPathSegment { get; } = ID;
    
    private List<BreadcrumbItemData> _breadcrumbItems = [];
    
    public List<BreadcrumbItemData> BreadcrumbItems
    {
        get => _breadcrumbItems;
        set => this.RaiseAndSetIfChanged(ref _breadcrumbItems, value);
    }
    
    public BreadcrumbViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}