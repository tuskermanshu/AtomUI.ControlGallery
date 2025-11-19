using AtomUI.Controls;

namespace AtomUIGallery.Icon.Application;

public partial class ApplicationIconPackage : IconPackage<ApplicationIconKind>
{
    public static ApplicationIconPackage Current { get; }

    static ApplicationIconPackage()
    {
        Current = new ApplicationIconPackage();
    }
    
    public ApplicationIconPackage()
        : base("AtomUIGalleryIcon")
    {
        SetupIconPool();
    }

    private partial void SetupIconPool();
}