using System;
using Npgsql;

namespace ScrumIt.DataAccess
{
    internal class Connection : IDisposable
    {
        public static NpgsqlConnection Conn { get; } = new NpgsqlConnection("Server=horton.elephantsql.com;Username=jrjasstd;Password=tpE7WlP6Il9sJPpfTCxW0JRDNR5oegYH;Database=jrjasstd");
        private static int _connCounter;
        private static bool _opened;
        public Connection()
        {
            if (!_opened && _connCounter <= 0)
            {
                Conn.Open();
                _opened = true;
            }
            _connCounter++;
        }

        public void Dispose()
        {
            _connCounter--;
            if (_connCounter <= 0)
            {
                Conn.Close();
                _opened = false;
                _connCounter = 0;
            }
        }
    }
}
