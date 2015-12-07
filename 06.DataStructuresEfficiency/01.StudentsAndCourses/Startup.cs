/*A text file students.txt holds information about students and their courses in the following format:
Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:
Kiril  | Ivanov   | C#
Stefka | Nikolova | SQL
Stela  | Mineva   | Java
Milena | Petrova  | C#
Ivan   | Grigorov | C#
Ivan   | Kolev    | SQL
C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
Java: Stela Mineva
SQL: Ivan Kolev, Stefka Nikolova*/

namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    public static class Startup
    {
        public static readonly SortedDictionary<Course, OrderedBag<Student>> Result = new SortedDictionary<Course, OrderedBag<Student>>();

        public static void Main()
        {
            using (var reader = new StreamReader("../../input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var splittedInfo = line
                        .Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    AddInfo(splittedInfo[2], splittedInfo[0], splittedInfo[1]);
                }
            }

            foreach (var course in Result)
            {
                Console.WriteLine(course.Key + ": " + string.Join(", ", course.Value));
            }
        }

        private static void AddInfo(string courseName, string firstName, string lastName)
        {
            var course = new Course(courseName);
            var student = new Student(firstName, lastName);

            if (!Result.ContainsKey(course))
            {
                Result[course] = new OrderedBag<Student>();
            }

            Result[course].Add(student);
        }
    }
}
