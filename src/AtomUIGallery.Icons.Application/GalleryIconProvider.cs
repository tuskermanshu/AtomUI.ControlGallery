using System.Diagnostics;
using System.Reflection;
using AtomUI.Controls;

namespace AtomUIGallery.Icons.Application;

public class GalleryIconProvider : IconProvider<ApplicationIconKind>
{
    public GalleryIconProvider()
    {}
    
    public GalleryIconProvider(ApplicationIconKind kind)
        : base(kind)
    {
    }
    
    protected override Icon GetIcon(ApplicationIconKind kind)
    {
        try
        {
            var fullTypeName = $"AtomUIGallery.Icon.Application.{kind.ToString()}";
            var type = Type.GetType(fullTypeName) 
                       ?? Assembly.GetExecutingAssembly().GetType(fullTypeName);
            
            if (type == null)
            {
                throw new InvalidOperationException($"{fullTypeName} not exist");
            }
            
            var icon = (Icon?)Activator.CreateInstance(type);
            Debug.Assert(icon != null);
            return icon;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"create icon {kind.ToString()} failed", ex);
        }
    }
}