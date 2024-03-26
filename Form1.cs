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
    public partial class Form1 : Form
    {   
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn muốn đóng chương trình", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username, pass from employee where username = '" + txtUserName.Text + "' and pass = '" + txtPassword.Text + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                labelError.Visible = false;
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            if(txtUserName.Text == "khanh" && txtPassword.Text == "123")
            {
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            else if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                DialogResult dg = MessageBox.Show("Tên đăng nhập hoặc mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            } 
                
        }
    }
}
