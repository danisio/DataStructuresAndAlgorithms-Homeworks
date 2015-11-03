namespace ImplementQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var myQueue = new LinkedQueue<string>();

            myQueue.Enqueue("First item");
            myQueue.Enqueue("Second item");
            myQueue.Enqueue("Third item");
            myQueue.Enqueue("Fourth item");

            Console.WriteLine("It should print the first entered item -> " + myQueue.Dequeue());

            Console.WriteLine("\nAll items:");
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
