using System;
using System.Collections.Generic;
using System.Text;
using Extensions;
using System.Linq;
using System.Linq.Expressions;

namespace Cslinq
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> cities = new[] { "Ghent", "London", "New Orleans", "Locust Hill" };

            IEnumerable<string> query = cities.Where(city => city.StartsWith("L"))
                .OrderByDescending(city => city.Length);

            foreach (var city in query)
            {
                Console.WriteLine(city);
            }

            WorkWithFuncs();
        }

        private static void WorkWithFuncs()
        {
            Expression<Func<int, int>> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine(x);

            // write(square(add(1, 90)));
        }
    }
}

namespace Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<T> Filter<T>
            (this IEnumerable<T> input, Func<T, bool> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public delegate bool FilterDelegate<T>(T item);
    }
}
