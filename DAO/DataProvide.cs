using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DAO
{
    class DataProvide //Connect database
    {
        //Tao Singleton de quan ly du lieu toan cuc
        
        private static DataProvide instance;
        
        public static DataProvide Instance
        {
            get {  if (instance == null) instance = new DataProvide(); return DataProvide.instance; }
            private set { DataProvide.instance = value; }
        }
        private DataProvide() { }
        private string connectionST = @"Data Source=.\MAYCHUSQL;Initial Catalog=QL_QUANCAFE;User ID=sa;Password=quoc12345";
        public DataTable ExcuteQuery(string query, object[] parameter=null)
        {
            DataTable data = new DataTable();
            // Sử dụng using để đảm bảo khác vẫn chạy (Bằng cách giải phóng bộ nhớ) nếu khối lệnh này có lỗi
            using (SqlConnection connection = new SqlConnection(connectionST))
            { 

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
               if(parameter != null)
                {
                    string[] listparame = query.Split(' ');
                    int i = 0;
                    foreach(string item in listparame)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            // Sử dụng using để đảm bảo khác vẫn chạy (Bằng cách giải phóng bộ nhớ) nếu khối lệnh này có lỗi
            using (SqlConnection connection = new SqlConnection(connectionST))
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listparame = query.Split(' ');
                    int i = 0;
                    foreach (string item in listparame)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
            }
            return data;
        }
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            // Sử dụng using để đảm bảo khác vẫn chạy (Bằng cách giải phóng bộ nhớ) nếu khối lệnh này có lỗi
            using (SqlConnection connection = new SqlConnection(connectionST))
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listparame = query.Split(' ');
                    int i = 0;
                    foreach (string item in listparame)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
            }
            return data;
        }
    }

}
