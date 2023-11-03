using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySoThu
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DataBaseProcess database = new DataBaseProcess();
        private void picThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void picXemMatKhau_Click(object sender, EventArgs e)
        {
            if (picXemMatKhau.Image != picXemMatKhau.ErrorImage)
            {
                Image tmp = picXemMatKhau.Image;
                picXemMatKhau.Image = picXemMatKhau.ErrorImage;
                picXemMatKhau.ErrorImage= tmp;
            }
            if (txtMatKhau.UseSystemPasswordChar == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
        private bool Check()
        {
            database.OpenConnect();
            bool kt = true;
            if (txtDangNhap.Text.Trim() == "")
            {
                lblTaiKhoan.Text = "Bạn chưa nhập tài khoản !!";
                return false;
            }
            else
            {
                lblTaiKhoan.Text = "";
            }
            if (txtMatKhau.Text.Trim()=="")
            {
                lblMatKhau.Text = "Bạn chưa nhập mật khẩu !!";
                return false;
            }
            else
            {
                lblMatKhau.Text = "";
            }
            if (kt)
            {
                foreach(DataRow row in database.DataReader("select * from Taikhoan where username='" + txtDangNhap.Text.Trim() + "'").Rows)
                {
                    if (row["pass"].ToString().Trim() == txtMatKhau.Text.Trim())
                    {
                        return true;
                    }
                }
                lblMatKhau.Text = "Tài khoản hoặc mật khẩu không đúng !!";
                return false;
            }
            return kt;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                this.Hide();
                frmTrangChu trangchu = new frmTrangChu();
                frmTrangChu.UserName = txtDangNhap.Text;
                trangchu.ShowDialog();
                this.Close();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangKy dangky = new frmDangKy();
            dangky.ShowDialog();
            this.Close();
        }

        private void lblQuenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLayLaiMK laylaimk = new frmLayLaiMK();
            laylaimk.ShowDialog();
            this.Close();
        }
    }
}
