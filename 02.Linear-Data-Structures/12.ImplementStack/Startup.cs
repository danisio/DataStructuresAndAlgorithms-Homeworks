/*Implement the ADT stack as auto-resizable array.
Resize the capacity on demand (when no space is available to add / insert a new element).*/

namespace ImplementStack
{
    using System;

    public class Startup
    {
        public static void Main()
        {
           var myStack = new NewStack<int>();
            try
            {
                Console.WriteLine(myStack.Pop());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Index = 0 => exception");
            }

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(6);
            myStack.Push(7);

            Console.WriteLine("Last item -> " + myStack.Peek());
            Console.WriteLine("All items -> " + string.Join(", ", myStack));
        }
    }
}
