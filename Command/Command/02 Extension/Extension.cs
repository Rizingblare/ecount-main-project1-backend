using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
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
        public static void AddError(this IExecutable executable, BaseError error)
        {
            executable.Errors.Add(error);
        }
    }
}
