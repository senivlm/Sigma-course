using System;
using System.Collections.Generic;
using System.Linq;
using Pr2;

namespace Pr8
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            var sortTesting = new _1Sort();
            object[] testArr = {0.1, 6.4, 2.3, 9.7, 1.1};
            _1Sort.Sort(testArr, sortTesting.ComparisonImpl);

            foreach (var t in testArr)
                Console.WriteLine(t);

            //2
            var initialProducts = new Product[]
            {
                new Product("name")
            };
            var storage1 = new Storage(initialProducts);
            var storage2 = new Storage(initialProducts);

            var sharedProducts = new List<Product>();
            foreach (var product in storage1.Products)
            {
                if (storage2.Products.Contains(product))
                    sharedProducts.Add(product);
            }

            var onlyInFirst = new List<Product>();
            foreach (var product in storage1.Products)
            {
                if (!storage2.Products.Contains(product))
                    onlyInFirst.Add(product);
            }

            var differentProducts = new List<Product>();
            var test1 = storage1.Products.Except(storage2.Products);
            var test2 = storage2.Products.Except(storage1.Products);
            differentProducts.AddRange(test1);
            differentProducts.AddRange(test2);

            //3
            var max = Task3.SolveProblem();
            Console.WriteLine("The biggest number of (): " + max);
        }
    }
}
