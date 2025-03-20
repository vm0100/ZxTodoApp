using System;
using System.Collections.Generic;
using System.Linq;

namespace ZxTodoApp.Core;

public static class CollectionExtensions
{
    /// <summary>
    ///     将集合展开并分别转换成字符串，再以指定的分隔符衔接，拼成一个字符串返回。默认分隔符为逗号
    /// </summary>
    /// <param name="collection"> 要处理的集合 </param>
    /// <param name="separator"> 分隔符，默认为逗号 </param>
    /// <returns> 拼接后的字符串 </returns>
    public static string ExpandAndToString<T>(this List<T> collection, string separator = ",")
    {
        return collection.ExpandAndToString(t => t!.ToString()!, separator);
    }

    /// <summary>
    ///     将集合展开并分别转换成字符串，再以指定的分隔符衔接，拼成一个字符串返回。默认分隔符为逗号
    /// </summary>
    /// <param name="collection"> 要处理的集合 </param>
    /// <param name="separator"> 分隔符，默认为逗号 </param>
    /// <returns> 拼接后的字符串 </returns>
    public static string ExpandAndToString<T>(this IEnumerable<T> collection, string separator = ",")
    {
        return collection.ExpandAndToString(t => t!.ToString()!, separator);
    }

    /// <summary>
    ///     循环集合的每一项，调用委托生成字符串，返回合并后的字符串。默认分隔符为逗号
    /// </summary>
    /// <param name="collection">待处理的集合</param>
    /// <param name="itemFormatFunc">单个集合项的转换委托</param>
    /// <param name="separetor">分隔符，默认为逗号</param>
    /// <typeparam name="T">泛型类型</typeparam>
    /// <returns></returns>
    public static string ExpandAndToString<T>(this IEnumerable<T> collection, Func<T, string> itemFormatFunc, string separetor = ",")
    {
        ArgumentNullException.ThrowIfNull(itemFormatFunc);

        return string.Join(separetor, collection.Select(itemFormatFunc));
    }

    public static List<TResult> ToList<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> selector)
    {
        return collection.Select(selector).ToList();
    }

    public static List<TResult> ToManyList<T, TResult>(this IEnumerable<T> collection, Func<T, IEnumerable<TResult>> selector)
    {
        return collection.SelectMany(selector).ToList();
    }


    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> elements)
    {
        foreach (var e in elements)
            collection.Add(e);
    }
}