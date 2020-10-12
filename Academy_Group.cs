using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;

namespace Group
{
    class Academy_Group : Graphics, ICloneable, IEnumerable, IEnumerator
    {
        private List<Student> Groups;
        private int count;

        public Academy_Group()
        {
            Groups = new List<Student>();
            count = Groups.Count;
        }

        public void Add()
        {
            Add_Form();
            try
            {
                Student St = new Student();
                Console.SetCursorPosition(10, 1);
                St.Name = Console.ReadLine();
                Console.SetCursorPosition(13, 2);
                St.Surname = Console.ReadLine();
                Console.SetCursorPosition(9, 3);
                St.Age = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(13, 4);
                St.Average = Convert.ToDouble(Console.ReadLine());
                Console.SetCursorPosition(11, 5);
                St.Phone = Console.ReadLine();
                Console.SetCursorPosition(16, 6);
                St.Number_of_group = Console.ReadLine();
                if (St.Name.Length > 1 && St.Surname.Length > 1)
                {
                    Groups.Add(St);
                    count++;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Main_Menu();
        }

        public void Remove()
        {
            if (Groups.Count == 0)
            {
                Main_Menu();
                return;
            }
            Delete_Form();
            Console.Write("\\.");
            Print();
            Console.SetCursorPosition(36, 1);
            string second_name = Console.ReadLine();
            foreach (var student in Groups)
                if (student.Surname == second_name)
                {
                    Groups.Remove(student);
                    count--;
                    break;
                }
            Main_Menu();
        }

        public void Edit()
        {
            if (Groups.Count < 1)
            {
                Main_Menu();
                return;
            }
            Edit_Form();
            Console.Write("\\.");
            Print();
            Console.SetCursorPosition(34, 1);
            string second_name = Console.ReadLine();
            int check = count;
            foreach (var student in Groups)
                if (student.Surname == second_name)
                {
                    Groups.Remove(student);
                    count--;
                    break;
                }
            if (check != count)
                Add();
            else
                Main_Menu();
        }

        //private bool Fake_Entry()
        //{
        //    return Groups.Count == 0 ? true : false;
        //}

        public void Print()
        {
            if (Groups.Count == 0)
            {
                Main_Menu();
                return;
            }
            int i = 0;
            foreach (var student in Groups)
            {
                Console.WriteLine("______________________________");
                Console.WriteLine("   | Name - " + student.Name);
                Console.WriteLine("№" + i++ + " | Surname - " + student.Surname);
                Console.WriteLine("---| Age - " + student.Age);
                Console.WriteLine("   | Average - " + student.Average);
                Console.WriteLine("   | Phone - " + student.Phone);
                Console.WriteLine("   | Name Group - " + student.Number_of_group);
            }
        }

        private Menu Sort_Menu()
        {
            Choose_Sort_Form();
            ConsoleKeyInfo Input;
            Menu Item = Menu.SortName;
            ChangeSortString(Item, ConsoleColor.Yellow);
            do
            {
                Input = Console.ReadKey(true);
                switch (Input.Key)
                {
                    case ConsoleKey.UpArrow:
                        ChangeSortString(Item, Console.ForegroundColor);
                        ChangeSortString(Item = Item > Menu.SortName ? Item -= Menu.Next : Menu.SortAverage, ConsoleColor.Yellow);
                        break;
                    case ConsoleKey.DownArrow:
                        ChangeSortString(Item, Console.ForegroundColor);
                        ChangeSortString(Item = Item < Menu.SortAverage ? Item += (byte)Menu.Next : Menu.SortName, ConsoleColor.Yellow);
                        break;
                    case ConsoleKey.Enter:
                        return Item;
                }
            } while (Input.Key != ConsoleKey.Escape);
            return Menu.Back;
        }

        public void Sort()
        {
            if (Groups.Count < 2)
            {
                Main_Menu();
                return;
            }
            switch (Sort_Menu())
            {
                case Menu.SortAge:
                    Groups.Sort(new Student.SortByAge());
                    break;
                case Menu.SortAverage:
                    Groups.Sort(new Student.SortByAverage());
                    break;
                case Menu.SortGroup:
                    Groups.Sort(new Student.SortByGroup());
                    break;
                case Menu.SortName:
                    Groups.Sort();
                    break;
                case Menu.SortSurname:
                    Groups.Sort(new Student.SortBySurname());
                    break;
                case Menu.Back:
                    Main_Menu();
                    break;
            }
            Console.Clear();
            Print_Config();
            Main_Menu();
        }

        public void Copy(Academy_Group previous)
        {
            if (Groups.Count < 1)
            {
                Main_Menu();
                return;
            }
            Copy_Form();
            Group_List();
            Console.SetCursorPosition(27, 1);
            Groups.InsertRange(Groups.Count - 1, (List<Student>)previous.Clone());
            count = Groups.Count;
            Main_Menu();
        }

        private void Group_List()
        {
            List<string> groups = new List<string>();
            foreach (var group in Groups)
                groups.Add(group.Number_of_group);
            groups = new List<string>(groups.Distinct());
            int count = 0;
            Console.WriteLine("\n\nGroup names - ");
            foreach (var i in groups)
            {
                Console.WriteLine("№" + count++ + "  |" + i);
                Console.WriteLine("____|__________________________");
            }
        }

        public void Save()
        {
            try
            {
                FileStream file = new FileStream("save.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file);
                writer.Write(count);
                foreach (var student in Groups)
                {
                    writer.Write(student.Age);
                    writer.Write(student.Average);
                    writer.Write(student.Name);
                    writer.Write(student.Number_of_group);
                    writer.Write(student.Phone);
                    writer.Write(student.Surname);
                }
                writer.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void Load()
        {
            try
            {
                FileStream file = new FileStream("save.dat", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Student stud = new Student();
                    stud.Age = reader.ReadInt32();
                    stud.Average = reader.ReadDouble();
                    stud.Name = reader.ReadString();
                    stud.Number_of_group = reader.ReadString();
                    stud.Phone = reader.ReadString();
                    stud.Surname = reader.ReadString();
                    Groups.Add(stud);
                }
                reader.Close();
                file.Close();
            }
            catch
            {
                return;
            }
        }

        public void Search()
        {
            if (Groups.Count < 1)
            {
                Main_Menu();
                return;
            }
            Search_Form();
            Console.Write("\\.");
            Print();
            Console.SetCursorPosition(40, 1);
            string name = Console.ReadLine();
            foreach (var student in Groups)
                if (student.Surname == name || student.Name == name)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("_______________________________");
                    Console.WriteLine("|  | Name - " + student.Name);
                    Console.WriteLine("|" + "  | Surname - " + student.Surname);
                    Console.WriteLine("|  | Age - " + student.Age);
                    Console.WriteLine("|  | Average - " + student.Average);
                    Console.WriteLine("|  | Phone - " + student.Phone);
                    Console.WriteLine("|  | Name Group - " + student.Number_of_group);
                    Console.WriteLine("|__|___________________________");
                    Press_Back();
                    break;
                }
            Main_Menu();
        }

        public object Clone()
        {
            string group = Console.ReadLine();
            List<Student> C_Group = new List<Student>();
            foreach (var student in Groups)
                if (group == student.Number_of_group)
                    C_Group.Add(student);
            return C_Group;
        }
        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        public IEnumerator GetEnumerator()
        {
            return Groups.GetEnumerator();
        }

        private int position = -1;
        public object Current
        {
            get
            {
                if (position == -1 || position >= Groups.Count)
                    throw new InvalidOperationException();
                return Groups[position];
            }
        }

        public bool MoveNext()
        {
            if (position < Groups.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }

        private void Press_Back()
        {
            do
            {
                ConsoleKeyInfo Input = Console.ReadKey();
                if (Input.Key == ConsoleKey.Escape || Input.Key == ConsoleKey.Enter || Input.Key == ConsoleKey.Spacebar)
                    break;
            } while (true);
        }

        public void Print_Config()
        {
            if (Groups.Count > 0)
            {
                Print();
                Press_Back();
            }
            Main_Menu();
        }
    }
}
