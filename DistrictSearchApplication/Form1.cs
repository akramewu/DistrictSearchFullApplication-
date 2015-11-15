using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistrictSearchApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> districts = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("districts.txt");
            var line = sr.ReadLine();
            while (line != null)
            {
                //add the line into the list
                districts.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            listBox1.DataSource = districts;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = textBox1.Text.ToUpper();
            List<string> result = new List<string>();
                result = (from d in districts
                    where d.ToUpper().Contains(query)
                    select d).ToList();

                //reload, re datasource to the listbox
                listBox1.DataSource = null;
                listBox1.DataSource = result;

                label1.Text = result.Count.ToString();
            }
        }
    }
}
