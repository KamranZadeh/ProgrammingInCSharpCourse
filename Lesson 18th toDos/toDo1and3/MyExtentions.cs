using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace toDo1and3
{
    public static class MyExtentions
    {
        public static IEnumerable<TSource> WhereMy<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate);
        }

        public static TSource? FirstOrDefaultMy<TSource>(this IEnumerable<TSource> source)
        {
            return source.FirstOrDefault();
        }

        public static TSource? FirstOrDefaultMy<TSource> (this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.FirstOrDefault(predicate);
        }
    }
}
