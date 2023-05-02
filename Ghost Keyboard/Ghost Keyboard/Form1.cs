using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ghost_Keyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] keyss(string s)
        {
            string[] splitt = s.Split("\n");
            return splitt;
        }

        private void Start()
        {
            string[] sk = keyss(richTextBox1.Text);
            int iterations = 0;
            foreach (string nn in sk)
            {
                iterations += 1;
                foreach (char t in nn)
                {
                    string x = ""+t;
                    if (t == '(' || t == '{' || t == ')' || t == '}' || t == '+' || t == '^' || t == '%' || t == '~')
                    {
                        x = "{" + x + "}";
                    }
                    SendKeys.Send(x);
                }
                if (iterations != sk.Length)
                {
                    SendKeys.Send("{Enter}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string t = label2.Text;
            label2.Text = (Convert.ToInt32(t) - 1).ToString();
            if (label2.Text == "0")
            {
                Start();
                timer2.Stop();
            }
        }
    }
}
