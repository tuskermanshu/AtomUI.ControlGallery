using System.Diagnostics;
using AtomUIGallery.ShowCases.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.Views;

public partial class SelectShowCase : ReactiveUserControl<SelectViewModel>
{
    public SelectShowCase()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
        CustomSearchSelect.FilterFn = CustomFilter;
    }

    public static bool CustomFilter(object value, object filterValue)
    {
        // 使用大小写敏感的搜索
        var valueStr = value.ToString();
        Debug.Assert(valueStr != null);
        var filterStr = filterValue.ToString();
        if (filterStr == null)
        {
            return false;
        }
        return valueStr.Contains(filterStr, StringComparison.Ordinal);
    }
}