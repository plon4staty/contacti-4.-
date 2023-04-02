using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomogite_3
{
    public class DBconnect
    {

            static private string Connections = @"Data Source=DESKTOP-F5IFSAN\SQLEXPRESS;Initial Catalog=kontact;Integrated Security=True";
            public SqlConnection connection = new SqlConnection(Connections);

            public void ConOpen()
            {

                if (connection.State == System.Data.ConnectionState.Closed)
                {

                    connection.Open();

                }

            }

            public void ConClosed()
            {

                if (connection.State == System.Data.ConnectionState.Open)
                {

                    connection.Close();

                }

            }

            public SqlConnection GetConnection()
            {

                return connection;

            }
    }

}
