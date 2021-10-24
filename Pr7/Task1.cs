using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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

            var words = text.Split(new [] { ' ', '.' }).Where(elem => !string.IsNullOrWhiteSpace(elem));
            foreach (var t in words)
            {
                if (_vocabulary.ContainsKey(t)) 
                    continue;

                Console.WriteLine($"Enter substitute for {t}: ");
                var newWord = Console.ReadLine();
                _vocabulary.Add(t, newWord);
            }

            foreach (var pair in _vocabulary)
            {
                text = text.Replace(pair.Key, pair.Value);
            }

            return text;
        }

    }
}
