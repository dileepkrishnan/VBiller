#region

using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using VenusBiller.Entities;

#endregion

namespace VenusBiller.Services.Dao
{
    public static class PartyDao
    {
        public static List<Party> GetManyByName(string name)
        {
            var query = "SELECT ACCODE, ACHEAD, ACADDRESS1 FROM ACHEADS, GSTIN WHERE ACHEAD LIKE '" + name + "'";
            var parties = RunQueryAndGetResults(query);
            return parties;
        }

        public static List<Party> GetAll()
        {
            const string query = "SELECT ACCODE, ACHEAD, ACADDRESS1, GSTIN FROM ACHEADS";
            var parties = RunQueryAndGetResults(query);
            return parties;
        }

        public static Party GetOneByCode(string code)
        {
            var query = "SELECT ACCODE, ACHEAD, ACADDRESS1, GSTIN FROM ACHEADS WHERE ACCODE = '" + code + "'";
            var parties = RunQueryAndGetResults(query);
            return parties.Any() ? parties[0] : new NullParty();
        }

        private static List<Party> RunQueryAndGetResults(string query)
        {
            var parties = new List<Party>();
            using (var connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                var command = new OleDbCommand(query, connection);
                var reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var party = new Party
                        {
                            Code = reader.GetString(0), // ACCODE
                            Name = reader.GetString(1), // ACHEAD
                            Address = reader.GetString(2), // ACADDRESS1
                            GstIn = reader.GetString(3) //GSTIN
                        };
                        parties.Add(party);
                    }
                }
            }
            return parties;
        }
    }
}