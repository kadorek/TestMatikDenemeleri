using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMatik_V1.Addons
{
    public static class MyExtensions
    {
        public static void Do<T>(this IList<T> list,Action<T> func) {
            foreach (var item in list)
            {
                func(item);
            }
        }
    }
}