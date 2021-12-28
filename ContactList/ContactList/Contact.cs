using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    class Contact
    {
        private string fName;
        private string lName;
        private string phone;

        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }

        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.Length == 10)
                {
                    phone = value;
                }
                else
                {
                    phone = "000-000-0000";
                }
            }
        }

        public Contact()
        {
            FirstName = "Dan";
            LastName = "Wright";
            Phone = "6308495098";
        }
        public Contact(string firstName, string lastName, string phones)
        {
            fName = firstName;
            lName = lastName;
            phone = phones;
        }

        public override string ToString()
        {
            string output = String.Empty;
            output += String.Format("{0}, {1}", lName, fName);
            output += String.Format(" ({0}) {1}-{2}", Phone.Substring(0, 3), Phone.Substring(3, 3), Phone.Substring(6, 4));

            return output;
        }
    }//end of class
}//end of namespace

