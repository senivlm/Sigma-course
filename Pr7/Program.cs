using System;

namespace Pr7
{
    class Program
    {
        static void Main(string[] args)
        {
            const string text = "I go to school. I go to school";
            var task1 = new Task1();
            var convertedStr = task1.SetVocabulary(text);
            Console.WriteLine(convertedStr);

            var myMenu = new Menu();
            var myPriceList = new PriceList();

            Console.WriteLine(myMenu);
            Console.WriteLine(myPriceList);

            var listOfProducts = Task2.GetList(myMenu, myPriceList);
            for (var i = 0; i < listOfProducts.Capacity - 1; i++)
                Console.Write(listOfProducts[i]);
        }
    }
}
