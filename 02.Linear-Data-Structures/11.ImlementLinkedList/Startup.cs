/*Implement the data structure linked list.
Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).*/

namespace ImlementLinkedList
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var test = new LinkedList2<string>();

            test.AddFirst("First string");
            test.AddLast("Second string");
            test.AddFirst("Should be before first");
            test.AddLast("Should be after last");

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

            test.Clear();
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
        }
    }
}
