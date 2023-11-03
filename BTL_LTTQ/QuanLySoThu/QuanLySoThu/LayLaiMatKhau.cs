using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySoThu
{
    public partial class frmLayLaiMK : Form
    {
        DataBaseProcess database = new DataBaseProcess();
        public frmLayLaiMK()
        {
            InitializeComponent();
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void picQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap t = new frmDangNhap();
            t.ShowDialog();
            this.Close();
        }

        private void frmLayLaiMK_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtMatKhau;
        }
        private void btnLayLaiMK_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.ToString().Trim()=="")
            {
                lblTaiKhoan.Text = "Tên tài khoản không được để trống !";
            }
            else if (txtMatKhau.Text.ToString().Trim()=="")
            {
                lblGmail.Text = "Gmail không được để trống !";
            }
            else
            {
                database.OpenConnect();
                if (database.DataReader("select * from Taikhoan where username ='" + txtTaiKhoan.Text.ToString().Trim() + "' and email = '" + txtMatKhau.Text.ToString().Trim() + "'").Rows.Count == 0)
                {
                    lblTaiKhoan.Text = "Tài khoản không tồn tại !!";
                }
                else
                {
                    foreach (DataRow row in database.DataReader("select * from Taikhoan where username ='" + txtTaiKhoan.Text.ToString().Trim() + "' and email = '" + txtMatKhau.Text.ToString().Trim() + "'").Rows)
                    {
                        lblThongBaoMK.Text = "Mật khẩu của bạn là :" + row["pass"].ToString();
                    }
                }
            }
        }
    }
}
