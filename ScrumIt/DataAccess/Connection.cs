using System;
using Npgsql;

namespace ScrumIt.DataAccess
{
    internal class Connection : IDisposable
    {
        public static NpgsqlConnection Conn { get; } = new NpgsqlConnection("Server=mdm73ng82os.ckymfrn8filu.eu-central-1.rds.amazonaws.com;Username=master;Password=HL3&bF|H?7MQ!k~|PpJ,MD|p^EEm.vv!;Database=master");
        public NpgsqlConnection ConnExcl { get; } = new NpgsqlConnection("Server=mdm73ng82os.ckymfrn8filu.eu-central-1.rds.amazonaws.com;Username=master;Password=HL3&bF|H?7MQ!k~|PpJ,MD|p^EEm.vv!;Database=master");
        private static int _connCounter;
        private static bool _opened;
        private bool _exclusive = false;

        public Connection(bool exclusive=false)
        {
            if (!exclusive)
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
            else
            {
                ConnExcl.Open();
                _exclusive = true;
            }

        }

        public void Dispose()
        {
            if (!_exclusive)
            {
                _connCounter--;
                if (_connCounter <= 0)
                {
                    Conn.Close();
                    _opened = false;
                    _connCounter = 0;
                }
            }
            else
            {
                ConnExcl.Close();
            }
        }
    }
}
