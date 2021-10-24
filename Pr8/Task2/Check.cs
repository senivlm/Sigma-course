using System;

namespace Pr2
{
    sealed class Check
    {
        public void ShowInfo()
        {
            try
            {
                Console.WriteLine("Enter the name of a product: ");
                var name = Console.ReadLine();
                Console.WriteLine("Enter the number of products: ");
                var num = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter its price: ");
                var price = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter its weight: ");
                var weight = Double.Parse(Console.ReadLine());

                var productsToBuy = new Product[num];

                for (int i = 0; i < num; i++)
                {
                    productsToBuy[i] = new Product(name, price, weight);
                }

                Buy buy = new Buy(productsToBuy, num, price, weight);
                Console.WriteLine("Your purchase contains: \nName " + name + "\nTotal price " + buy.Cost + "\nTotal weight " + buy.Weight + '\n');
            } catch (FormatException)
            {
                Console.WriteLine("Incorrect format.\n");
            }
        }
    }

//class Test : Check
//{

//}

}