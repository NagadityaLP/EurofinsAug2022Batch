using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Task t1 = new Task(() =>
            {
                Graphics red = panel1.CreateGraphics();
                Random random = new Random();
                for (int i = 1; i <= 1000; i++)
                {
                    int x = random.Next(panel1.Height);
                    int y = random.Next(panel1.Width);
                    red.DrawRectangle(Pens.Red, x, y, 20, 20);
                    Thread.Sleep(10);
                }
            });
            t1.Start();

            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                Graphics blue = panel2.CreateGraphics();
                Random random = new Random();
                for (int i = 1; i <= 1000; i++)
                {
                    int x = random.Next(panel2.Height);
                    int y = random.Next(panel2.Width);
                    blue.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    Thread.Sleep(10);
                }
            }).Start();
            
        }

    }
}
