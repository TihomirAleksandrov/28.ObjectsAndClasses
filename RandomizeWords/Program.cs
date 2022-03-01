using System;
using System.Linq;

namespace RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomIndex = rnd.Next(0, words.Length);

                string word = words[i];
                words[i] = words[randomIndex];
                words[randomIndex] = word;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
