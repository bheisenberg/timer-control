using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AutoClicker
{
    public partial class NumberBox : TextBox
    {
        private string defaultValue = "00";
        private string numberPattern = @"[0-9]";
        private int value;
        public int Value
        {
            get
            {
                return int.Parse(this.Text);
            }
            set
            {
                if (value < 10)
                {
                    this.Text = "0" + value;
                }
                else
                {
                    this.Text = ""+value;
                }
            }
        }

        public NumberBox()
        {
            InitializeComponent();
            this.Text = defaultValue;
            this.Enter += NumberBox_Enter;
            this.AcceptsReturn = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            /*nonNumberEntered = false;
            if (((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) && (e.KeyCode != Keys.Back) || Control.ModifierKeys == Keys.Shift) || (this.Text.Length >= 2 && e.KeyCode != Keys.Back && this.SelectionLength < 1 && e.KeyCode != Keys.Control))
            {
                nonNumberEntered = true;
            }*/
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((!Regex.IsMatch(e.KeyChar.ToString(), numberPattern) || Text.Length >= 2 && this.SelectionLength < 1) && !Char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Enter)
            {
                Console.WriteLine("HANDLED");
                e.Handled = true;
                if(e.KeyChar == (char)Keys.Enter)
                {
                    this.DeselectAll();
                }
            }
        }

        private void FormatText()
        {
            if(int.Parse(this.Text) < 10 && this.Text.Length == 1)
            {
                this.Text = "0" + this.Text;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            if (this.Text == "")
            {
                this.Text = this.defaultValue;
            } else
            {
                FormatText();
            }
        }


        private void NumberBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)this.SelectAll);
        }
    }
}
