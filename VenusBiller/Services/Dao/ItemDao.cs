#region

using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using VenusBiller.Entities;

#endregion

namespace VenusBiller.Services.Dao
{
    public static class ItemDao
    {
        public static List<Item> GetAll()
        {
            const string query = "SELECT ITEMCODE, ITEMNAME, UNIT, CLOSING, RPRICE, WPRICE, LC, TAXPER, CESSPER, SUPPLIERCODE, TAXCATEGORY FROM STOCK ORDER BY ITEMNAME";
            var items = RunQueryAndGetResults(query);
            return items;
        }

        public static Item GetOneByCode(string code)
        {
            var query =
                "SELECT ITEMCODE, ITEMNAME, UNIT, CLOSING, RPRICE, WPRICE, LC, TAXPER, CESSPER, SUPPLIERCODE, TAXCATEGORY FROM STOCK WHERE ITEMCODE='" +
                code + "'";
            var items = RunQueryAndGetResults(query);
            return items.Any() ? items[0] : null;
        }

        private static List<Item> RunQueryAndGetResults(string query)
        {
            var items = new List<Item>();
            using (var connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                var command = new OleDbCommand(query, connection);
                var reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        double maximumRetailPrice;
                        double dealerPrice;
                        int closingStock;
                        double taxPercent;
                        double cessPercent;
                        var item = new Item
                        {
                            Code = reader.GetString(0), // ITEMCODE
                            Name = reader.GetString(1), // ITEMNAME
                            Unit = reader.GetString(2), // ACADDRESS1
                            ClosingStock = int.TryParse(reader.GetString(3), out closingStock) ? closingStock : 0, // CLOSING
                            MaximumRetailPrice = double.TryParse(reader.GetString(4), out maximumRetailPrice) ? maximumRetailPrice : 0.0, // RPRICE
                            DealerPrice = double.TryParse(reader.GetString(5), out dealerPrice) ? dealerPrice : 0.0, // WPRICE
                            LandingCost = double.TryParse(reader.GetString(6), out dealerPrice) ? dealerPrice : 0.0, // LC
                            Tax = double.TryParse(reader.GetString(7), out taxPercent) ? taxPercent : 0.0, // TAXPER
                            Cess = double.TryParse(reader.GetString(8), out cessPercent) ? cessPercent : 0.0, // CESSPER
                            SupplierCode = reader.GetString(9), //SUPPLIERCODE
                            HsnOrSac = reader.GetString(10) //TAXCATEGORY
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}