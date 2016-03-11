using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        private HttpWebResponse sharedResponse;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("观测到输入的文本是：" + this.textBox1.Text);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "作为一只大鲵，必须要邪恶。";
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            string userName = "userName";
            string tagUrl = "https://freedom.everstray.com/";
            EasyNeter easy_neter = new EasyNeter();
            //CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = easy_neter.getHttp(tagUrl);//.CreateGetHttpResponse(tagUrl, null, null, cookies);
            this.textBox1.Text = "Http Status Code = " + response.StatusCode;
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            this.label2.Text = content;
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            string tagUrl = "http://sinri.tk/StringLDJudge";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("str1", "apple");
            parameters.Add("str2", "pear");
            EasyNeter easy_neter = new EasyNeter();
            HttpWebResponse response = easy_neter.postHttp(tagUrl, parameters, 30, null, Encoding.UTF8);
            this.textBox1.Text = "Http Status Code = " + response.StatusCode;
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            this.label2.Text = content;
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            string tagUrl = "https://freedom.everstray.com/";

            Dictionary<string, object> state = new Dictionary<string, object>();
            state.Add("target", this);
            state.Add("url", tagUrl);

            bool async_gone = EasyAsync.register(new WaitCallback(Form1.callback_1), state);
            this.textBox1.Text = (async_gone ? "Async Begins..." : "Async failed to begin!");
        }

        private static void callback_1(object state)
        {
            try
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)state;
                EasyNeter easy_neter = new EasyNeter();
                object oform;
                object ourl;
                dict.TryGetValue("target", out oform);
                dict.TryGetValue("url", out ourl);
                Form1 form = (Form1)oform;
                string url = (string)ourl;

                HttpWebResponse response = easy_neter.getHttp(url);
                form.sharedResponse = response;
                /*
                form.statusBar1.Text = "URL: " + url;
                HttpWebResponse response = easy_neter.getHttp(url);//.CreateGetHttpResponse(tagUrl, null, null, cookies);
                form.textBox1.Text = "Http Status Code = " + response.StatusCode;
                StreamReader sr = new StreamReader(response.GetResponseStream());
                String content = sr.ReadToEnd();
                form.label2.Text = content;
                */

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.StackTrace.ToString());
            }
        }

        // 声明一个委托 
        private delegate void NewDel();

        private void menuItem8_Click(object sender, EventArgs e)
        {
            Kaishi();
        }

        // 创建一个 新线程的方法
        public void Kaishi()
        {
            Thread thread;
            ThreadStart threadstart = new ThreadStart(start);
            thread = new Thread(threadstart);
            thread.Start();
        }

        // 屏蔽错误的方法   说白了 就是通过了一个 委托  
        // 解决Control.Invoke 必须用于与在独立线程上创建的控件交互。
        private void start()
        {
            if (InvokeRequired)
            {
                // 要 努力 工作的 方法
                BeginInvoke(new NewDel(GetMac));
            }
        }
        // 实质工作的 方法体
        private void GetMac()
        {
            string userName = "userName";
            string tagUrl = "https://freedom.everstray.com/";
            EasyNeter easy_neter = new EasyNeter();
            HttpWebResponse response = easy_neter.getHttp(tagUrl);
            this.textBox1.Text = "Http Status Code = " + response.StatusCode;
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            this.label2.Text = content;
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            

            string json = @"{
                   'd': [
                     {
                       'Name': 'John Smith'
                     },
                     {
                       'Name': 'Mike Smith'
                     }
                  ]
                }";

            JObject o = JObject.Parse(json);

            this.label2.Text += o["d"].ToString();
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            List<string> videogames = new List<string> { "Starcraft", "Halo", "Legend of Zelda" };
            string json = JsonConvert.SerializeObject(videogames);
            this.label2.Text += (json);

            Dictionary<string, int> points = new Dictionary<string, int>{
                { "James", 9001 },
                { "Jo", 3474 },
                { "Jess", 11926 }
            };

            json = JsonConvert.SerializeObject(points, Formatting.Indented);

            this.label2.Text += (json);

            JArray array = new JArray();
            array.Add("Manual text");
            array.Add(new DateTime(2000, 5, 23));

            JObject o = new JObject();
            o["MyArray"] = array;

            json = o.ToString();
            this.label2.Text += (json);
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}