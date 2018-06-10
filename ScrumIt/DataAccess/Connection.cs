using System;
using Npgsql;

namespace ScrumIt.DataAccess
{
    internal class Connection : IDisposable
    {
        public static NpgsqlConnection Conn { get; } = new NpgsqlConnection("Server=mdm73ng82os.ckymfrn8filu.eu-central-1.rds.amazonaws.com;Username=master;Password=HL3&bF|H?7MQ!k~|PpJ,MD|p^EEm.vv!;Database=master");
        private static int _connCounter;
        private static bool _opened;
        public Connection()
        {
            if (!_opened && _connCounter <= 0)
            {
                try
                {
                    Conn.Open();
                    _opened = true;
                }
                catch (PostgresException error)
                {
                    if (error.SqlState == "53300")
                        throw new ArgumentException("Nie mozna polaczyc z baza danych.");
                }
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
