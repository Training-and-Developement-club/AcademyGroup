using System;

namespace Group
{
    class Person
    {
        protected string name, surname, phone;
        protected int age;

        public Person()
        {
            age = 0;
            name = "";
            surname = "";
            phone = "";
        }

        public Person(string c_name, string c_surname, string c_phone, int c_age)
        {
            name = c_name;
            surname = c_surname;
            phone = c_phone;
            age = c_age;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
            }
        }

        protected void Print()
        {
            Console.WriteLine("Name - " + name + "\nSurname - " + surname + "\nAge" + age + "\nPhone - " + phone);
        }
    }
}
