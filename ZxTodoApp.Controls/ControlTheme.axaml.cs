using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace ZxTodoApp.Controls;

public partial class ControlTheme : Styles
{
    public ControlTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}