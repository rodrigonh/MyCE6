using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.listBox1.Items.Add(e.KeyCode.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.listBox2.Items.Add(e.KeyChar.ToString());
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.listBox3.Items.Add(e.KeyCode.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
        }
    }
}