using System;
using System.Collections.Generic;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            // list of # (or 2)
            // sign in the middle
            // map
            SortedDictionary<int, char> symbolPosition = new SortedDictionary<int, char>();
            string example = "It's #test example# #for assignment# #for## string";

            string[] input = new string[example.Length];
            input = example.Split(".");
            
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("#"))
                    symbolPosition.Add(i, '#');
            }

            if (symbolPosition.Count % 2 != 0)
                Console.WriteLine("THere is not right amount of #.");

            for (var i = 0; i < input.Length; i++)
            {
                var middleIndex = symbolPosition.Count / 2;
                if (i < middleIndex)
                    input[i].Replace('#', '<');
                else
                    input[i].Replace('#', '>');

                Console.WriteLine(input[i]);
            }
        }
    }
}
