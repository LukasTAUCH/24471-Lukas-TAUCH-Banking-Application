using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Customer
    {
        #region Attributes
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
        public int Pin { get; set; }
        #endregion
        #region Builder

        public Customer(string _FirstName, string _LastName, string _File, int _Pin)
        {
            this.FirstName = _FirstName.ToLower();
            this.LastName = _LastName.ToLower();
            this.File = _File;
            this.Pin = _Pin;
        }




        /// <summary>
        /// Builder where we convert the name and first name of the customer into a customer code
        /// </summary>
        public Customer(string _FirstName, string _LastName)
        {
            this.FirstName = _FirstName.ToLower();
            this.LastName = _LastName.ToLower();

            this.Name = FirstName + " " + LastName;
            
            char a = FirstName[0];
            char b = LastName[0];

            int Length = FirstName.Length + LastName.Length;

            int Pos1 = Convert.ToInt32(a) - 96;                 // Thanks to this formula we can recover the position of the letter
            int Pos2 = Convert.ToInt32(b) - 96;                 // However this letter must be in lowercase otherwise the value obtained will be negative

            string Pos11 = Convert.ToString(Pos1);
            string Pos12 = Convert.ToString(Pos2);

            if (Pos1 < 10)                                       // If the position is a number and not a number we must put a 0 in front of it
            {
                Pos11 = '0' + Convert.ToString(Pos1);
            }

            if (Pos2 < 10)
            {
                Pos12 = '0' + Convert.ToString(Pos2);
            }

            this.File = Convert.ToString(a) + Convert.ToString(b) + "-" + Length + "-" + Pos11 + "-" + Pos12; // Customer code 

            this.Pin = Convert.ToInt32(Pos11 + Pos12);                                                        // Pin code
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"je suis le client {FirstName} {LastName}";
        }
        #endregion
    }
}
