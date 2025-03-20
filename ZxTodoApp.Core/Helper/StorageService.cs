using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;

namespace ZxTodoApp.Core;

internal static class StorageService
{
    public static FilePickerFileType All { get; } = new("All")
    {
        Patterns = ["*.*"],
        MimeTypes = ["*/*"]
    };

    public static FilePickerFileType Json { get; } = new("Json")
    {
        Patterns = ["*.json"],
        AppleUniformTypeIdentifiers = ["public.json"],
        MimeTypes = ["application/json"]
    };


    public static FilePickerFileType Excel { get; } = new("Excel")
    {
        Patterns = ["*.xls", "*.xlsx"],
        AppleUniformTypeIdentifiers = ["org.openxmlformats.spreadsheetml.sheet", "com.microsoft.excel.xls"],
        MimeTypes = ["application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"]
    };


    public static FilePickerFileType Pdf { get; } = new("PDF")
    {
        Patterns = ["*.pdf"],
        AppleUniformTypeIdentifiers = ["com.adobe.pdf"],
        MimeTypes = ["application/pdf"]
    };

    public static IStorageProvider? GetStorageProvider()
    {
        switch (Application.Current?.ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime { MainWindow: { } window }:
                return window.StorageProvider;
            case ISingleViewApplicationLifetime
            {
                MainView: { } mainView
            }:
            {
                var visualRoot = mainView.GetVisualRoot();
                if (visualRoot is TopLevel topLevel) return topLevel.StorageProvider;

                break;
            }
        }

        return null;
    }

    public static async Task<IStorageFile?> OpenSingleFilePickerAsync(string title, IReadOnlyList<FilePickerFileType> filter, bool multi = false)
    {
        var storageProvider = GetStorageProvider();
        var chooseFiles =
            await storageProvider!.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = title,
                FileTypeFilter = filter,
                AllowMultiple = multi
            });

        return chooseFiles.FirstOrDefault();
    }


    public static async Task<IStorageFolder?> OpenSingleFolderPickerAsync(string title, bool multi = false)
    {
        var storageProvider = GetStorageProvider();
        var chooseFolders =
            await storageProvider!.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = title,
                AllowMultiple = multi
            });
        return chooseFolders.FirstOrDefault();
    }
}