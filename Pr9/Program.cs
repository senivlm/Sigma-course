using System;
using System.IO;
using System.Text;
using Pr2;

namespace Pr9
{
    class Program
    {
        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void RemoveExpired(Storage storage)
        {
            storage.RemoveExpired();
        }

        static void LogInFile(string path, Product product)
        {
            using StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(DateTime.Now);
            file.WriteLine(product.ToString());
        }

        static void WriteToLogFile(string path)
        {
            using StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(DateTime.Now);
            file.WriteLine("Expired products removed");
        }

        static void LogWrongInput(string path, string wrongLine, int paramsCounter)
        {
            using StreamWriter file = new StreamWriter(path, true);
            StringBuilder result = new();
            result.Append("\nWrong input in line:\n " + wrongLine);
            switch (paramsCounter)
            {
                case 1:
                    result.Append("Wrong product's name");
                    break;
                case 2:
                    result.Append("Wrong product's price");
                    break;
                case 3:
                    result.Append("Wrong product's weight");
                    break;
                case 4:
                    result.Append("Wrong product's max shelf life");
                    break;
                default:
                    result.Append("Wrong product's date of manufacture");
                    break;
            }
            file.WriteLine(result.ToString());
        }

        static void CorrectInput(Storage storage, string wrongLine, int paramCounter)
        {
            Console.WriteLine($"Mistake in line\n {wrongLine}\n Enter new product data: ");
            string newName = Console.ReadLine();
            double price = 0;
            double weight = 0;
            while (true)
            {
                Console.WriteLine("Enter new price: ");
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new weight: ");
                if (double.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
            }

            storage.Add(new Product(newName, price, weight));
        }
        static void Main(string[] args)
        {
            var myStorage = new Storage();
            myStorage.OnAdd += ShowMessage;
            myStorage.OnAddLog += LogInFile;
            myStorage.OnWrongInput += LogWrongInput;
            myStorage.OnCorrectWrongInput += CorrectInput;
            myStorage.ReadFromFile(@"D:\Courses\Sigma\Pr9\Models\ProductsInStorage.txt");
            Console.WriteLine(myStorage);

            myStorage.ExpiredProducts += () =>
            {
                WriteToLogFile(@"D:\Courses\Sigma\Pr9\logFile.txt");
                RemoveExpired(myStorage);
                Console.Write("Expired products are removed.");
            };

            var testProduct = new Product("IceCream", 15, 0.2, 40, Convert.ToDateTime("2021.10.25 15:12:14"));

            myStorage.Add(testProduct);

            var test = myStorage.Find(product => product.Weight == 0.2);
            Console.WriteLine("\nItem found: " + test);

            myStorage.Remove("Milk");
            Console.WriteLine(myStorage);
        }
    }
}
