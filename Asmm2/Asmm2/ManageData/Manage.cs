using System;
using System.Collections.Generic;
using System.Text;
using Asmm2.Userinfor;

namespace Asmm2.ManageData
{
    class Manage
    {
        static private List<User> list;
        public Manage()
        {
            list = new List<User>();
        }
        public void Managelist(bool t=false)
        {
            int a;
            int b=0;
            if (t==false)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. View all");
                    Console.WriteLine("2. Add student");
                    Console.WriteLine("3. Search student");
                    Console.WriteLine("4. Delete student");
                    Console.WriteLine("5. Update student");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Enter your choice: ");
                    do
                    {
                        a = int.Parse(Console.ReadLine());
                        if (a < 1 || a > 6) { Console.Write("Invalid, try again: "); }
                    } while (a < 1 || a > 6);
                    switch (a)
                    {
                        case 1: View(true); break;
                        case 2: Add(true); break;
                        case 3: Search(true); break;
                        case 4: Delete(); break;
                        case 5: Update(true); break;
                        case 6: Menu _menu = new Menu(); break;
                    }
                    Console.ReadKey();
                } while (b != 2);
            }
            else if (t == true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. View all");
                    Console.WriteLine("2. Add lecturer");
                    Console.WriteLine("3. Search lecturer");
                    Console.WriteLine("4. Delete lecturer");
                    Console.WriteLine("5. Update lecturer");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Enter your choice: ");
                    do
                    {
                        a = int.Parse(Console.ReadLine());
                        if (a < 1 || a > 6) { Console.Write("Invalid, try again: "); }
                    } while (a != 6);
                    switch (a)
                    {
                        case 1: View(false); break;
                        case 2: Add(false); break;
                        case 3: Search(false); break;
                        case 4: Delete(); break;
                        case 5: Update(false); break;
                        case 6: Menu _menu = new Menu(); break;
                    }
                    Console.ReadKey();
                } while (b != 2);
            }
        }
        public void Add(bool _c = false)
        {
            string c;
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter date of birth: ");
            string dob = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            if (_c == true)
            {
                Console.Write("Enter Batch: ");
                string batch = Console.ReadLine();
                list.Add(new User(id, name, dob, email, address, batch, ""));
            }
            else if (_c == false)
            {

                Console.Write("Enter Dept: ");
                string dept = Console.ReadLine();
                list.Add(new User(id, name, dob, email, address, "", dept));
            }
            do
            {
                Console.WriteLine("Do you want Add more ?  (Y/N) ");
                c = Console.ReadLine();

                if (c == "Y" || c == "y")
                {
                    Add(_c);
                    break;
                }
                else if (c == "N" || c == "n")
                {
                    break;
                }
            } while (c != "Y" && c != "y" && c != "N" && c != "n");
        }
        public void View(bool _c = false)
        {
            foreach (User p in list)
            {
                if (_c == true)
                {

                    Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}", p.ID, p.Name, p.DoB, p.Email, p.Address, p.Batch);

                }
                else if (_c == false)
                {
                    Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}", p.ID, p.Name, p.DoB, p.Email, p.Address, p.Dept);
                }

            }
        }
        public void Update(bool _c = true)
        {
            Console.Write("Enter ID: ");
            string ID = Console.ReadLine();
            bool s = true;
            foreach (User p in list)
            {
                if (p.ID == ID)
                {
                    if (_c == true)
                    {
                        Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}", p.ID, p.Name, p.DoB, p.Email, p.Address, p.Batch);
                        Console.Write("Enter ID: ");
                        p.ID = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        p.Name = Console.ReadLine();
                        Console.Write("Enter Date of Birth: ");
                        p.DoB = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        p.Email = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        p.Address = Console.ReadLine();
                        Console.Write("Enter Batch: ");
                        p.Batch = Console.ReadLine();
                        s = true;
                    }
                    else if (_c == false)
                    {
                        Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}", p.ID, p.Name, p.DoB, p.Email, p.Address, p.Dept);
                        Console.Write("Enter ID: ");
                        p.ID = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        p.Name = Console.ReadLine();
                        Console.Write("Enter Date of Birth: ");
                        p.DoB = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        p.Email = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        p.Address = Console.ReadLine();
                        Console.Write("Enter Department: ");
                        p.Dept = Console.ReadLine();
                        s = true;

                    }
                }
            }
            if (s == false)
            {
                Console.WriteLine("Invalid, try again!");
            }
        }
        public void Search(bool _c = false)
        {
            Console.Write("Enter Id: ");
            string ID = Console.ReadLine();
            bool tr = false;
            foreach (User p in list)
            {

                if (p.ID == ID)
                {
                    Console.WriteLine("");
                    if (_c == false)
                    {
                        Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}", p.ID, p.Name, p.DoB, p.Email, p.Address, p.Batch);

                    }
                    else if (_c == true)
                    {
                        Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}", p.ID, p.Name, p.DoB, p.Email, p.Address, p.Dept);
                    }
                    tr = true;
                }

            }
            if (tr == false)
            {
                Console.WriteLine("Invalid, try again!");

            }
        }
        public void Delete()
        {
            Console.Write("Enter ID: ");
            string ID = Console.ReadLine();
            bool lists = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == ID)
                {
                    list.RemoveAt(i);
                    lists = true;
                    break;
                }               
            }
            if (lists == false)
            {
                Console.WriteLine("Error, try again!");
            }
        }
    }
    
}


