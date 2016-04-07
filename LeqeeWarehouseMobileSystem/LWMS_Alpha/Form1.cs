using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LWMS_Alpha
{

    public partial class Form1 : Form
    {
        public List<String> funcList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (UserSessionAgent.token == null)
            {
                this.tb_username.Text = "";
                this.tb_password.Text = "";
                this.tb_username.Enabled = true;
                this.tb_password.Enabled = true;
                this.btn_login.Enabled = true;
                this.btn_logout.Enabled = false;
            }
            else
            {
                this.tb_username.Text = UserSessionAgent.username;
                this.tb_username.Enabled = false;
                this.tb_password.Enabled = false;
                this.btn_login.Enabled = false;
                this.btn_logout.Enabled = true;
            }

            this.dataInit();
        }

        private void dataInit()
        {
            //初始化仓库
            Dictionary<string, API.APIRE_PhysicalWarehouse> dict = API.APIWorker.getFacilityList();
            if (dict != null && dict.Keys.Count > 0)
            {
                foreach (String key in dict.Keys)
                {
                    this.cb_facility.Items.Add(dict[key]);
                }
                this.cb_facility.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("仓库列表获取不正常。", "初始化失败");
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("人类是多么的虚无。");
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            MatuoPackageBinder MPB = new MatuoPackageBinder();
            MPB.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            switch (lb.SelectedIndex)
            {
                case 0:
                    MatuoPackageBinder MPB = new MatuoPackageBinder();
                    MPB.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(UserSessionAgent.machineCode(), "MAC");
            String info = "";

            API.APIRE_PhysicalWarehouse pw=(API.APIRE_PhysicalWarehouse)this.cb_facility.SelectedItem;

            Boolean done=UserSessionAgent.login(pw.physical_warehouse_id,this.tb_username.Text, this.tb_password.Text, out info);
            if (done)
            {
                this.tb_username.Enabled = false;
                this.tb_password.Enabled = false;
                this.btn_login.Enabled = false;
                this.cb_facility.Enabled = false;
                this.btn_logout.Enabled = true;
            }
            else
            {
                MessageBox.Show("人类真是虚无，登录不能啊。参考："+info, "登录");
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Boolean outed=UserSessionAgent.logout();
            if (outed)
            {
                this.tb_username.Text = "";
                this.tb_password.Text = "";
                this.tb_username.Enabled = true;
                this.tb_password.Enabled = true;
                this.btn_login.Enabled = true;
                this.cb_facility.Enabled = true;
                this.btn_logout.Enabled = false;
            }
        }

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc=(TabControl)sender;
            if (UserSessionAgent.token == null && tc.SelectedIndex != 0)
            {
                MessageBox.Show("少年你还没登录呢。", "登录");
                tc.SelectedIndex = 0;
            }
        }

    }
}