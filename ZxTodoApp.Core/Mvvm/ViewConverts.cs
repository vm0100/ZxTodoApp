using Avalonia.Controls;
using Avalonia.Data.Converters;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace ZxTodoApp.Core;

public class ViewConverts
{
    public static IValueConverter ViewTypeToViewConvert = new FuncValueConverter<Type, Control?>(type => Ioc.Default.GetService(type) as Control);

}