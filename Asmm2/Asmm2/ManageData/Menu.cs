using System;
using System.Collections.Generic;
using System.Text;

namespace Asmm2.ManageData
{
    class Menu
    {
        public Menu()
        {
            Manage manage = new Manage();
            int choice;
            Console.Clear();
            Console.WriteLine("UNIVERSITY SYSTEM");
            Console.WriteLine("1. Manage Student");
            Console.WriteLine("2. Manage lecturer");
            Console.WriteLine("3. Exit");
            Console.Write("Please choose: ");

            do
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 3) { Console.Write("Invalid, try againt: "); }
            } while (choice < 1 || choice > 3);
            switch (choice)
            {
                case 1:

                    manage.Managelist(false);
                    break;
                case 2:

                    manage.Managelist(true);
                    break;
                case 3: break;
            }
        }
    }
}
