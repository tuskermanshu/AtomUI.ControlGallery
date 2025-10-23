using AtomUI.Controls;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.ViewModels;

public class SelectViewModel : ReactiveObject, IRoutableViewModel
{
    public static TreeNodeKey ID = "Select";
    
    public IScreen HostScreen { get; }
    
    public string UrlPathSegment { get; } = ID.ToString();
        
    public SelectViewModel(IScreen screen)
    {
        HostScreen  = screen;
    }
}