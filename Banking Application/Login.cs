using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banking_Application
{
    class Login
    {
        #region Attributes
        public List<Customer> customerList { get; set; }
        #endregion
        #region Builder
        public Login()
        {
            //Console.WriteLine("1");
        }
        #endregion
        #region Methods
        public void Log()
        {
            ConsoleKeyInfo cki;
            do
            {
                bool s;
                int select = 0;
                do
                {

                    Console.Clear();
                    Console.WriteLine("                                                BANKING APPLICATION\n"
                         + "\n"
                         + " 1 : Bank employee \n"
                         + " 2 : Customer \n"
                         + "\n"
                         + "Select the right one ");
                    Console.WriteLine();
                    try
                    {
                        s = true;
                        select = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        s = false;
                        Console.WriteLine("Start again !");
                    }
                } while (s == false);
                Console.WriteLine();

                switch (select)
                {
                    case 1:
                        Console.WriteLine("\nIf you really are an employee please enter the code.");
                        string pin = Convert.ToString(Console.ReadLine());
                        if (pin == "A1234")
                        {
                            bool f = false;
                            int godmode = 0;

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("\nWhat do you want to do ? :\n"
                                     + " 1 : Add Customer \n"
                                     + " 2 : Delete Customer \n"
                                     + " 3 : Add Money \n"
                                     + " 4 : Remove Money \n"
                                     + " 5 : Show list customer with their balance \n"
                                     + " 6 : Back to menu ! \n"
                                     + "\n"
                                     + " Choose !");
                                Console.WriteLine("What do you want to do ?");

                                f = false;
                                while (f == false)
                                {
                                    try
                                    {
                                        f = true;
                                        godmode = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        f = false;
                                        Console.WriteLine("Try again !");
                                    }
                                }
                                switch (godmode)
                                {
                                    case 1:
                                        CreateObjects();
                                        break;
                                    case 2:
                                        Removecust();
                                        break;
                                    case 3:
                                        Console.WriteLine("\nWrite the First name of the customer ");
                                        string stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("\nWrite the Last name of the customer ");
                                        string ndName = Convert.ToString(Console.ReadLine());

                                        Console.WriteLine("\nwhich type of account \n"
                                             + "\n"
                                             + " 1 : Saving account \n"
                                             + " 2 : Current account \n"
                                             + "\n"
                                             + "Select the right one ");
                                        Console.WriteLine();
                                        int type = Convert.ToInt32(Console.ReadLine());

                                        if (type == 1)
                                        {
                                            SavingAccounts sav = new SavingAccounts(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            sav.AddMoney("saving", Money);
                                        }
                                        else if (type == 2)
                                        {
                                            CurrentAccount cur = new CurrentAccount(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            cur.AddMoney("current", Money);
                                        }
                                        else Console.WriteLine("\nChoose Saving or Current account !");

                                        break;
                                    case 4:
                                        Console.WriteLine("\nWrite the First name of the customer ");
                                        stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("\nWrite the Last name of the customer ");
                                        ndName = Convert.ToString(Console.ReadLine());

                                        Console.WriteLine("\nwhich type of account \n"
                                             + "\n"
                                             + " 1 : Saving account \n"
                                             + " 2 : Current account \n"
                                             + "\n"
                                             + "Select the right one ");
                                        Console.WriteLine();
                                        type = Convert.ToInt32(Console.ReadLine());

                                        if (type == 1)
                                        {
                                            SavingAccounts sav = new SavingAccounts(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            sav.RemoveMoney("saving", Money);
                                        }
                                        else if (type == 2)
                                        {
                                            CurrentAccount cur = new CurrentAccount(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            cur.RemoveMoney("current", Money);
                                        }
                                        else Console.WriteLine("\nChoose Saving or Current account !");
                                        break;
                                    case 5:
                                        CustomerList();
                                        break;
                                    case 6:
                                        goto telep;
                                    default:
                                        break;
                                }

                            }

                        }
                        else Console.WriteLine("\nPlease start again kk ! Pay attention to the capital letter !");
                        telep:;
                        break;

                    case 2:
                        Console.WriteLine(" \nHello ! ");
                        if (Verif() == true)
                        {
                            bool h = false;
                            int noob = 0;

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("\nWhat do you want to do ? :\n"
                                     + " 1 : Add money \n"
                                     + " 2 : Remove money \n"
                                     + " 3 : Check transaction \n"
                                     + " 4 : Back to menu \n"
                                     + "\n"
                                     + " Choose !");
                                Console.WriteLine("\nWhat do you want to do ?");

                                h = false;
                                while (h == false)
                                {
                                    try
                                    {
                                        h = true;
                                        noob = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        h = false;
                                        Console.WriteLine(" Try again !");
                                    }
                                }
                                switch (noob)
                                {
                                    case 1:
                                        Console.WriteLine("\nCan you rewrite your First name ");
                                        string stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("\nCan you rewrite your Last name ");
                                        string ndName = Convert.ToString(Console.ReadLine());

                                        Console.WriteLine("\nwhich type of account \n"
                                            + "\n"
                                            + " 1 : Saving account \n"
                                            + " 2 : Current account \n"
                                            + "\n"
                                            + "Select the right one ");
                                        Console.WriteLine();
                                        int type = Convert.ToInt32(Console.ReadLine());

                                        if (type == 1)
                                        {
                                            SavingAccounts sav = new SavingAccounts(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            sav.AddMoney("saving", Money);
                                        }
                                        else if (type == 2)
                                        {
                                            CurrentAccount cur = new CurrentAccount(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            cur.AddMoney("current", Money);
                                        }
                                        else Console.WriteLine("\nChoose Saving or Current account !");
                                        
                                        break;
                                    case 2:
                                        Console.WriteLine("\nCan you rewrite your First name ");
                                        stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("\nCan you rewrite your Last name ");
                                        ndName = Convert.ToString(Console.ReadLine());

                                        Console.WriteLine("\nwhich type of account \n"
                                           + "\n"
                                           + " 1 : Saving account \n"
                                           + " 2 : Current account \n"
                                           + "\n"
                                           + "Select the right one ");
                                        Console.WriteLine();
                                         type = Convert.ToInt32(Console.ReadLine());

                                        if (type == 1)
                                        {
                                            SavingAccounts sav = new SavingAccounts(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            sav.RemoveMoney("saving", Money);
                                        }
                                        else if (type == 2)
                                        {
                                            CurrentAccount cur = new CurrentAccount(stName, ndName);
                                            Console.WriteLine("\nHow much Money ? ");
                                            double Money = Convert.ToDouble(Console.ReadLine());
                                            cur.RemoveMoney("current", Money);
                                        }
                                        else Console.WriteLine("\nChoose Saving or Current account !");  
                                        
                                        break;
                                    case 3:
                                        Console.WriteLine("\nCan you rewrite your First name ");
                                        stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("\nCan you rewrite your Last name ");
                                        ndName = Convert.ToString(Console.ReadLine());

                                        Console.WriteLine("                               \nSaving                       ");
                                        SavingAccounts sav2 = new SavingAccounts(stName, ndName);
                                            sav2.Transaction("saving");
                                        Console.WriteLine();
                                        Console.WriteLine("=".PadRight(80, '='));

                                        Console.WriteLine("                                \nCurrent                      ");
                                        CurrentAccount cur2 = new CurrentAccount(stName, ndName);
                                            cur2.Transaction("current");
                                        Console.WriteLine();
                                        Console.WriteLine("=".PadRight(80, '='));

                                        break;

                                    case 4:
                                        goto telep2;
                                    default:
                                        break;
                                }
                            }
                        telep2:;
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Type Escape to exit !");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
            Console.Read();
        }

        public bool Verif()
        {
            List<string> aze = new List<string>(File.ReadAllLines(".\\customers.txt"));      // We convert your file into a list of strings to be able to manipulate it. A line in the file corresponds to an element of our list

            Console.WriteLine("Write Your First Name");
            string stName = Console.ReadLine();
            Console.WriteLine("Write Your Last Name");
            string ndName = Console.ReadLine();

            Customer cust = new Customer(stName, ndName);

            string trueName = cust.Name;

            string truetrueName = trueName + ":" + cust.File;

            bool result = aze.Contains(truetrueName);                                    // we are looking for the item in our list

            if (result == true)
            {
                Console.WriteLine("you are in our bank !");
            }
            return result;
        }
        public void Removecust()
        {
            List<string> aze = new List<string>(File.ReadAllLines(".\\customers.txt"));

            Console.WriteLine("Write Your First Name");
            string stName = Console.ReadLine();
            Console.WriteLine("Write Your Last Name");
            string ndName = Console.ReadLine();

            Customer cust = new Customer(stName, ndName);

            string Name = cust.Name;

            string Tname = Name + ":" + cust.File;

            bool result = aze.Contains(Tname);
            if (result == true)
            {
                Console.WriteLine(" The person will be deleted from the list !");
                aze.Remove(Tname);
                File.WriteAllLines(".\\customers.txt", aze.ToArray());                                 //we rewrite the file via the list with one less client
            }
            else Console.WriteLine("The person is not on the list");
        }
        public void CreateObjects()
        {

            Console.WriteLine("Write the First of the customer ");
            string stName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Write the Last of the customer ");
            string ndName = Convert.ToString(Console.ReadLine());

            Customer cust = new Customer(stName, ndName);
            string name = cust.Name;

            string path = ".\\customers.txt";

            string saving = $".\\transaction/{cust.File}-saving.txt";

            string current = $".\\transaction/{cust.File}-current.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(name + ":" + cust.File);
            }

            using (StreamWriter sw = File.AppendText(saving))
            {
                sw.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy")}\tLodgement\t0\t0");
            }

            using (StreamWriter sw = File.AppendText(current))
            {
                sw.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy")}\tLodgement\t0\t0");
            }

        }
        public void CustomerList()
        {
            string path = ".\\customers.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(':');
                        Console.WriteLine($"\t{String.Format("{0,-20}", splitData[0])}\t{splitData[1]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }




            Console.WriteLine("Write the First of the customer ");
            string stName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Write the Last of the customer ");
            string ndName = Convert.ToString(Console.ReadLine());

            Customer cust = new Customer(stName, ndName);




            Console.WriteLine();
            Console.WriteLine("=".PadRight(80, '='));

            SavingAccounts sav = new SavingAccounts(stName, ndName);
            Console.WriteLine("                                 Saving                       ");
            sav.Transaction("saving");
            Console.WriteLine();
            Console.WriteLine("=".PadRight(80, '='));

            CurrentAccount cur = new CurrentAccount(stName, ndName);
            Console.WriteLine("                                 Current                      ");
            cur.Transaction("current");
            Console.WriteLine();
            Console.WriteLine("=".PadRight(80, '='));
            Console.ReadKey();
        }

        #endregion
    }
}
