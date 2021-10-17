using System;

namespace Pr7
{
    class Program
    {
        static void Main(string[] args)
        {
            const string text = "I go to school. Girl runs to school";
            var task1 = new Task1();
            var convertedStr = task1.SetVocabulary(text);
            Console.WriteLine(convertedStr);
        }
    }
}
