using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Threading;

namespace SmartDeviceProject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.label1.Text = this.textBox1.Text;
                try
                {
                    EasyNeter en = new EasyNeter();
                    Dictionary<String, String> p = new Dictionary<String, String>();
                    p.Add("key", this.textBox1.Text);
                    HttpWebResponse res = en.postHttp("http://www.everstray.com/include/io_debug.php", p, 30000, null, Encoding.UTF8);
                    StreamReader sr = new StreamReader(res.GetResponseStream());
                    String content = sr.ReadToEnd();
                    this.label1.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message, "Vain");
                }
            }
        }
    }
}