using System;

namespace ConsoleApp
{
    class EntryClass
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information

            var deduplicator = new FileDeDuplicator();
            deduplicator.RemoveDuplicateFile(""); // Replace with your directory path

            Console.WriteLine("Done!");
        }
    }
}

