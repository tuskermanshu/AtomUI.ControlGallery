using System.Collections.Generic;
  using AtomUI.Controls;
  using AtomUIGallery.ShowCases.ViewModels;
  using Avalonia.Controls;
  using Avalonia.Controls.Primitives;
  using Avalonia.Interactivity;
  using Avalonia.ReactiveUI;

  namespace AtomUIGallery.ShowCases.Views;

  public partial class BoxPanelShowCase : ReactiveUserControl<BoxPanelViewModel>
  {
      private Border? _addedSpacing; // 跟踪添加的间距
      private readonly List<Border> _addedPlaceholders = new(); // 跟踪添加的占位符

      public BoxPanelShowCase()
      {
          InitializeComponent();
          SetupEventHandlers();
      }

      private void SetupEventHandlers()
      {
          // Basic - Orientation switch
          Vertical.Checked   += (s, e) => BasicBoxPanel.Orientation = Avalonia.Layout.Orientation.Vertical;
          Horizontal.Checked += (s, e) => BasicBoxPanel.Orientation = Avalonia.Layout.Orientation.Horizontal;

          // Flex Ratio - Orientation switch
          Vertical1.Checked   += (s, e) => FlexBoxPanel.Orientation = Avalonia.Layout.Orientation.Vertical;
          Horizontal1.Checked += (s, e) => FlexBoxPanel.Orientation = Avalonia.Layout.Orientation.Horizontal;

          // JustifyContent
          JustifyFlexStart.Checked += (s, e) => JustifyContentBoxPanel.JustifyContent =
              JustifyContent.FlexStart;
          JustifyFlexEnd.Checked += (s, e) => JustifyContentBoxPanel.JustifyContent = JustifyContent.FlexEnd;
          JustifyCenter.Checked  += (s, e) => JustifyContentBoxPanel.JustifyContent = JustifyContent.Center;
          JustifySpaceBetween.Checked += (s, e) => JustifyContentBoxPanel.JustifyContent =
              JustifyContent.SpaceBetween;
          JustifySpaceAround.Checked += (s, e) => JustifyContentBoxPanel.JustifyContent =
              JustifyContent.SpaceAround;
          JustifySpaceEvenly.Checked += (s, e) => JustifyContentBoxPanel.JustifyContent =
              JustifyContent.SpaceEvenly;

          // AlignItems
          AlignFlexStart.Checked += (s, e) => AlignItemsBoxPanel.AlignItems = AlignItems.FlexStart;
          AlignFlexEnd.Checked   += (s, e) => AlignItemsBoxPanel.AlignItems = AlignItems.FlexEnd;
          AlignCenter.Checked    += (s, e) => AlignItemsBoxPanel.AlignItems = AlignItems.Center;
          AlignStretch.Checked   += (s, e) => AlignItemsBoxPanel.AlignItems = AlignItems.Stretch;

          // FlexWrap
          NoWrap.Checked      += (s, e) => WrapBoxPanel.Wrap = FlexWrap.NoWrap;
          Wrap.Checked        += (s, e) => WrapBoxPanel.Wrap = FlexWrap.Wrap;
          WrapReverse.Checked += (s, e) => WrapBoxPanel.Wrap = FlexWrap.WrapReverse;

          // AlignContent
          ContentFlexStart.Checked += (s, e) => AlignContentBoxPanel.AlignContent = AlignContent.FlexStart;
          ContentFlexEnd.Checked   += (s, e) => AlignContentBoxPanel.AlignContent = AlignContent.FlexEnd;
          ContentCenter.Checked    += (s, e) => AlignContentBoxPanel.AlignContent = AlignContent.Center;
          ContentStretch.Checked   += (s, e) => AlignContentBoxPanel.AlignContent = AlignContent.Stretch;
          ContentSpaceBetween.Checked += (s, e) => AlignContentBoxPanel.AlignContent =
              AlignContent.SpaceBetween;
          ContentSpaceAround.Checked += (s, e) => AlignContentBoxPanel.AlignContent =
              AlignContent.SpaceAround;
          ContentSpaceEvenly.Checked += (s, e) => AlignContentBoxPanel.AlignContent =
              AlignContent.SpaceEvenly;
      }

      private void HandleSpaceSliderValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
      {
          if (ChangeSpaceBoxPanel != null)
          {
              ChangeSpaceBoxPanel.Spacing = e.NewValue;
          }
      }

      private void HandleAddSpaceButtonClicked(object? sender, RoutedEventArgs e)
      {
          if (ChangeSpaceBoxPanel == null || AddSpaceButton == null)
              return;

          if (_addedSpacing == null)
          {
              // 添加固定间距
              _addedSpacing = new Border
              {
                  Width      = ChangeSpaceBoxPanel.Orientation == Avalonia.Layout.Orientation.Horizontal ? 40 : 0,
                  Height     = ChangeSpaceBoxPanel.Orientation == Avalonia.Layout.Orientation.Vertical ? 40 : 0,
                  Background = Avalonia.Media.Brushes.Transparent
              };
              ChangeSpaceBoxPanel.Children.Add(_addedSpacing);
              AddSpaceButton.Content = "Remove space (40px)";
          }
          else
          {
              // 移除固定间距
              ChangeSpaceBoxPanel.Children.Remove(_addedSpacing);
              _addedSpacing          = null;
              AddSpaceButton.Content = "Add a space of size 40";
          }
      }

      private int _flexToggle = 0;

      private void HandleChangFlexButtonClicked(object? sender, RoutedEventArgs e)
      {
          if (ChangeSpaceBoxPanel?.Children.Count >= 3)
          {
              var flexItem = ChangeSpaceBoxPanel.Children[2];
              _flexToggle = (_flexToggle + 1) % 4; // Cycle through 1, 2, 3, 0
              BoxPanel.SetFlex(flexItem, _flexToggle == 0 ? 1 : _flexToggle);
          }
      }

      private void HandleAddFlexButtonClicked(object? sender, RoutedEventArgs e)
      {
          if (AddPlaceholderBoxPanel == null || AddFlexButton == null)
              return;

          if (_addedPlaceholders.Count == 0)
          {
              // 添加 Flex 占位符
              var placeholder = new Border
              {
                  Background = Avalonia.Media.Brushes.LightGray
              };
              BoxPanel.SetFlex(placeholder, 1);

              AddPlaceholderBoxPanel.Children.Add(placeholder);
              _addedPlaceholders.Add(placeholder);

              AddFlexButton.Content = "Remove placeholder";
          }
          else
          {
              // 移除最后一个占位符
              var lastPlaceholder = _addedPlaceholders[_addedPlaceholders.Count - 1];
              AddPlaceholderBoxPanel.Children.Remove(lastPlaceholder);
              _addedPlaceholders.RemoveAt(_addedPlaceholders.Count - 1);

              if (_addedPlaceholders.Count == 0)
              {
                  AddFlexButton.Content = "Add a placeholder flex";
              }
          }
      }
  }