using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                lblHello.ForeColor = Color.Green;
                lblHello.Text = "Hello "+ txtName.Text;
            }
            else
            {
                lblHello.ForeColor = Color.Red;
                lblHello.Text = "Please Enter Your Name";
            }

            //MessageBox.Show("Hello " + txtName.Text);
        }
    }
}
