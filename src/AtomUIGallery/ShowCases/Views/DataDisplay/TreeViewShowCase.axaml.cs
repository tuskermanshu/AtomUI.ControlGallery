﻿using AtomUI.Controls;
using AtomUI.Controls.Primitives;
using AtomUIGallery.ShowCases.ViewModels;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AtomUIGallery.ShowCases.Views;

public partial class TreeViewShowCase : ReactiveUserControl<TreeViewViewModel>
{
    public TreeViewShowCase()
    {
        this.WhenActivated(disposables =>
        {
            if (DataContext is TreeViewViewModel viewModel)
            {
                InitBasicTreeViewData(viewModel);
                viewModel.TreeViewNodeHoverMode = TreeItemHoverMode.Default;
                InitBasicTreeNodes(viewModel);
            }
        });
        InitializeComponent();
    }

    private void InitBasicTreeViewData(TreeViewViewModel viewModel)
    {
        viewModel.BasicTreeViewDefaultExpandedPaths = [
            new TreeNodePath("0-0/0-0-0"),
            new TreeNodePath("0-0/0-0-1/0-0-1-1")
        ];
        
        viewModel.BasicTreeViewDefaultSelectedPaths =
        [
            new TreeNodePath("0-0/0-0-1")
        ];
        
        viewModel.BasicTreeViewDefaultCheckedPaths =
        [
            new TreeNodePath("0-0/0-0-1/0-0-1-1")
        ];
    }

    private void HandleHoverModeChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is RadioButton radioButton)
        {
            if (radioButton.IsChecked == true)
            {
                if (radioButton.Tag is TreeItemHoverMode hoverMode)
                {
                    if (DataContext is TreeViewViewModel viewModel)
                    {
                        viewModel.TreeViewNodeHoverMode = hoverMode;
                    }
                }
            }
        }
    }
    
    private void InitBasicTreeNodes(TreeViewViewModel viewModel)
    {
        viewModel.BasicTreeNodes = [
            new TreeViewItemData()
            {
                Header  = "parent 1",
                ItemKey = "0-0",
                Children = [
                    new TreeViewItemData()
                    {
                        Header  = "parent 1-0",
                        ItemKey = "0-0-0",
                        Children = [
                            new TreeViewItemData()
                            {
                                Header    = "leaf 1",
                                ItemKey   = "0-0-0-0",
                                IsEnabled = false
                            },
                            new TreeViewItemData()
                            {
                                Header  = "leaf 2",
                                ItemKey = "0-0-0-1"
                            }
                        ]
                    },
                    new TreeViewItemData()
                    {
                        Header  = "parent 1-1",
                        ItemKey = "0-0-1",
                        Children = [
                            new TreeViewItemData()
                            {
                                Header    = "sss",
                                ItemKey   = "0-0-1-0",
                                Children = [
                                    new TreeViewItemData()
                                    {
                                        Header  = "ccc",
                                        ItemKey = "0-0-1-0-0"
                                    }
                                ]
                            },
                            new TreeViewItemData()
                            {
                                Header  = "xxx",
                                ItemKey = "0-0-1-1",
                                Children = [
                                    new TreeViewItemData()
                                    {
                                        Header  = "aaaa",
                                        ItemKey = "0-0-1-1-0"
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }
        ];
    }
}