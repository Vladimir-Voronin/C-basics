using System;
using System.Text;
using Npgsql;

namespace Postgresql
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=postgres;Password=123;Database=fiim";

            var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT * FROM participants";

            var cmd = new NpgsqlCommand(sql, con);

            Encoding utf8 = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            var data = cmd.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine(data.GetValue(0).ToString() + " " + data.GetValue(1).ToString() + " " + data.GetValue(2).ToString() + " " + data.GetValue(3).ToString()); 
            }
        }
    }
}
