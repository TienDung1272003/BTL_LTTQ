using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySoThu
{
    class DataBaseProcess
    {
        string strConnect = "Data Source = LAPTOP-PU7VEUUB\\TIENDUNG;" +
            "DataBase=QLVuonThu;User ID=sa;" +
            "Password=dung1272003;Integrated Security=false";
        SqlConnection sqlConnect = null;
        //Mở kết nối
        public void OpenConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if(sqlConnect.State!=ConnectionState.Open)
                sqlConnect.Open();
        }
        //Đóng kết nối
        public void CloseConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        //Thực hiện select trả về 1 DataTable
        public DataTable DataReader(string sqlSelect)
        {
            try
            {
                DataTable tblData = new DataTable();
                OpenConnect();
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConnect);
                sqlData.Fill(tblData);
                tblData.Dispose();
                return tblData;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);
            }
            finally
            {
                CloseConnect();
            }
            return null;
        }
        //Thực hiện các câu lệnh insert,update,delete
        public void DataChanged(string sql)
        {
            try
            {
                OpenConnect();
                SqlCommand sqlcomma = new SqlCommand(sql,sqlConnect);
                sqlcomma.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { 
                CloseConnect();
            }
        }
        public void TryInsertInto()
        {
            OpenConnect();

        }
    }
}
