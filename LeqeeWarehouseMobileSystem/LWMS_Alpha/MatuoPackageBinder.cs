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
    public partial class MatuoPackageBinder : Form
    {
        public MatuoPackageBinder()
        {
            InitializeComponent();
        }

        private void resetBoxes()
        {
            this.tb_matuo.Text = "";
            this.tb_package.Text = "";
            this.tb_package.Enabled = false;
            this.lb_info.Text = "Scan Matuo Barcode...";
            this.listBox1.Items.Clear();
        }

        private void MatuoPackageBinder_Load(object sender, EventArgs e)
        {
            this.resetBoxes();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.resetBoxes();
        }

        private void tb_matuo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //Matuo comes

            }
        }


    }
}