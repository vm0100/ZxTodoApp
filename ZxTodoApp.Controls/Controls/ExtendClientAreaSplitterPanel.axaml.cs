using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Templates;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.Metadata;

namespace ZxTodoApp.Controls;

public class ExtendClientAreaSplitterPanel : ContentControl
{
    public static readonly StyledProperty<object?> PaneProperty = AvaloniaProperty.Register<SplitView, object?>(nameof(Pane));

    public static readonly StyledProperty<IDataTemplate> PaneTemplateProperty = AvaloniaProperty.Register<SplitView, IDataTemplate>(nameof(PaneTemplate));

    public static readonly StyledProperty<BoxShadows> BoxShadowProperty =  AvaloniaProperty.Register<Border, BoxShadows>(nameof(BoxShadow));

    public static readonly StyledProperty<double> ExtendClientAreaTitleBarHeightHintProperty = AvaloniaProperty.Register<Window, double>(nameof(ExtendClientAreaTitleBarHeightHint), -1);

    
    [DependsOn(nameof(PaneTemplate))]
    public object? Pane
    {
        get => GetValue(PaneProperty);
        set => SetValue(PaneProperty, value);
    }

    public IDataTemplate PaneTemplate
    {
        get => GetValue(PaneTemplateProperty);
        set => SetValue(PaneTemplateProperty, value);
    }
    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowProperty);
        set => SetValue(BoxShadowProperty, value);
    }
    public double ExtendClientAreaTitleBarHeightHint
    {
        get => GetValue(ExtendClientAreaTitleBarHeightHintProperty);
        set => SetValue(ExtendClientAreaTitleBarHeightHintProperty, value);
    }


    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);

        return presenter.Name == "PART_PanePresenter" || result;
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == PaneProperty)
        {
            if (change.OldValue is ILogical oldChild) LogicalChildren.Remove(oldChild);

            if (change.NewValue is ILogical newChild) LogicalChildren.Add(newChild);
        }
    }
}