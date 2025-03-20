using System.IO;

namespace ZxTodoApp.Core;

public static class FileExtensions
{
    public static void FileExistsRemove(this string path)
    {
        if (path.IsNotNullOrWhiteSpace() && File.Exists(path)) File.Delete(path);
    }

    public static void DirectoryExistsRemove(this string path)
    {
        if (path.IsNotNullOrWhiteSpace() && Directory.Exists(path)) Directory.Delete(path);
    }

    public static void DirectoryNotExistsCreate(this string path)
    {
        var dir = Path.GetDirectoryName(path);
        if (dir.IsNullOrWhiteSpace()) return;
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
    }
}