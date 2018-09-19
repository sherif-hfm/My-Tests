using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFileTableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddFile();
            ReadFile();
        }

        private static void AddFile()
        {
            using (SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=FileTableTestDb;Integrated Security=True"))
            {
                string sql = "insert into FileTable1 (stream_id, name,file_stream) values(@stream_id, @name,@file_stream)";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (var fs = File.Open(@"D:\Att2.png", FileMode.Open))
                    {
                        var id = Guid.NewGuid();
                        cmd.Parameters.Add("@stream_id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = @"Att2.png";
                        cmd.Parameters.Add("@file_stream", SqlDbType.VarBinary).Value = fs;
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
            }
        }

        private static void ReadFile()
        {
            using (SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=FileTableTestDb;Integrated Security=True"))
            {
                string sql = "Select * from FileTable1 where stream_id='7729A829-4DAB-4150-A48B-309B26A354B2'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    var rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        var fileData = rdr["file_stream"];
                        File.WriteAllBytes(@"d:\Att1-2.png", (byte[])fileData);
                    }
                    cnn.Close();
                }
            }
        }
    }
}
