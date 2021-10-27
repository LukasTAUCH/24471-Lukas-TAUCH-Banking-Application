using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banking_Application
{
    class Accounts
    {
        #region Attributes
        public int Balance { get; set; }
        public string Action { get; set; }
        public double Money { get; set; }
        public DateTime Date { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        #endregion
        public Accounts()
        {

        }
        public Accounts(string _Fname, string _Lname)
        {
            this.Fname = _Fname;
            this.Lname = _Lname;
        }
        #region Methods
        public void AddMoney(string type, double Money)
        {   
            Customer cust = new Customer(Fname,Lname);         
            string path = $"c:/users/Lukas/downloads/transaction/{cust.File}-{type}.txt";
            string addMoney = Convert.ToString(BalanceNow(type) + Money);
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy")}\tLodgement\t{Money}\t{addMoney}");
            }
        }

        public double BalanceNow(string type)
        {
            Customer cust = new Customer(Fname, Lname);

            string path = $"c:/users/Lukas/downloads/transaction/{cust.File}-{type}.txt";
            string endbalance = File.ReadLines(path).Last();
            string[] endbalance2 = endbalance.Split('\t');
            double endbalance3 = Convert.ToDouble(endbalance2[3]);
            return endbalance3;
        }

        public void RemoveMoney(string type, double Money)
        {
            Customer cust = new Customer(Fname, Lname);
            string path = $"c:/users/Lukas/downloads/transaction/{cust.File}-{type}.txt";
            if (Money < BalanceNow(type))
            {
                string RemoveMoney = Convert.ToString(BalanceNow(type) - Money);
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy")}\tWithdrawal\t{Money}\t{RemoveMoney}");
                }
            }
            else 
            { 
                Console.WriteLine("No enought money");
            } 
        }

        public void Transaction(string type)
        {
            Customer cust = new Customer(Fname, Lname);
            string path = $"c:/users/Lukas/downloads/transaction/{cust.File}-{type}.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"\t{line}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        #endregion

    }
}
