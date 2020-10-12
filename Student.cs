using System;
using System.Collections.Generic;

namespace Group
{
    class Student : Person, IComparable<Student>
    {
        protected double average;
        protected string number_of_group;

        public Student()
            : base()
        {
            average = 0.0;
            number_of_group = "";
        }

        public Student(double c_average, string c_number_of_group, int c_age, string c_name, string c_surname, string c_phone)
            : base(c_name, c_surname, c_phone, c_age)
        {
            average = c_average;
            number_of_group = c_number_of_group;
        }

        public double Average
        {
            get => average;
            set
            {
                average = value;
            }
        }

        public string Number_of_group
        {
            get => number_of_group;
            set
            {
                number_of_group = value;
            }
        }

        public new void Print()
        {
            base.Print();
            Console.Write("Average - " + average + "\nGroup Name - " + number_of_group);
        }

        public int CompareTo(Student obj)
        {
            return name.CompareTo((obj as Student).name);
        }

        public class SortBySurname : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).surname.CompareTo((obj2 as Student).surname);

                throw new NotImplementedException();
            }
        }
        public class SortByAge : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).age.CompareTo((obj2 as Student).age);

                throw new NotImplementedException();
            }
        }
        public class SortByAverage : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).average.CompareTo((obj2 as Student).average);

                throw new NotImplementedException();
            }
        }

        public class SortByGroup : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student obj1, Student obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).number_of_group.CompareTo((obj2 as Student).number_of_group);

                throw new NotImplementedException();
            }
        }
    }
}
