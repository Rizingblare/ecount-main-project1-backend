﻿namespace Command
{
    public static class CommonExtension
    {
        public static bool vIsNull<T>(this T obj)
        {
            return obj.Equals(null);
        }

        public static bool vIsEmpty<T>(this T obj)
        {
            return obj.Equals(null);
        }

        public static bool vIsNotEmpty<T>(this T obj)
        {
            return !obj.Equals(null);
        }

        public static bool vIsDefault<T>(this T obj)
        {
            return obj.Equals(null);
        }
    }
    public static class CommandExtension
    {
        public static void AddError(this ICommand executable, BaseError error)
        {
            executable.Errors.Add(error);
        }
    }
}
