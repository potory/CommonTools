using System;

namespace CommonTools.Extensions
{
    /// <summary>
    /// Класс расширений для валидации значений
    /// </summary>
    public static class ValidationExtensions
    {
        public static T MustBeNotNull<T>(this T obj, string variableName = "") where T: class
        {
            if (obj != null)
            {
                return obj;
            }
            
            if (string.IsNullOrEmpty(variableName))
            {
                throw new ValueValidationException("Variable is null");
            }

            throw new ValueValidationException($"Variable is null: {variableName}");
        }

        public static T MustBeEqual<T>(this T obj, T candidate)
        {
            if (obj.Equals(candidate))
            {
                return obj;
            }

            throw new ValueValidationException("Variables are not equal");
        }

        public static T Or<T>(this T obj, T candidate) where T: class
        {
            return obj ?? candidate;
        }
        
        public static TComparable MustBeIn<TComparable, TException>(this TComparable entity, TComparable min, TComparable max) where TComparable : IComparable where TException: Exception, new()
        {
            var minCompare = entity.CompareTo(min);

            if (minCompare < 0)
            {
                throw new TException();
            }

            var maxCompare = entity.CompareTo(max);
            
            if (maxCompare > 0)
            {
                throw new TException();
            }

            return entity;
        }
        
        public static TComparable MustBeIn<TComparable>(this TComparable entity, TComparable min, TComparable max) where TComparable : IComparable
        {
            return MustBeIn<TComparable, ValueValidationException>(entity, min, max);
        }
    }

    public class ValueValidationException : Exception
    {
        public ValueValidationException() : base()
        {
            
        }

        public ValueValidationException(string message) : base(message)
        {
            
        }
    }
}