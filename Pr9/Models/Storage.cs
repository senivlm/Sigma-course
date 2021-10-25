using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pr2
{
    class Storage
    {
        private List<Product> Products;
        public delegate void PrintMessageHandler(string message);
        public delegate void PrintInLogFile(string path, Product product);
        public delegate void PrintIncorrect(string path, string wrongLine, int paramCounter);
        public delegate void ModifyInput(Storage storage, string wrongLine, int paramCounter);
        public event PrintMessageHandler OnAdd;
        public event PrintInLogFile OnAddLog;
        public event PrintIncorrect OnWrongInput;
        public event ModifyInput OnCorrectWrongInput;

        public event Action ExpiredProducts;

        public Storage(string filePath = @"D:\Courses\Sigma\Pr9\Models\ProductsInStorage.txt")
        {
            Products = new List<Product>();
            ReadFromFile(filePath);
        }

        public Storage(List<Product> products)
        {
            Products = products;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Products);
        }

        public override string ToString()
        {
            ExpiredProducts?.Invoke();
            var tempStr = "";
            foreach (var product in Products)
            {
                tempStr += "Name: " + product.Name + "\n" + "Price: " + product.Price + "\n" + "Weight: " +
                           product.Weight + "\n" + "Shelf life: " + product.MaxShelfLife + "\n" +
                           "Date of manufacture: " + product._dateOfManufacture + "\n\n";
            }
            return tempStr;
        }

        public void ReadFromFile(string filePath)
        {
            Products.Clear();
            var sentences = new List<string>();
            using var reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
                sentences.Add(reader.ReadLine());

            var splitSentences = new List<string>();
            foreach (var str in sentences)
            {
                splitSentences.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }

            var j = 0;
            for (var i = 0; i < sentences.Capacity; i++)
            {
                var tempProduct = new Product(splitSentences[j], Convert.ToDouble(splitSentences[j + 1]),
                    Convert.ToDouble(splitSentences[j + 2]), Convert.ToInt32(splitSentences[j + 3]),
                    Convert.ToDateTime(splitSentences[j + 4] + " " + splitSentences[j + 5]));

                if (!Double.TryParse(splitSentences[j + 1], out _))
                {
                    OnWrongInput?.Invoke(@"D:\Courses\Sigma\Pr9\logFile.txt", sentences[i], 2);
                    OnCorrectWrongInput?.Invoke(this, sentences[i], 2);
                    continue;
                }

                if (!Double.TryParse(splitSentences[j + 2], out _))
                {
                    OnWrongInput?.Invoke(@"D:\Courses\Sigma\Pr9\logFile.txt", sentences[i], 3);
                    OnCorrectWrongInput?.Invoke(this, sentences[i], 3);
                    continue;
                }

                if (!Int32.TryParse(splitSentences[j + 3], out _))
                {
                    OnWrongInput?.Invoke(@"D:\Courses\Sigma\Pr9\logFile.txt", sentences[i], 4);
                    OnCorrectWrongInput?.Invoke(this, sentences[i], 3);
                    continue;
                }

                if (!DateTime.TryParse(splitSentences[j + 4] + " " + splitSentences[j + 5], out _))
                {
                    OnWrongInput?.Invoke(@"D:\Courses\Sigma\Pr9\logFile.txt", sentences[i], 5);
                    OnCorrectWrongInput?.Invoke(this, sentences[i], 3);
                    continue;
                }

                Products.Add(tempProduct);
                j += 6;
            }
        }

        public void AutomaticFillUp()
        {
            Products[0] = new Product("Apple", 20, 1);
            Products[1] = new Product("Pear", 70, 2);
            Products[2] = new Product("Grape", 80, 2);
        }

        public Product this[int index]
        {
            get => Products[index];
            set => Products[index] = value;
        }

        public void Add(Product product)
        {
            OnAddLog?.Invoke(@"D:\Courses\Sigma\Pr9\logFile.txt", product);
            Products.Add(product);
        }

        public void Remove(string name)
        {
            for (var i = 0; i < Products.Count; i++)
            {
                if (Products[i].Name == name)
                {
                    Products.Remove(Products[i]);
                }
            }
        }

        public Product Find(Func<Product, bool> predicate)
        {
            return Products.FirstOrDefault(predicate);
        }

        public void RemoveExpired()
        {
            var presentTime = DateTime.Now.Date;

            for (var i = 0; i <= Products.Capacity; i++)
            {
                var endOfShelfLife = Products[i]._dateOfManufacture;

                if (presentTime < endOfShelfLife)
                {
                    Products.Remove(Products[i]);
                }
            }
        }

        //public Product[] FindMeatProducts()
        //{
        //    Product[] products = new Product[0];

        //    for (int i = 0, j = 0; i < Products.Length; i++, j++)
        //    {
        //        if (Products[i] is Meat)
        //        {
        //            products[j] = new Product();
        //            products[j] = Products[i];
        //        }
        //    }
        //    return products;
        //}

        //public void ChangePrices(int procent)
        //{
        //    foreach (Product prod in Products)
        //    {
        //        prod.Price *= procent / 100.0;
        //    }
        //}

    }
}
