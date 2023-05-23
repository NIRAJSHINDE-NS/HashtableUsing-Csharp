namespace Hashtable
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            // Add elements to the hashtable
            hashTable.Add("apple", 1);
            hashTable.Add("banana", 2);
            hashTable.Add("cherry", 3);

            // Retrieve and print values
            int appleValue;
            if (hashTable.TryGetValue("apple", out appleValue))
            {
                Console.WriteLine("Value of 'apple': " + appleValue);
            }

            int orangeValue;
            if (hashTable.TryGetValue("orange", out orangeValue))
            {
                Console.WriteLine("Value of 'orange': " + orangeValue);
            }
            else
            {
                Console.WriteLine("Key 'orange' does not exist in the hashtable.");
            }

            // Remove an element
            bool removed = hashTable.Remove("banana");
            if (removed)
            {
                Console.WriteLine("Successfully removed 'banana' from the hashtable.");
            }
            else
            {
                Console.WriteLine("'banana' does not exist in the hashtable.");
            }
        }
    }

}