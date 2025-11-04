using AtomUIGallery.ShowCases.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.Views;

public partial class QRCodeShowCase : ReactiveUserControl<QRCodeViewModel>
{
    public QRCodeShowCase()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}