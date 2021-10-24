using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pr8
{
    class Task3
    {
        public static int SolveProblem()
        {
            var sentences = ReadFromFile("D:\\Courses\\Sigma\\Pr8\\Task2\\test.txt");

            var max = 0;
            foreach (var sentence in sentences)
            {
                var currentSentence = 0;
                foreach (var symb in sentence)
                {
                    if (symb == '(')
                    {
                        currentSentence++;
                        if (currentSentence > max)
                            max = currentSentence;
                    }
                    else if (symb == ')')
                    {
                        currentSentence--;
                    }
                }
            }
            
            return max;
        }

        public static List<string> ReadFromFile(string filePath)
        {
            var sentences = new List<string>();
            using StreamReader reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
                sentences.Add(reader.ReadLine());

            return sentences;
        }
    }
}