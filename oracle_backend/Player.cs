using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace oracle_backend
{
    class Player
    {
        public string Nickname { get; }
        public string Region { get; }
        public string Club { get; }
        public DataTable ResultTable { get; private set; }


        public Player()
        {
            SetMainData();
        }

        //constructor method, that creates the results table
        public void CreateTable()
        {
            ResultTable = new DataTable("ResultTable");

            DataColumn column = new DataColumn();
            column.ColumnName = "type";
            column.ReadOnly = true;
            column.Unique = true;

            ResultTable.Columns.Add(column);

            string[] column_names = new string[] { "percents", "extra_points", "total_points" };

            foreach (var item in column_names)
            {
                column = new DataColumn();
                column.ColumnName = item;
                column.ReadOnly = true;
                ResultTable.Columns.Add(column);
            }

            string[] rows_name = new string[] { "Civilian", "sheriff", "mafia", "don", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "total" };

            foreach (var item in rows_name)
            {
                DataRow row = ResultTable.NewRow();
                row["type"] = item;
                ResultTable.Rows.Add(row);
            }
        }

        //constructor method, that Select and get datas by using class DBconnect
        public void SetMainData()
        {

        }
    }
}
