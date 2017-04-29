using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace WcfService
{
    public static class DataAcess
    {
        private static SqlConnection cnn;
        private static SqlDataAdapter adapter;
        private static DataSet tables;

        static DataAcess()
        {
            cnn = new SqlConnection("Data Source=DESKTOP-61U7JE6;Initial Catalog=Northwind;Integrated Security=True");
            tables = new DataSet();
            adapter = new SqlDataAdapter("select * from Customers", cnn);
            adapter.Fill(tables, "Cliente");
        }

        public static DataSet Set
        {
            get { return tables; }
        }

        public static DataAdapter Adapter
        {
            get{ return adapter; }
        }
        
    }
}