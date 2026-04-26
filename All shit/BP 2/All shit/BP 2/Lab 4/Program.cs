using System;
using Lab4;

class Program
{
    static void Main(string[] args)
    {
        var queue = new BiDirectionalPriorityQueue<string>();

        queue.Enqueue("Task A (Priority 10)", 10);
        queue.Enqueue("Task B (Priority 50)", 50);
        queue.Enqueue("Task C (Priority 10)", 10);
        queue.Enqueue("Task D (Priority 30)", 30);

        Console.WriteLine($"Highest Priority: {queue.Dequeue(Query.Highest)}");
        Console.WriteLine($"Oldest (FIFO):    {queue.Dequeue(Query.Oldest)}");
        Console.WriteLine($"Newest (LIFO):    {queue.Dequeue(Query.Newest)}");
        Console.WriteLine($"Lowest Priority:  {queue.Dequeue(Query.Lowest)}");

        try
        {
            queue.Dequeue(Query.Highest);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.ReadKey();
    }
}