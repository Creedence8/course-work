using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editor
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Vlad\Desktop\1.txt");
         
            
        }
    }
}
