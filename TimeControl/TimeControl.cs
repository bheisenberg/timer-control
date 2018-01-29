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
    public partial class TimeControl : UserControl
    {
        private Timer timer;
        private int startingSeconds = 0;
        public int seconds
        {
            get
            {
                return GetSeconds();
            }
        }

        public delegate void TimerEnd();
        public event TimerEnd End;

        protected override void OnPaint(PaintEventArgs e) 
        {
            SolidBrush myBrush = new SolidBrush(Color.DodgerBlue);
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 60, TimeRatio(), 5));
            myBrush.Color = Color.Gray;
            myBrush.Dispose();
            formGraphics.Dispose();
        }


        private int GetSeconds()
        {
            return this.hoursBox.Value * 3600 + this.minutesBox.Value * 60 + this.secondsBox.Value;
        }

        public TimeControl()
        {
            InitializeComponent();
        }

        private int TimeRatio()
        {
            return (int)((float) (timer.Enabled ? seconds : 0) / (timer.Enabled ? startingSeconds : seconds > 0 ? seconds : 100) * 150f);
        }

        private void TimeControl_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Tick += Tick;
        }

        private void Tick(object sender, EventArgs e)
        {
            if (this.seconds > 0)
            {
                //UpdateRectangle();
                Invalidate();
                if (this.secondsBox.Value > 0)
                {
                    if (this.secondsBox.Value > 0)
                    {
                        this.secondsBox.Value -= 1;
                    }
                    else if(this.minutesBox.Value > 0)
                    {
                        this.minutesBox.Value -= 1;
                    }
                    else if(this.hoursBox.Value > 0)
                    {
                        this.hoursBox.Value -= 1;
                    }
                }
                else if(this.minutesBox.Value > 0)
                {
                    this.minutesBox.Value -= 1;
                    this.secondsBox.Value = 59;
                }
                else if(this.hoursBox.Value > 0)
                {
                    this.hoursBox.Value -= 1;
                    this.minutesBox.Value = 59;
                    this.secondsBox.Value = 59;
                }
            }
            else
            {
                End();
                timer.Stop();
                hoursBox.Enabled = true;
                minutesBox.Enabled = true;
                secondsBox.Enabled = true;
            }
        }

        public void Start()
        {
            this.startingSeconds = seconds;
            Console.WriteLine(seconds);
            timer.Interval = 500;
            timer.Start();
            hoursBox.Enabled = false;
            minutesBox.Enabled = false;
            secondsBox.Enabled = false;
        }
    }
}
