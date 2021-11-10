using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class SavingAccounts : Accounts // Inheritance
    {
        public SavingAccounts()
        {

        }
        public SavingAccounts(string _Fname, string _Lname) : base(_Fname, _Lname)     // The "Savingaccount" class inherits from the constructor of the "account" parent class
        {


        }
    }
    class CurrentAccount : Accounts
    {
        public CurrentAccount()
        {

        }

        public CurrentAccount(string _Fname, string _Lname) : base(_Fname, _Lname)
        {

        }
    }
}
