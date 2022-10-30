using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator_Example_WinForm
{
    public partial class Form1 : Form
    {
        ICalculate Calculate;

        public Form1()
        {
            InitializeComponent();
            Calculate = new Calculate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool ValidateInputs()
        {
            bool isValide = true;

            if (txtNumber1.Value == 0)
            {
                isValide = false;
                MessageBox.Show("Please Enter Number 1!!");
            }
            else
            {
                if(txtNumber2.Value == 0)
                {
                    isValide = false;
                    MessageBox.Show("Please Enter Number 2!!");
                }
            }

            return isValide;
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int sum = Calculate.Sum((int)txtNumber1.Value, (int)txtNumber2.Value);
                MessageBox.Show($"Sum Is: {sum}");
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int minus = Calculate.Minus((int)txtNumber1.Value, (int)txtNumber2.Value);
                MessageBox.Show($"Minus Is: {minus}");
            }
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int multiple = Calculate.Multiple((int)txtNumber1.Value, (int)txtNumber2.Value);
                MessageBox.Show($"Multipe Is: {multiple}");
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int divide = Calculate.Divide((int)txtNumber1.Value, (int)txtNumber2.Value);
                MessageBox.Show($"Divide Is: {divide}");
            }
        }
    }
}
