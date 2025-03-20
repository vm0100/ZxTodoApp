using System.Globalization;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Text;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using ZxTodoApp.Core;
using Microsoft.Extensions.DependencyInjection;
using ZxTodoApp.ViewModels;
using ZxTodoApp.Views;

namespace ZxTodoApp;

public partial class App : Application
{
    public App()
    {
        Ioc.Default.ConfigureServices(ConfigureServices());

        Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

   
    public override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.Remove(BindingPlugins.DataValidators.First(plugin => plugin is DataAnnotationsValidationPlugin));

        if (ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
        {
            base.OnFrameworkInitializationCompleted();
            return;
        }

        desktop.MainWindow = Ioc.Default.GetService<MainWindow>();
        base.OnFrameworkInitializationCompleted();
    }
    
    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.RegisterAttributeServices();
        return services.BuildServiceProvider();
    }
}