using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.timeControl1.End += Test;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timeControl1.Start();
        }

        private void Test()
        {
            Console.WriteLine("FUCK YA");
        }
    }
}
