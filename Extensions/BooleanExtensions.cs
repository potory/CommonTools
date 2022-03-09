using System;

namespace CommonTools.Extensions
{
    /// <summary>
    /// Класс расширений для булевых переменных
    /// </summary>
    public static class BooleanExtensions
    {
        public static void Then(this bool condition, Action action)
        {
            if (condition)
            {
                action?.Invoke();
            }
        }
    }
}