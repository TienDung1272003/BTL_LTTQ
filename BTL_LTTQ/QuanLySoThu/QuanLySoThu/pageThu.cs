﻿using QuanLySoThu.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLySoThu
{
    public partial class pageThu : UserControl
    {
        DataBaseProcess data = new DataBaseProcess();
        Classes.Commomfunctions function = new Classes.Commomfunctions();
        public pageThu()
        {
            InitializeComponent();
        }
        private void FillDataToCombobox()
        {
            DataTable dataTable = new DataTable();
            //Fill dữ liệu từ DB vào combobox Mã Loài
            dataTable = data.DataReader("Select distinct TenLoai from Loai");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbbLoaiThu1.Items.Add(dataTable.Rows[i][0].ToString());
                cbbLoaiThu2.Items.Add(dataTable.Rows[i][0].ToString());
            }

            //Fill dữ liệu từ DB vào combobox Kiểu Sinh
            dataTable = data.DataReader("Select distinct TenKieuSinh from KieuSinh");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbbKieuSinh1.Items.Add(dataTable.Rows[i][0].ToString());
                cbbKieuSinh2.Items.Add(dataTable.Rows[i][0].ToString());
            }

            //Fill dữ liệu từ DB vào combobox Giới tính
            dataTable = data.DataReader("Select distinct GioiTinh from Thu");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbbGioiTinh.Items.Add(dataTable.Rows[i][0].ToString());

            }
            //Fill dữ liệu từ DB vào combobox Tên thú
            dataTable = data.DataReader("Select distinct TenThu from Thu");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbbTenThu.Items.Add(dataTable.Rows[i][0].ToString());

            }
            //Fill dữ liệu từ DB vào combobox NguonGoc
            dataTable = data.DataReader("Select distinct TenNguonGoc from NguonGoc");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbbNguonGoc1.Items.Add(dataTable.Rows[i][0].ToString());
                cbbNguonGoc2.Items.Add(dataTable.Rows[i][0].ToString());
            }
            //Fill dữ liệu từ DB vào combobox Chuong
            dataTable = data.DataReader("Select machuong from chuong");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbbChuong.Items.Add(dataTable.Rows[i][0].ToString());
            }
        }
        private void GetListAnimal()
        {
            //Hien thi danh sach thu len datagridview
            DataTable dataTable = new DataTable();
            dataTable = data.DataReader("select * from view_thu");
            dgvDanhSachThu.DataSource = dataTable;
        }
        private void LoadHeaderText()
        {
            dgvDanhSachThu.Columns[0].HeaderText = "Mã thú";
            dgvDanhSachThu.Columns[1].HeaderText = "Mã chuồng";
            dgvDanhSachThu.Columns[2].HeaderText = "Tên thú";
            dgvDanhSachThu.Columns[3].HeaderText = "Tên loài";
            dgvDanhSachThu.Columns[4].HeaderText = "Tên khoa học";
            dgvDanhSachThu.Columns[5].HeaderText = "Tên tiếng anh";
            dgvDanhSachThu.Columns[6].HeaderText = "Tên kiểu sinh";
            dgvDanhSachThu.Columns[7].HeaderText = "Tên nguồn gốc";
            dgvDanhSachThu.Columns[8].HeaderText = "Giới tính";
            dgvDanhSachThu.Columns[9].HeaderText = "Số lượng";
            dgvDanhSachThu.Columns[10].HeaderText = "Sách đỏ";
            dgvDanhSachThu.Columns[11].HeaderText = "Đặc điểm";
            dgvDanhSachThu.Columns[12].HeaderText = "Ngày vào";
            dgvDanhSachThu.Columns[13].HeaderText = "Ngày sinh";
            dgvDanhSachThu.Columns[14].HeaderText = "Tuổi thọ";
            dgvDanhSachThu.Columns[15].HeaderText = "Ảnh";

        }
        private void pageThu_Load(object sender, EventArgs e)
        {
            FillDataToCombobox();
            GetListAnimal();
            LoadHeaderText();
        }

        private void pageThu_Paint(object sender, PaintEventArgs e)
        {
            //GetListAnimal();
        }
        private void dgvDanhSachThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaThu.Text = dgvDanhSachThu.CurrentRow.Cells[0].Value.ToString();
            txtTenThu.Text = dgvDanhSachThu.CurrentRow.Cells[2].Value.ToString();
            //xu ly ma loai convert sang ten loai
            cbbLoaiThu1.Text = dgvDanhSachThu.CurrentRow.Cells[3].Value.ToString();

            txtSoLuong.Text = dgvDanhSachThu.CurrentRow.Cells[9].Value.ToString();

           // cbbChuong.Text = dgvDanhSachThu.CurrentRow.Cells[4].Value.ToString();

            txtTenKH.Text = dgvDanhSachThu.CurrentRow.Cells[4].Value.ToString();
            txtTenTA.Text = dgvDanhSachThu.CurrentRow.Cells[5].Value.ToString();
            cbbChuong.Text = dgvDanhSachThu.CurrentRow.Cells[1].Value.ToString();

            //xu ly ma kieu sinh convert sang ten kieu sinh
            cbbKieuSinh1.Text = dgvDanhSachThu.CurrentRow.Cells[6].Value.ToString();

            cbbGioiTinh.Text = dgvDanhSachThu.CurrentRow.Cells[8].Value.ToString();
            //Xu ly binding radio button
            if (dgvDanhSachThu.CurrentRow.Cells[10].Value.ToString().Equals("True"))
            {
                rdbCo.Checked = true;
                rdbKhong.Checked = false;
            }
            else
            {
                rdbCo.Checked = false;
                rdbKhong.Checked = true;
            }
            //Xu li binding to datetimepicker ngay vao
            dtpNgayVao.Text = Convert.ToDateTime(dgvDanhSachThu.CurrentRow.Cells[12].Value.ToString()).ToString();

            cbbNguonGoc1.Text = dgvDanhSachThu.CurrentRow.Cells[7].Value.ToString();
            txtDacDiem.Text = dgvDanhSachThu.CurrentRow.Cells[11].Value.ToString();
            //Xu li binding to datetimepicker ngay sinh
            dtpNgaySinh.Text = Convert.ToDateTime(dgvDanhSachThu.CurrentRow.Cells[13].Value.ToString()).ToString();

            txtTuoiTho.Text = dgvDanhSachThu.CurrentRow.Cells[14].Value.ToString();

            //binding picture
            string pictureURL = dgvDanhSachThu.CurrentRow.Cells[15].Value.ToString();
            ptbThu.ImageLocation = pictureURL;

            txtAnh.Text = pictureURL;
        }
        private bool ValidateDataNull_Thu()
        {
            try
            {
                if (txtMaThu.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải nhập mã thú"));
                    txtMaThu.Focus();
                    return false;
                }
                if (txtTenThu.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải nhập tên thú"));
                    txtTenThu.Focus();
                    return false;
                }
                if (cbbLoaiThu1.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải chọn loài thú"));
                    cbbLoaiThu1.Focus();
                    return false;
                }
                if (txtSoLuong.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải nhập số lượng thú"));
                    txtSoLuong.Focus();
                    return false;
                }
                if (cbbChuong.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải nhập số mã chuồng"));
                    cbbChuong.Focus();
                    return false;
                }
                if (cbbKieuSinh1.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải nhập kiểu sinh thú"));
                    cbbGioiTinh.Focus();
                    return false;
                }
                if (cbbNguonGoc1.Text.Equals(""))
                {
                    MessageBox.Show(("Bạn cần phải nhập nguồn gốc thú"));
                    cbbGioiTinh.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return true;
        }
        private bool ValidateDuplicateKey_Thu()
        {
            try
            {
                DataTable dataTable = data.DataReader("select MaThu from Thu where" + " MaThu='" + txtMaThu.Text + "'");
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Mã thú này đã tồn tại, bạn hãy nhập mã khác!");
                    txtMaThu.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
        private bool ValidateNotExistKey_Thu()
        {
            try
            {
                DataTable dataTable = data.DataReader("Select MaThu from Thu where" + " MaThu='" + txtMaThu.Text + "'");
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Mã thú này không tồn tại, bạn hãy nhập mã khác!");
                    txtMaThu.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
        private Thu GetThu()
        {
            Thu thu = new Thu();
            thu.MaThu = txtMaThu.Text;
            thu.TenThu = txtTenThu.Text;
            thu.MaLoai = data.DataReader("select MaLoai from Loai where TenLoai = N'"+cbbLoaiThu1.Text+"'").Rows[0][0].ToString();
            thu.SoLuong = int.Parse(txtSoLuong.Text);
            if (rdbCo.Checked)
            {
                thu.SachDo = 1;
            }
            else
            {
                thu.SachDo = 0;
            }
            thu.TenKH = txtTenKH.Text;
            thu.TenTA = txtTenTA.Text;
            thu.MaKS = data.DataReader("select MaKieuSinh from KieuSinh where TenKieuSinh = N'"+cbbKieuSinh1.Text+"'").Rows[0][0].ToString();
            thu.GioiTinh = cbbGioiTinh.Text;
            thu.NgayVao = Convert.ToDateTime(dtpNgayVao.Value.ToString());
            thu.MaNG = data.DataReader("Select MaNguonGoc from NguonGoc where TenNguonGoc = N'" + cbbNguonGoc1.Text + "' ").Rows[0][0].ToString();
            thu.DacDiem = txtDacDiem.Text;
            thu.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Value.ToString());
            thu.TuoiTho = int.Parse(txtTuoiTho.Text == "" ? "0" : txtTuoiTho.Text);
            thu.Anh = txtAnh.Text;
            return thu;
        }
        private void LoadMaThu()
        {
            string maxMT = data.DataReader("select max(MaThu) from Thu").Rows[0][0].ToString();
            int tmp = int.Parse(maxMT.Substring(2)) + 1;
            txtMaThu.Text = String.Concat("Th", tmp.ToString());
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDataNull_Thu() && ValidateDuplicateKey_Thu())
                {
                    
                    Thu t = new Thu();
                    t = GetThu();
                    string queryThu = "insert into Thu(mathu, TenThu, MaLoai, SoLuong, SachDo, TenKhoaHoc, TenTA, MaKieuSinh, " +
                           "GioiTinh, NgayVao, MaNguonGoc, DacDiem, NgaySinh, TuoiTho, Anh) " +
                           "values(N'" + t.MaThu + "', N'" + t.TenThu + "',N'" + t.MaLoai + "', '" + t.SoLuong + "','" + t.SachDo + "', " +
                           "N'" + t.TenKH + "',N'" + t.TenTA + "', N'" + t.MaKS + "',N'" + t.GioiTinh + "', '" + t.NgayVao + "',N'" + t.MaNG + "', " +
                           "N'" + t.DacDiem + "', '" + t.NgaySinh + "','" + t.TuoiTho + "', N'" + t.Anh + "')";
                    data.DataChanged(queryThu);

                    string queryToThu_Chuong = "insert into Thu_Chuong(machuong,mathu,ngayvao) " +
                           "values (N'" + cbbChuong.Text + "',N'" + t.MaThu + "',N'" + t.NgayVao + "')";
                    data.DataChanged(queryToThu_Chuong);
                    GetListAnimal();
                    LoadMaThu();
                    MessageBox.Show("Thêm mới thành công!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvDanhSachThu.CurrentRow.Cells[0].Value.ToString();
                if (ValidateDataNull_Thu() && ValidateNotExistKey_Thu() && MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes && !id.Equals(""))
                {

                    Thu t = new Thu();
                    t = GetThu();
                    // update Thu
                    string queryToThu = "update Thu " +
                        "set TenThu = N'" + t.TenThu + "'," +
                        "MaLoai = N'" + t.MaLoai + "'," +
                        "SoLuong = N'" + t.SoLuong + "'," +
                        "SachDo = N'" + t.SachDo + "'," +
                        "TenKhoaHoc = N'" + t.TenKH + "'," +
                        "TenTA = N'" + t.TenTA + "'," +
                        "MaKieuSinh = N'" + t.MaKS + "'," +
                        "GioiTinh = N'" + t.GioiTinh + "'," +
                        "NgayVao = N'" + t.NgayVao + "'," +
                        "MaNguonGoc = N'" + t.MaNG + "'," +
                        "DacDiem = N'" + t.DacDiem + "'," +
                        "NgaySinh = N'" + t.NgaySinh + "'," +
                        "TuoiTho = N'" + t.TuoiTho + "'," +
                        "Anh = N'" + t.Anh + "'" +
                        "where mathu = N'" + id + "'";
                    data.DataChanged(queryToThu);

                    GetListAnimal();
                    LoadMaThu();
                    MessageBox.Show("Sửa thông tin thành công!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string idThu = dgvDanhSachThu.CurrentRow.Cells[0].Value.ToString();
                if (ValidateNotExistKey_Thu() && MessageBox.Show("Ban co muon xóa khong ?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes && !idThu.Equals(""))
                {
                    string queryToThu = "delete from Thu where mathu = N'" + idThu + "'";
                    data.DataChanged(queryToThu);
                    GetListAnimal();
                    LoadMaThu();
                    MessageBox.Show("Xóa thông tin thành công!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            GetListAnimal();

            //Xóa bỏ selected
            cbbTenThu.SelectedIndex = -1;
            cbbLoaiThu2.SelectedIndex = -1;
            cbbKieuSinh2.SelectedIndex = -1;
            cbbNguonGoc2.SelectedIndex = -1;

            //xóa bỏ text
            cbbTenThu.Text = "";
            cbbLoaiThu2.Text = "";
            cbbKieuSinh2.Text = "";
            cbbNguonGoc2.Text = "";

            LoadMaThu();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string tenThu = cbbTenThu.Text;
                string loaiThu = cbbLoaiThu2.Text;
                string kieuSinh = cbbKieuSinh2.Text;
                string nguonGoc = cbbNguonGoc2.Text;
                string query = "exec Proc_Thu N'" + tenThu + "',N'" + loaiThu + "',N'" + kieuSinh + "',N'" + nguonGoc + "'";
                DataTable dataTable = new DataTable();
                dataTable = data.DataReader(query);
                dgvDanhSachThu.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có thông tin bạn đang tìm kiếm");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1]; //thao tác với worksheet trang đầu tiên
                                                                                 //Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1];
                exSheet.get_Range("B3:P4").Font.Bold = true;
                exSheet.get_Range("F3").Value = "Danh sách thú";
                exSheet.get_Range("A4").Value = "STT";
                exSheet.get_Range("B4").Value = "Mã thú";
                exSheet.get_Range("C4").Value = "Mã chuồng";
                exSheet.get_Range("D4").Value = "Tên thú";
                exSheet.get_Range("E4").Value = "Tên loài";
                exSheet.get_Range("F4").Value = "Tên khoa học";
                exSheet.get_Range("G4").Value = "Tên tiếng anh";
                exSheet.get_Range("H4").Value = "Tên kiểu sinh";
                exSheet.get_Range("I4").Value = "Tên nguồn gốc";
                exSheet.get_Range("J4").Value = "Giới tính";
                exSheet.get_Range("K4").Value = "Số lượng";
                exSheet.get_Range("L4").Value = "Sách đỏ";
                exSheet.get_Range("M4").Value = "Đặc điểm";
                exSheet.get_Range("N4").Value = "Ngày vào";
                exSheet.get_Range("O4").Value = "Ngày sinh";
                exSheet.get_Range("P4").Value = "Tuổi thọ";

                int n = dgvDanhSachThu.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[0].Value;
                    exSheet.get_Range("C" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[1].Value;
                    exSheet.get_Range("D" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[2].Value;
                    exSheet.get_Range("E" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[3].Value;
                    exSheet.get_Range("F" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[4].Value;
                    exSheet.get_Range("G" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[5].Value;
                    exSheet.get_Range("H" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[6].Value;
                    exSheet.get_Range("I" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[7].Value;
                    exSheet.get_Range("J" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[8].Value;
                    exSheet.get_Range("K" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[9].Value;
                    exSheet.get_Range("L" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[10].Value;
                    exSheet.get_Range("M" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[11].Value;
                    exSheet.get_Range("N" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[12].Value;
                    exSheet.get_Range("O" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[13].Value;
                    exSheet.get_Range("P" + (i + 5).ToString()).Value = dgvDanhSachThu.Rows[i].Cells[14].Value;
                }
                //auto fit columns
                foreach (Excel.Worksheet ws in exBook.Worksheets)
                {
                    Excel.Range range = ws.UsedRange;
                    range.Columns.AutoFit();
                }

                exBook.Activate();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xls|CSV Files|*.csv|All Files|*.*";
                saveFileDialog.ShowDialog();
                exBook.SaveAs(saveFileDialog.FileName.ToString());
                exApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
