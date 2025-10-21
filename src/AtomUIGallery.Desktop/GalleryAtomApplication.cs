﻿using AtomUI.Controls;
using AtomUI.Theme;
using AtomUI.Theme.Language;
using Avalonia.Controls.ApplicationLifetimes;

namespace AtomUIGallery.Desktop;

public class GalleryAtomApplication : BaseGalleryAtomApplication
{
    public override void Initialize()
    {
        base.Initialize();
        this.UseAtomUI(builder =>
        {
            builder.WithDefaultLanguageVariant(LanguageVariant.zh_CN);
            builder.WithDefaultTheme(IThemeManager.DEFAULT_THEME_ID);
            builder.UseOSSControls();
            builder.UseGalleryControls();
            builder.UseOSSDataGrid();
            builder.UseColorPicker();
        });
    }

    public GalleryAtomApplication()
    {
        Name                  = "AtomUI Gallery";
    }
    
    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow       = CreateWorkspaceWindow();
                desktop.MainWindow.Title = Name;
                break;
            // case ISingleViewApplicationLifetime singleView:
            //     singleView.MainView = new MainView();
            //     break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}