using System;

namespace CommonTools.Extensions
{
    /// <summary>
    /// Класс расширений для массивов
    /// </summary>
    public static class ArrayExtensions
    {
        public static int IndexOf<T>(this T[] arr, Func<T, bool> condition)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (condition(arr[i]))
                {
                    return i;
                }
            }

            return -1;
        }
        
        public static T[] For<T>(this T[] arr, Action<int, T> action)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                action(i, arr[i]);
            }

            return arr;
        }
    }
}