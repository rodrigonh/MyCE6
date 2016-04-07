namespace LWMS_Alpha
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.cb_facility = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageWork = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.tabPageWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.Text = "WMS";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "码托绑定包裹";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.Text = "Help";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "About";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUser);
            this.tabControl1.Controls.Add(this.tabPageWork);
            this.tabControl1.Location = new System.Drawing.Point(3, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 237);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.cb_facility);
            this.tabPageUser.Controls.Add(this.label3);
            this.tabPageUser.Controls.Add(this.btn_logout);
            this.tabPageUser.Controls.Add(this.btn_login);
            this.tabPageUser.Controls.Add(this.tb_password);
            this.tabPageUser.Controls.Add(this.tb_username);
            this.tabPageUser.Controls.Add(this.label2);
            this.tabPageUser.Controls.Add(this.label1);
            this.tabPageUser.Location = new System.Drawing.Point(4, 25);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Size = new System.Drawing.Size(304, 208);
            this.tabPageUser.Text = "身份";
            // 
            // cb_facility
            // 
            this.cb_facility.Location = new System.Drawing.Point(63, 7);
            this.cb_facility.Name = "cb_facility";
            this.cb_facility.Size = new System.Drawing.Size(227, 23);
            this.cb_facility.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.Text = "仓库：";
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(15, 168);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(275, 31);
            this.btn_logout.TabIndex = 5;
            this.btn_logout.Text = "登出";
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(15, 126);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(276, 29);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "登入";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(63, 84);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(229, 23);
            this.tb_password.TabIndex = 3;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(63, 47);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(229, 23);
            this.tb_username.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.Text = "用户：";
            // 
            // tabPageWork
            // 
            this.tabPageWork.Controls.Add(this.listBox1);
            this.tabPageWork.Location = new System.Drawing.Point(4, 25);
            this.tabPageWork.Name = "tabPageWork";
            this.tabPageWork.Size = new System.Drawing.Size(304, 208);
            this.tabPageWork.Text = "绑定";
            // 
            // listBox1
            // 
            this.listBox1.Items.Add("码托包裹绑定");
            this.listBox1.Location = new System.Drawing.Point(10, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 178);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Leqee WMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageUser.ResumeLayout(false);
            this.tabPageWork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageWork;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.ComboBox cb_facility;
        private System.Windows.Forms.Label label3;
    }
}

