using System.IO;
using System.Linq;

namespace ZxTodoApp.Core;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static bool IsNotNullOrWhiteSpace(this string str)
    {
        return str.IsNullOrWhiteSpace() == false;
    }

    public static string NullWhiteSpaceOrElse(this string? str, string elseStr)
    {
        return str.IsNullOrWhiteSpace() ? elseStr : str!;
    }

    public static bool IsUpper(this string str)
    {
        return str.Any(c => c is >= 'A' and <= 'Z');
    }

    public static bool In(this string str, params string[] strArr)
    {
        return strArr.Contains(str);
    }

    public static bool NotIn(this string str, params string[] strArr)
    {
        return str.In(strArr) == false;
    }

    public static bool InContains(this string str, params string[] strArr)
    {
        return strArr.Any(str.Contains);
    }

    public static bool InStartsWith(this string str, params string[] strArr)
    {
        return strArr.Any(str.StartsWith);
    }

    public static bool EndsWith(this string str, params string[] strArr)
    {
        return strArr.Any(str.EndsWith);
    }

    public static string TrimEnd(this string str, params string[] strArr)
    {
        while (str.EndsWith(strArr)) str = strArr.Aggregate(str, (lStr, trimStr) => lStr.EndsWith(trimStr) ? lStr[..^trimStr.Length] : lStr);

        return str;
    }

    public static string GetFileNameWithoutExtension(this string str)
    {
        return Path.GetFileNameWithoutExtension(str);
    }
}