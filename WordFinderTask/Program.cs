using System;
using System.Collections.Generic;

namespace WordFinderTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> wordsTream = new string[] { "chill", "cold", "wind" };
            IEnumerable<string> matrix = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };

            IWordFinder wordFinder = new WordFinder(matrix);

            var list = wordFinder.Find(wordsTream);

            Console.WriteLine("*********Found words*********");

            foreach (string wordFound in list)
            {
                Console.WriteLine(wordFound);
            }
            Console.ReadLine();
        }
    }
}
