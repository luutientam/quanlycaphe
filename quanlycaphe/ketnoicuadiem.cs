using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlycaphe
{
    class ketnoicuadiem
        //su dung íntance-báed(doi tuong rieng)
    {
        //chuoi ket noi connection string dung de xac dinh thong tin ket noi den sql
        private static readonly string connectionString = @"Data Source=localhost;Initial Catalog=quanlycafe;Integrated Security=True";

        //bien la 1 doi tuong cua lop sqlConnection , dung de thiet lap va quan ly ket noi voi co so du lieiu
        private SqlConnection con;
        public ketnoicuadiem()
        {
            con = new SqlConnection(connectionString);
        }

        //tra ve doi tuong ket noi con
        public SqlConnection GetConnection()
        {
            return con;
        }

        //kiem tra trang thai ket noi
        public void Open()
        {
            con.Open();
        }
        public void Close()
        {
            con.Close();
        }
    }
}
