namespace LWMS_Alpha
{
    partial class MatuoPackageBinder
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_matuo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_package = new System.Windows.Forms.TextBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.lb_info = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Reset";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.Text = "码托的条码";
            // 
            // tb_matuo
            // 
            this.tb_matuo.Location = new System.Drawing.Point(105, 32);
            this.tb_matuo.Name = "tb_matuo";
            this.tb_matuo.Size = new System.Drawing.Size(202, 23);
            this.tb_matuo.TabIndex = 1;
            this.tb_matuo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_matuo_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.Text = "包裹运单号";
            // 
            // tb_package
            // 
            this.tb_package.Location = new System.Drawing.Point(105, 68);
            this.tb_package.Name = "tb_package";
            this.tb_package.Size = new System.Drawing.Size(202, 23);
            this.tb_package.TabIndex = 3;
            this.tb_package.TextChanged += new System.EventHandler(this.tb_package_TextChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 251);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(318, 24);
            this.statusBar1.Text = "statusBar1";
            // 
            // lb_info
            // 
            this.lb_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_info.Location = new System.Drawing.Point(10, 104);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(297, 19);
            this.lb_info.Text = "label3";
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(10, 134);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(297, 114);
            this.listBox1.TabIndex = 7;
            // 
            // MatuoPackageBinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.tb_package);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_matuo);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "MatuoPackageBinder";
            this.Text = "码托包裹绑定";
            this.Load += new System.EventHandler(this.MatuoPackageBinder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_matuo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_package;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}