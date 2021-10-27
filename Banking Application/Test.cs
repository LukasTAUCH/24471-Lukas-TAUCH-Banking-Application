using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banking_Application
{
    class Test
    {
        public List<Customer> customerList { get; set; }
        public Test()
        {
            //Console.WriteLine("1");
        }
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
                    Console.WriteLine("Menu :\n"
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
                        Console.WriteLine("If you really are an employee please enter the code.");
                        string pin = Convert.ToString(Console.ReadLine());
                        if (pin == "A1234")
                        {
                            bool f = false;
                            int godmode = 0;

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("What do you want to do ? :\n"
                                     + " 1 : Add Customer \n"
                                     + " 2 : Delete Customer \n"
                                     + " 3 : Add Money \n"
                                     + " 4 : Remove Money \n"
                                     + " 5 : Show list customer with their balance \n"
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
                                        Console.WriteLine("Veuillez recommencer !");
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
                                        Console.WriteLine("Write the First name of the customer ");
                                        string stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("Write the Last name of the customer ");
                                        string ndName = Convert.ToString(Console.ReadLine());
                                        Accounts acc = new Accounts(stName, ndName);

                                        Console.WriteLine();

                                        Console.WriteLine("which type of account ");
                                        string type = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("How much Money ? ");
                                        double Money = Convert.ToDouble(Console.ReadLine());
                                        acc.AddMoney(type, Money);
                                        break;
                                    case 4:
                                        Console.WriteLine("Write the First name of the customer ");
                                        stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("Write the Last name of the customer ");
                                        ndName = Convert.ToString(Console.ReadLine());
                                        Accounts acc2 = new Accounts(stName, ndName);

                                        Console.WriteLine();

                                        Console.WriteLine("which type of account ");
                                        type = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("How much Money ? ");
                                        Money = Convert.ToDouble(Console.ReadLine());
                                        acc2.RemoveMoney(type, Money);
                                        break;
                                    case 5:
                                        CustomerList();
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }
                        else Console.WriteLine("Please start again kk ! Pay attention to the capital letter !");
                        break;

                    case 2:
                        Console.WriteLine(" Please write your First Name and Name ! ");
                        if ( Verif() == true)
                        {
                            bool h = false;
                            int noob = 0;

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("What do you want to do ? :\n"
                                     + " 1 : Add money \n"
                                     + " 2 : retreve money \n"
                                     + " 3 : Check transaction \n"
                                     + "\n"
                                     + " Choose !");
                                Console.WriteLine("What do you want to do ?");

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
                                        Console.WriteLine("Veuillez recommencer !");
                                    }
                                }
                                switch (noob)
                                {
                                    case 1:
                                        Console.WriteLine("Can you rewrite your First name ");
                                        string stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("Can you rewrite your Last name ");
                                        string ndName = Convert.ToString(Console.ReadLine());
                                        Accounts acc = new Accounts(stName, ndName);

                                        Console.WriteLine();

                                        Console.WriteLine("which type of account ? ");
                                        string type = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("How much Money ? ");
                                        double Money = Convert.ToDouble(Console.ReadLine());
                                        acc.AddMoney(type, Money);
                                        break;
                                    case 2:
                                        Console.WriteLine("Can you rewrite your First name ");
                                        stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("Can you rewrite your Last name ");
                                        ndName = Convert.ToString(Console.ReadLine());
                                        Accounts acc2 = new Accounts(stName, ndName);

                                        Console.WriteLine();

                                        Console.WriteLine("which type of account ? ");
                                        type = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("How much Money ? ");
                                        Money = Convert.ToDouble(Console.ReadLine());
                                        acc2.RemoveMoney(type, Money);
                                        break;
                                    case 3:
                                        Console.WriteLine("Can you rewrite your First name ");
                                        stName = Convert.ToString(Console.ReadLine());
                                        Console.WriteLine("Can you rewrite your Last name ");
                                        ndName = Convert.ToString(Console.ReadLine());
                                        Accounts acc3 = new Accounts(stName, ndName);

                                        Console.WriteLine();

                                        Console.WriteLine("which type of account do you want to see transaction ?");
                                        type = Convert.ToString(Console.ReadLine());

                                        acc3.Transaction(type);
                                        break;
                                    default:
                                        break;
                                }
                            }
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
            List<string> aze = new List<string>(File.ReadAllLines("c:/users/Lukas/downloads/customers.txt"));

            Console.WriteLine("Write Your First Name");
            string stName = Console.ReadLine();
            Console.WriteLine("Write Your Last Name");
            string ndName = Console.ReadLine();

            Customer cust = new Customer(stName, ndName);

            string trueName = cust.Name;

            string truetrueName = trueName + ":" + cust.File;

            bool result = aze.Contains(truetrueName);

            if (result == true)
            {
                Console.WriteLine("you are in our bank !");            
            }
            return result;
        }

        public void Removecust()
        {
            List<string> aze = new List<string>(File.ReadAllLines("c:/users/Lukas/downloads/customers.txt"));

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
                File.WriteAllLines("c:/users/Lukas/downloads/customers.txt",aze.ToArray());
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

            string path = "c:/users/Lukas/downloads/customers.txt";

            string saving = $"c:/users/Lukas/downloads/transaction/{cust.File}-saving.txt";

            string current = $"c:/users/Lukas/downloads/transaction/{cust.File}-current.txt";

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
            string path = "c:/users/Lukas/downloads/customers.txt";
            
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

            Accounts acc = new Accounts(stName, ndName);
            acc.Transaction("saving");
            Console.WriteLine();
            Console.WriteLine("=".PadRight(80, '='));

            Accounts acc2 = new Accounts(stName, ndName);
            acc2.Transaction("current");
            Console.WriteLine();
            Console.WriteLine("=".PadRight(80, '='));
            Console.ReadKey();
        }
    }
}
