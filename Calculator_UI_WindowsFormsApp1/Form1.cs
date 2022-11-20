using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_UI_WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int res = CalculatorLibrary.Calculator.sum(a, b);

            MessageBox.Show($"Sum of {a} and {b} is {res}");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int res = CalculatorLibrary.Calculator.diff(a, b);

            MessageBox.Show($"Difference of {a} and {b} is {res}");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int res = CalculatorLibrary.Calculator.mul(a, b);

            MessageBox.Show($"Product of {a} and {b} is {res}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int res = CalculatorLibrary.Calculator.div(a, b);

            MessageBox.Show($"Quotient of {a} and {b} is {res}");
        }
    }
}
