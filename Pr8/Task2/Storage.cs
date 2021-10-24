using System;
using System.Collections.Generic;

namespace Pr2
{
    class Storage
    {
        private Product[] _products;
        public Product[] Products => _products;
        private int _maxElements { get; set; }

        public Storage()
        {
            _products = new Product[_maxElements];
            for (int i = 0; i < _maxElements; i++)
            {
                _products[i] = new Product();
            }
        }

        public Storage(Product[] products)
        {
            _products = products;
        }

        public override bool Equals(object obj)
        {
            return obj is Storage storage &&
                   EqualityComparer<Product[]>.Default.Equals(_products, storage._products);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_products);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void FillUp()
        {
            try
            {
                Console.WriteLine("Enter number of elements to store: ");
                _maxElements = Convert.ToInt32(Console.ReadLine());

                for (int i = 0, j = 1; i < _maxElements; i++, j++)
                {
                    Console.WriteLine($"Enter the name of the {j}th product: ");
                    var name = Console.ReadLine();
                    Console.WriteLine($"Enter the price of the {j}th product: ");
                    double price = Double.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter the weight of the {j}th product: ");
                    double weight = Double.Parse(Console.ReadLine());

                    _products[i] = new Product(name, price, weight);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Incorrect input format.");
            }
        }

        public void AutomaticFillUp()
        {
            _products[0] = new Product("Apple", 20, 1);
            _products[1] = new Product("Pear", 70, 2);
            _products[2] = new Product("Grape", 80, 2);
        }

        public void Display()
        {
            for (int i = 0, j = 1; i < _products.Length; i++, j++)
            {
                Console.WriteLine($"Product {j}: " + _products[i].Name + " " + _products[i].Price
                    + " " + _products[i].Weight);
            }
        }

        public Product[] FindMeatProducts()
        {
            Product[] products = new Product[0];

            for (int i = 0, j = 0; i < _products.Length; i++, j++)
            {
                if (_products[i] is Meat)
                {
                    products[j] = new Product();
                    products[j] = _products[i];
                }
            }
            return products;
        }

        public void ChangePrices(int procent)
        {
            foreach (Product prod in _products)
            {
                prod.Price *= procent / 100.0;
            }
        }

        public Product this[int index]
        {
            get
            {
                return _products[index];
            }
            set
            {
                _products[index] = value;
            }
        }

        //public void CheckShelfLife()
        //{
        //    DateTime presentTime = DateTime.Now.Date;

        //    for (int i = 0; i < 3; i++)
        //    {
        //        var endOfShelfLife = _products[i].DateOfManufacture.Add(_products[i].ShelfLife);

        //        if (presentTime < endOfShelfLife)
        //        {
        //            _products[i].remove();
        //        }
        //    }
        //}
    }
}
