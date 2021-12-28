using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactList
{
    public partial class Form1 : Form
    {
        private Contact[] contactArray = new Contact[1];
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Write(Contact obj) { 
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine(contactArray.Length + 1);
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.Phone);

            for(int i = 0; i < contactArray.Length; i++)
            {
                sw.WriteLine(contactArray[i].FirstName);
                sw.WriteLine(contactArray[i].LastName);
                sw.WriteLine(contactArray[i].Phone);
            }

            sw.Close();
        }

        private void Read() {
            StreamReader sr = new StreamReader("Contacts.txt");
            contactArray = new Contact[Convert.ToInt32(sr.ReadLine())];

            for (int i = 0; i < contactArray.Length; i++) { 
                contactArray[i] = new Contact();
                contactArray[i].FirstName = sr.ReadLine();
                contactArray[i].LastName = sr.ReadLine();
                contactArray[i].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        private void Display() {
            LstContacts.Items.Clear();

            for (int x = 0; x < contactArray.Length; x++) { 
                LstContacts.Items.Add(contactArray[x].ToString());
            }
        }

        private void ClearForm() { 
            txtFirstName.Text = String.Empty;
            TxtLastName.Text = String.Empty;
            TxtPhone.Text = String.Empty;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contact obj = new Contact();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = TxtLastName.Text;
            obj.Phone = TxtPhone.Text;

            Write(obj);
            Read();
            SortNames();
            Display();
            ClearForm();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }

        private void ListSort_Click(object sender, EventArgs e)
        {
            SortNames();
            Display();
        }

        private void SortNames() {
            Contact temp;
            bool swap;

            do
            {
                swap = false;
                for(int x = 0;x < (contactArray.Length - 1);x++)
                {
                    if ( contactArray[x].LastName.CompareTo(contactArray[x+1].LastName) > 0) { 
                        temp = contactArray[x];
                        contactArray[x] = contactArray[x + 1];
                        contactArray[x + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap == true);
        }
    }
}
