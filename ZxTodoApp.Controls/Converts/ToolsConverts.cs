using Avalonia.Data.Converters;
using Avalonia.Media;
using Material.Icons;

namespace ZxTodoApp.Controls;

public class ToolsConverts
{
    public static IValueConverter MaterialIconKindToGeometryConvert =
        new FuncValueConverter<MaterialIconKind, Geometry>(iconKind => StreamGeometry.Parse(MaterialIconDataProvider.GetData(iconKind)));
}