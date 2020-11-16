using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator en = new MMDeviceEnumerator();
            var devices = en.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox1.Items.AddRange(devices.ToArray());
            label1.Visible = false;

        }
        public int voice;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            label1.Visible = false;
            h1.Left = 1000;
            h2.Left = 1100;
            h3.Left = 1200;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                var selected = (MMDevice)comboBox1.SelectedItem;
                voice = (int)(selected.AudioMeterInformation.MasterPeakValue * 100 + 0.5);
                progressBar1.Value = voice;
            }
        }
        void movehurdle()
        {
            if(h1.Left>0)
            {
                h1.Left += -2;
            }
            else
            {
                h1.Left = 1000;
            }
            if (h2.Left > 0)
            {
                h2.Left += -2;
            }
            else
            {
                h2.Left = 1050;
            }
            if (h3.Left > 0)
            {
                h3.Left += -2;
            }
            else
            {
                h3.Left = 1075;
            } 
        }
         void gameOver()
        {
          if((h1.Bounds.IntersectsWith(supreme.Bounds)) || (h2.Bounds.IntersectsWith(supreme.Bounds)) || h3.Bounds.IntersectsWith(supreme.Bounds))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                label1.Visible = true;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(voice>25)
            {
                supreme.Top += -3;

            }
            else
            {
                if (supreme.Top < 465)
                    supreme.Top += 2;
                 
            }
            movehurdle();
            gameOver();

        }
    }
}
