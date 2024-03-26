using DevExpress.XtraTab;
using Quanlikhachsan.All_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlikhachsan
{
    public partial class Dashboard : Form
    {
        UC_AddRoom room;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn muốn đóng chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRes1.Visible = false;
            uC_Checkout1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Employee1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        bool sidebarExpand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 68)
                {
                    sidebarExpand = false;
                    timer1.Stop();

                    button1.Width = sidebar.Width;
                    button2.Width = sidebar.Width;
                    button3.Width = sidebar.Width;
                    button4.Width = sidebar.Width;
                    button5.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 5;
                if(sidebar.Width >= 345)
                {
                    sidebarExpand = true;
                    timer1.Stop();

                    button1.Width = sidebar.Width + 14;
                    button2.Width = sidebar.Width + 14;
                    button3.Width = sidebar.Width + 14;
                    button4.Width = sidebar.Width + 14;
                    button5.Width = sidebar.Width + 14;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_CustomerRes1.Visible = true;
            uC_CustomerRes1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uC_Checkout1.Visible = true;
            uC_Checkout1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn muốn đóng chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
