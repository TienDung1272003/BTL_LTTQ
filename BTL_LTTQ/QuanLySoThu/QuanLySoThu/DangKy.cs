using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySoThu
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        DataBaseProcess database = new DataBaseProcess();
        private void picThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thoát không? ","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void picXemMatKhau_Click(object sender, EventArgs e)
        {
            if(picXemMatKhau.Image!=picXemMatKhau.ErrorImage)
            {
                Image tmp = picXemMatKhau.Image;
                picXemMatKhau.Image = picXemMatKhau.ErrorImage;
                picXemMatKhau.ErrorImage = tmp;
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

        private void picQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap dangnhap = new frmDangNhap();
            dangnhap.ShowDialog();
            this.Close();
        }
        private bool Check()
        {
            bool kt = true;
            string pattern = @"[^@]{2,64}@[^.]{2,253}\.[0-9a-z-.]{2,63}";
            string regusername = @"^[a-z0-9_-]{6,15}$";
            if (txtTaiKhoan.Text.ToString() == "")
            {
                lblTaiKhoan.Text = "Tên tài khoản không được bỏ trống!!";
                return false;
            }
            if(txtTaiKhoan.Text.ToString().Trim().Length <6 || txtTaiKhoan.Text.ToString().Trim().Length > 15) 
            {
                lblTaiKhoan.Text = "Tên tài khoản từ 6 đến 15 kí tự";
            }
            if(Regex.IsMatch(txtTaiKhoan.Text.ToString().Trim(),regusername)==false)
            {
                lblTaiKhoan.Text = "Tên tài khoản chỉ chứa chữ cái, số và kí tự '_'";
                return false;
            }
            database.OpenConnect();
            if(database.DataReader("select*from Taikhoan where username='" + txtTaiKhoan.Text.Trim() + "'").Rows.Count > 0)
            {
                lblTaiKhoan.Text = "Tên tài khoản đã tồn tại";
                database.CloseConnect();
                return false;
            }
            if (txtMatKhau.Text.ToString() == "")
            {
                lblMatKhau.Text = "Mật khẩu không được để trống!!";
                return false;
            }
            if (txtMatKhau.Text.ToString().Length < 8 || txtMatKhau.Text.ToString().Trim().Length > 15)
            {
                lblMatKhau.Text = "Mật khẩu phải chứa từ 8 đến 15 kí tự";
            }
            if (txtGmail.Text.ToString() == "")
            {
                lblGmail.Text = "Email không được để trống !!";
                return false;
            }
            if (Regex.IsMatch(txtGmail.Text.ToString().Trim(), pattern) == false)
            {
                lblGmail.Text = "Email phải đúng định dạng";
                return false;
            }
            return kt;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                database.OpenConnect();
                database.DataChanged("insert into Taikhoan values('" + txtTaiKhoan.Text.ToString().Trim() + "','" + txtMatKhau.Text.ToString().Trim() + "','" + txtGmail.Text.ToString().Trim() + "')");
                database.CloseConnect();
                MessageBox.Show("Bạn đã đăng ký tài khoản thành công!!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtGmail.Text = "";
            }
        }

        private void txtTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            lblTaiKhoan.Text= "";
        }

        private void txtMatKhau_MouseClick(object sender, MouseEventArgs e)
        { 
            lblMatKhau.Text="";
        }

        private void txtGmail_MouseClick(object sender, MouseEventArgs e)
        {
            lblGmail.Text = "";
        }
        private void Dangky_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTaiKhoan;
        }
    }
}
