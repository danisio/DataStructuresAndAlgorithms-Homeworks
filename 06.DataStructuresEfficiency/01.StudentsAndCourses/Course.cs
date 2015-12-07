namespace StudentsAndCourses
{
    using System;

    public class Course : IComparable<Course>
    {
        public Course(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int CompareTo(Course course)
        {
            return string.Compare(this.Name, course.Name, true);
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
