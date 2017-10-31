#region

using System.Data.OleDb;

#endregion

namespace VenusBiller.Services
{
    public static class DatabaseManager
    {
        private const string ConnectionString =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ms2.msd;Jet OLEDB:Database Password=msk";

        public static OleDbConnection GetConnection()
        {
            var connection = new OleDbConnection(ConnectionString);
            return connection;
        }
    }
}