using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pr7
{
    class PriceList
    {
        public Dictionary<string, double> _elements = new Dictionary<string, double>();

        public PriceList(string filePath = "D:\\Courses\\Sigma\\Pr7\\Pr7\\PriceList.txt")
        {
            ReadFromFile(filePath);
        }

        public void ReadFromFile(string filePath)
        {
            var readText = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    readText.Add(reader.ReadLine());
                }
            }

            foreach (var textLine in readText)
            {
                var values = textLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                _elements.Add(values[0], Convert.ToDouble(values[1]));
            }
        }

        public override string ToString()
        {
            var str = "";
            foreach (KeyValuePair<string, double> kvp in _elements)
            {
                Console.WriteLine("Name = {0}\nPrice = {1}",
                    kvp.Key, kvp.Value);
            }

            return str;
        }
    }
}
