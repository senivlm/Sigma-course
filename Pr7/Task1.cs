using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Pr7
{
    class Task1
    {
        private Dictionary<string, string> _vocabulary = new Dictionary<string, string>();

        public string SetVocabulary(string text)
        {
            _vocabulary.Add("I", "boy");
            _vocabulary.Add("go", "run");
            _vocabulary.Add("to", "to");
            _vocabulary.Add("school", "cinema");

            var convertedStr = "";
            var sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var words = new List<string>();

            foreach (var t in sentences)
            {
                words.AddRange(t.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }

            for (var i = 0; i < words.Capacity; i++)
            { Тут має бути цикл
                if (_vocabulary.ContainsKey(words[i]))
                {
                    words[i] = _vocabulary[$"{words[i]}"];
                }
                else
                {
                    Console.WriteLine($"Enter substitute for {words[i]}: ");
                    words[i] = Console.ReadLine();
                }

                convertedStr += words[i];
            }

            return convertedStr;
        }

    }
}
