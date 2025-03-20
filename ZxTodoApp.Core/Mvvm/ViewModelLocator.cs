using System.Collections.Concurrent;
using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ZxTodoApp.Core;

public class ViewModelLocator : AvaloniaObject
{
    private static readonly ConcurrentDictionary<Type, Type?> ViewModelMap = new();

    public static AvaloniaProperty AutoWireViewModelProperty = AvaloniaProperty.RegisterAttached<Control, bool?>(name: "AutoWireViewModel", ownerType: typeof(ViewModelLocator), defaultValue: false);

    public static bool? GetAutoWireViewModel(AvaloniaObject obj) => (bool?)obj.GetValue(AutoWireViewModelProperty);
    public static void SetAutoWireViewModel(AvaloniaObject obj, bool value) => obj.SetValue(AutoWireViewModelProperty, value);

    static ViewModelLocator()
    {
        AutoWireViewModelProperty.Changed.AddClassHandler<AvaloniaObject>(AutoWireViewModelChanged);
    }

    private static void AutoWireViewModelChanged(AvaloniaObject d, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.NewValue is not bool autoWireViewModel || autoWireViewModel == false) return;

        AutowireViewModel(d);
    }

    private static void AutowireViewModel(object sender)
    {
        if (sender is not ContentControl { DataContext: null } view) return;

        var viewModelType = ViewModelMap.GetOrAdd(view.GetType(), _ => GetViewModelByViewType(view.GetType()));
        if (viewModelType == null) return;

        var viewModel = Ioc.Default.GetService(viewModelType);
        if (viewModel == null) return;

        view.DataContext = viewModel;
    }

    private static Type? GetViewModelByViewType(Type viewType)
    {
        var suffix = new[] { "View", "Window", "Page" };

        var viewName = viewType.FullName!.TrimEnd(suffix);
        viewName = viewName.Replace(".Views.", ".ViewModels.");

        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        return Type.GetType($"{viewName}ViewModel, {viewAssemblyName}");
    }
}