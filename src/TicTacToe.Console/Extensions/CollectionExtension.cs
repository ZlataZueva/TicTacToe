using System;
using System.Collections.Generic;

namespace TicTacToe.Console.Extensions
{
    public static class CollectionExtension
    {
        public static void ForEach<TElement>(this ICollection<TElement> collection, Action<TElement> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }
    }
}