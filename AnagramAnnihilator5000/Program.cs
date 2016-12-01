using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AnagramAnnihilator5000
{
    class Program
    {
        static char[] deferredSort(char[] c)
        {
            Array.Sort(c);
            return c;
        }

        static int annihilateAnagramsGroupBy(List<string> words, int logging = 0)
        {
            // need to use string typing instead of char array here or else the comparison won't happen properly
            var wordsHash = words.GroupBy(x => new string(deferredSort(x.ToCharArray())), x => x);
            using (System.IO.StreamWriter file =
                       new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + @"\anagrams.txt"))
            {
                foreach (IGrouping<string, string> anagram in wordsHash)
                {
                    if (anagram.Count() > 1)
                    {
                        file.WriteLine(anagram.Key);

                        foreach (string name in anagram)
                            file.WriteLine("  {0}", name);
                    }
                }
            }

            return wordsHash.Count();
        }

        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            if (string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please specify the name of a .txt file containing words on separate lines.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            List<string> lines = new List<string>();
            try
            {
                Regex lettersOnly = new Regex("[^a-zA-Z]+");
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)                    
                        lines.Add(lettersOnly.Replace(line, ""));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("Annihilating anagrams with " + lines.Count + " words...");
            time.Start();            
            int cnt = annihilateAnagramsGroupBy(lines);
            time.Stop();
            Console.WriteLine("Finished. Anagram sets: " + cnt + " Time taken: " + time.Elapsed);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}