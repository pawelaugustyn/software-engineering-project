using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ScrumIt.DataAccess
{
    internal class Connection : IDisposable
    {
        public NpgsqlConnection Conn { get; }
        public Connection()
        {
            Conn = new NpgsqlConnection("Server=horton.elephantsql.com;Username=jrjasstd;Password=tpE7WlP6Il9sJPpfTCxW0JRDNR5oegYH;Database=jrjasstd");
            Conn.Open();
        }

        public void Dispose()
        {
            Conn.Close();
        }
    }
}
