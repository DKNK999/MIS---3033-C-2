using System;
using System.IO;

namespace ReadFileExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ takes string as literal
            string filePath = @"C:\Users\nicho\Downloads\Pride and Prejudice by Jane Austen.txt";

            string entireBook = File.ReadAllText(filePath);
            string[] allLines = File.ReadAllLines(filePath);

            // reads 5 lines at a time then waits for user
            //for (int i = 0; i < allLines.Length; i++)
            //{
            //    if (i % 5 == 0 && i != 0)
            //    {
            //      Console.ReadKey();
            //    }
            //      Console.WriteLine(allLines[i]);
            //}

            // reads a chapter at a time then waits for user
            foreach (var line in allLines)
            {
                
                if (line.Contains("Chapter") == true)
                {
                    Console.ReadKey();
                }
                Console.WriteLine(line);
            }

            //Console.WriteLine(entireBook);
            //Console.WriteLine(allLines);
            
        }
    }
}
