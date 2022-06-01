using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Medical.Common.Helpers
{
    public class Database : IDisposable
    {
        readonly SqlConnection _conn;

        public Database(string conn)
        {
            _conn = new SqlConnection(conn);
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(SqlCommand cmd)
        {
            SqlDataReader result;

            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }

            using (cmd)
            {
                cmd.CommandTimeout = 0;
                cmd.Connection = _conn;
                result = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            return result;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
                _conn.Dispose();
            }
        }
    }
}
