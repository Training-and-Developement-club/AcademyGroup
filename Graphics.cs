using System;
namespace Group
{
    enum Menu
    {
        Add = 1,
        Next,
        Remove,
        Print = 5,
        Sort = 7,
        Search = 9,
        Dublicate = 11,
        Edit = 13,

        SortName = 1,
        SortSurname = 3,
        SortAge = 5,
        SortGroup = 7,
        SortAverage = 9,
        Back = 11
    }

    class Graphics
    {
        public void Main_Menu()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.Write(".-----------------.\n"
                        + "|    Add Student  |\n"
                        + ":-----------------:\n"
                        + "|  Remove Student |\n"
                        + ":-----------------:\n"
                        + "|   View Group    |\n"
                        + ":-----------------:\n"
                        + "|   Sort Group    |\n"
                        + ":-----------------:\n"
                        + "|  Search Student |\n"
                        + ":-----------------:\n"
                        + "| Dublicate Group |\n"
                        + ":-----------------:\n"
                        + "|  Edit Student   |\n"
                        + ":-----------------:\n"
                        + "|Esc - Save & Exit|\n"
                        + "`-----------------`\n");
        }

        protected void Search_Form()
        {
            Input_Form();
            Console.WriteLine("|Please enter name or surname to find -                   |");
        }

        protected void Add_Form()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.Write(".-------------------------------.\n"
                        + "|  Name -                       |\n"
                        + "|  Surname -                    |\n"
                        + "|  Age -                        |\n"
                        + "|  Average -                    |\n"
                        + "|  Phone -                      |\n"
                        + "|  Group Name -                 |\n"
                        + "`-------------------------------`");
        }

        protected void Delete_Form()
        {
            Input_Form();
            Console.WriteLine("|Please enter last name to delete -");
        }

        protected void Copy_Form()
        {
            Input_Form();
            Console.WriteLine("|Please enter name group -");
        }

        protected void Edit_Form()
        {
            Input_Form();
            Console.WriteLine("|Please enter last name to edit -");
        }

        private void Input_Form()
        {
            Console.CursorVisible = true;
            Console.WriteLine("._________________________________________________________.");
            Console.WriteLine("|                                                         |");
            Console.WriteLine("\\._______________________________________________________./");
            Console.SetCursorPosition(0, 1);
        }

        protected void Choose_Sort_Form()
        {
            Console.CursorVisible = false;
            Console.Write(".-----------------.\n"
                        + "|   Sort By Name  |\n"
                        + ":-----------------:\n"
                        + "| Sort By Surname |\n"
                        + ":-----------------:\n"
                        + "|   Sort By Age   |\n"
                        + ":-----------------:\n"
                        + "|  Sort By Group  |\n"
                        + ":-----------------:\n"
                        + "| Sort By Average |\n"
                        + ":-----------------:\n"
                        + "|   Esc <= Back   |\n"
                        + "`-----------------`\n");
        }

        protected void ChangeSortString(Menu item, ConsoleColor C)
        {
            Console.SetCursorPosition(1, (int)item);
            Console.ForegroundColor = C;
            switch (item)
            {
                case Menu.SortName:
                    Console.Write("   Sort By Name ");
                    break;
                case Menu.SortSurname:
                    Console.Write(" Sort By Surname");
                    break;
                case Menu.SortAge:
                    Console.Write("   Sort By Age  ");
                    break;
                case Menu.SortGroup:
                    Console.Write("  Sort By Group ");
                    break;
                case Menu.SortAverage:
                    Console.Write(" Sort By Average");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ChangeTextString(Menu item, ConsoleColor C)
        {
            Console.SetCursorPosition(1, (int)item);
            Console.ForegroundColor = C;
            switch (item)
            {
                case Menu.Add:
                    Console.Write("   Add Student  ");
                    break;
                case Menu.Remove:
                    Console.Write("  Remove Student");
                    break;
                case Menu.Print:
                    Console.Write("   View Group   ");
                    break;
                case Menu.Sort:
                    Console.Write("   Sort Group   ");
                    break;
                case Menu.Search:
                    Console.Write("  Search Student");
                    break;
                case Menu.Dublicate:
                    Console.Write(" Dublicate Group ");
                    break;
                case Menu.Edit:
                    Console.Write("  Edit Student  ");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
