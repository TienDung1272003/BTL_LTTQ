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
    public partial class frmTrangChu : Form
    {
        DataBaseProcess database = new DataBaseProcess();
        public frmTrangChu()
        {
            InitializeComponent();
        }
        private static string userName = "";
        public static string UserName { get => userName; set => userName = value; }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblUser.Text = UserName;
        }

        private void btnThu_Click(object sender, EventArgs e)
        {
            pnFooter.Visible = true;
            pnMain.Controls.Clear();

            pageThu pagethu = new pageThu();
            pagethu.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pagethu);

            //lblTongBanGhi.Text = GetNumberOfRecords("select count(mathu) from thu");
        }

        private void btnNhanSu_Click(object sender, EventArgs e)
        {
            pnFooter.Visible = true;
            pnMain.Controls.Clear();

            pageNhanSu pagens = new pageNhanSu();
            pagens.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pagens);
        }

        private void btnChuong_Click(object sender, EventArgs e)
        {
            pnFooter.Visible = true;
            pnMain.Controls.Clear();

            pageChuong pagechuong = new pageChuong();
            pagechuong.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pagechuong);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            pnFooter.Visible = true;
            pnMain.Controls.Clear();

            pageBaoCao pagebc = new pageBaoCao();
            pagebc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pagebc);
        }

        private void btnNhapLieu_Click(object sender, EventArgs e)
        {
            pnFooter.Visible = true;
            pnMain.Controls.Clear();

            pageNhapLieu pagenl = new pageNhapLieu();
            pagenl.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pagenl);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pnFooter.Visible = false;
            pnMain.Controls.Clear();

            pageTrangChu pagetc = new pageTrangChu();
            pagetc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pagetc);
            pnMain.Controls.Add(pnHeader);
        }
    }
}
