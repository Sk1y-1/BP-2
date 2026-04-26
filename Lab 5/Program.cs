using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lab5;

namespace Lab5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var items = new List<string> { "apple", "banana", "orange", "cherry", "pear" };

            Console.WriteLine("--- Testing FindIndexAsync ---");
            try
            {
                int index = await AsyncArray.FindIndexAsync(items, x => x == "orange");
                Console.WriteLine($"Index of 'orange': {index}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- Testing FindParallelAsync ---");
            using var cts = new CancellationTokenSource();

            try
            {
                Task<int> searchTask = AsyncArray.FindParallelAsync(items, x => x == "pear", cts.Token);

                Console.WriteLine("Search started...");

                int parallelIndex = await searchTask;
                Console.WriteLine($"Index of 'pear': {parallelIndex}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nProgram finished.");
        }
    }
}