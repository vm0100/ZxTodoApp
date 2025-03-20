using Avalonia.Controls;
using ZxTodoApp.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ZxTodoApp.Views;

[ServiceDescriptor(typeof(MainWindow), ServiceLifetime.Singleton)]
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        
    }
}