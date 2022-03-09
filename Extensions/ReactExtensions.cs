using System;

namespace CommonTools.Extensions
{
    public static class ReactExtensions
    {
        public static ReactCase<T> Do<T>(this T obj, Func<T, T> action)
        {
            return new ReactCase<T>(obj, action);
        }
    }

    public class ReactCase<T>
    {
        private readonly Func<T, T> _action;
        private T _obj;

        public ReactCase(T obj, Func<T, T> action)
        {
            _obj = obj;
            _action = action;
        }

        public ReactCase<T> If(bool condition)
        {
            if (condition)
            {
                _obj = _action(_obj);
            }

            return this;
        }

        public ReactCase<T> If(Func<T, bool> condition)
        {
            if (condition(_obj))
            {
                _obj = _action(_obj);
            }

            return this;
        }

        public ReactCase<T> While(Func<T, bool> condition)
        {
            while (condition(_obj))
            {
                _obj = _action(_obj);
            }

            return this;
        }

        public ReactCase<T> For(int count)
        {
            for (var i = 0; i < count; i++)
            {
                _obj = _action(_obj);
            }

            return this;
        }

        public ReactCase<T> For(int start, int end)
        {
            for (var i = start; i < end; i += 1)
            {
                _obj = _action(_obj);
            }

            return this;
        }

        public ReactCase<T> For(int start, int end, int step)
        {
            for (var i = start; i < end; i += step)
            {
                _obj = _action(_obj);
            }

            return this;
        }

        public ReactCase<T> After(Func<T, T> func)
        {
            _obj = func(_obj);
            _obj = _action(_obj);

            return this;
        }


        public ReactCase<T> Before(Func<T, T> func)
        {
            _obj = _action(_obj);
            _obj = func(_obj);

            return this;
        }

        public static implicit operator T(ReactCase<T> @case)
        {
            return @case._obj;
        }
    }
}