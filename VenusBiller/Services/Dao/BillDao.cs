#region

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using VenusBiller.Entities;
using VenusBiller.Reports;
using VenusBiller.Reports.Entities;

#endregion

namespace VenusBiller.Services.Dao
{
    public static class BillDao
    {
        private const string SaveItemsQuery =
            @"INSERT INTO SITEM (BILLNO, BILLDATE, CUSTOMERCODE, ITEMCODE, ITEMNAME, UNIT, QTY, RATE, DISCPER, DISCOUNT, SPLDISCPER, SPLDISCOUNT, TAXPER, TAXAMT, NETAMT, LC, SALESCODE, SLNO, TAXCODE, SUPPLIERCODE, TAXCATEGORY, CESSPER, CESSAMT, MRP, HSNORSAC, SALESTYPE, GSTIN)
VALUES(@BILLNO, @BILLDATE, @CUSTOMERCODE, @ITEMCODE, @ITEMNAME, @UNIT, @QTY, @RATE, @DISCPER,  @DISCOUNT, @SPLDISCPER, @SPLDISCOUNT, @TAXPER, @TAXAMT, @NETAMT, @LC, @SALESCODE, @SLNO, @TAXCODE, @SUPPLIERCODE, @TAXCATEGORY, @CESSPER, @CESSAMT, @MRP, @HSNORSAC, @SALESTYPE, @GSTIN)";

        private const string SaveBillQuery =
            @"INSERT INTO SALES (BILLNO, BILLDATE, BILLTYPE, CUSTOMERCODE, CUSTOMERNAME, CUSTOMERADDRESS, TOTALAMT1, DISCOUNTAMT, TOTAL2, SPLDISCPER, SPLDISCOUNTAMT, TOTAL3, TAXAMT, ASTPER, ASTAMT, TOTAL4, HANDLINGCH, GTOTAL, ROUNDEDOF, BILLAMT, BILLTIME, USERID, TOTALCESSAMT, BALANCE,PFT, PAYMENTTYPE, SALESTYPE, GSTIN)
VALUES(@BILLNO, @BILLDATE, @BILLTYPE, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERADDRESS, @TOTALAMT1, @DISCOUNTAMT, @TOTAL2, @SPLDISCPER, @SPLDISCOUNTAMT, @TOTAL3, @TAXAMT, @ASTPER, @ASTAMT, @TOTAL4, @HANDLINGCH, @GTOTAL, @ROUNDEDOF, @BILLAMT, @BILLTIME, @USERID, @TOTALCESSAMT, @BALANCE, @PFT, @PAYMENTTYPE, @SALESTYPE, @GSTIN)";

        private const string GetClosingStockQuery = @"SELECT CLOSING FROM STOCK WHERE ITEMCODE = @ITEMCODE";
        private const string UpdateClosingStockQuery = @"UPDATE STOCK SET CLOSING = ? WHERE ITEMCODE = ?";

        private const string GetLastBillNumberQuery =
            "SELECT MAX(BILLNO) FROM SALES WHERE BILLDATE IN (SELECT MAX(BILLDATE) FROM SALES)";

        private const string LoadBillQuery =
            @"SELECT BILLNO, BILLDATE, CUSTOMERCODE, CUSTOMERNAME, CUSTOMERADDRESS, SPLDISCPER, SPLDISCOUNTAMT, ROUNDEDOF, BILLAMT, PFT, SALESTYPE, GSTIN FROM SALES WHERE BILLNO = ? ";

        private const string LoadItemQuery =
            @"SELECT ITEMCODE, ITEMNAME, QTY, DISCPER, TAXPER, NETAMT, LC, SLNO, SUPPLIERCODE, CESSPER, MRP, HSNORSAC FROM SITEM WHERE BILLNO = ?";

        private const string DeleteBillQuery = @"DELETE FROM SALES WHERE BILLNO = ?";

        private const string DeleteItemsQuery = @"DELETE FROM SITEM WHERE BILLNO = ?";

        public static void Save(Bill bill)
        {
            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                SaveItems(bill, connection);
                SaveBill(bill, connection);
                UpdateClosingStock(bill, connection);
            }
        }

        public static Bill Load(int billNumber)
        {
            Bill bill = null;

            #region Bill

            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = LoadBillQuery;
                    cmd.Parameters.Add("@p1", billNumber);
                    var reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            bill = new Bill();
                            bill.BillNumnber = reader.GetString(0); //BILLNO
                            bill.BillDate = DateTime.ParseExact(reader.GetString(1), "yyyyMMdd", null); //BILLDATE
                            bill.PartyCode = reader.GetString(2); // CUSTOMER CODE
                            bill.PartyName = reader.GetString(3); // CUSTOMER NAME
                            bill.PartyAddress = reader.GetString(4); // CUSTOMER ADDRESS
                            bill.SpecialDiscountPercent = SafelyParseDoubleFromString(reader.GetString(5)); // SPLDISCPER
                            bill.SpecialDiscountAmount = SafelyParseDoubleFromString(reader.GetString(6));  // SPLDISCOUNTAMT
                            bill.RoundOffAmount = SafelyParseDoubleFromString(reader.GetString(7)); // ROUNDEDOF
                            bill.FinalBillAmount = SafelyParseDoubleFromString(reader.GetString(8)); // BILLAMT
                            bill.Profit = SafelyParseDoubleFromString(reader.GetString(9)); // PFT
                            bill.SalesType = SalesTypeExtension.StringToEnum(reader.GetString(10));
                            bill.PartyGstIn = reader.GetString(11);
                        }
                    }
                }

            }

            #endregion Bill

            #region Items

            if (bill != null)
            {
                using (OleDbConnection connection = DatabaseManager.GetConnection())
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = LoadItemQuery;
                        cmd.Parameters.Add("@p1", billNumber);
                        var reader = cmd.ExecuteReader();
                        bill.Items = new List<BillItem>();
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var billItem = new BillItem();
                                billItem.Code = reader.GetString(0);
                                billItem.Name = reader.GetString(1);
                                billItem.Quantity = int.Parse(reader.GetString(2));
                                billItem.DiscountPercent = SafelyParseDoubleFromString(reader.GetString(3));
                                billItem.GstPercent = SafelyParseDoubleFromString(reader.GetString(4));
                                billItem.NetAmount = SafelyParseDoubleFromString(reader.GetString(5));
                                billItem.LandingCost = SafelyParseDoubleFromString(reader.GetString(6));
                                billItem.ItemNumber = int.Parse(reader.GetString(7));
                                billItem.SupplierCode = reader.GetString(8);
                                billItem.CessPercent = SafelyParseDoubleFromString(reader.GetString(9));
                                billItem.MaximumRetailPrice = SafelyParseDoubleFromString(reader.GetString(10));
                                billItem.HsnOrSac = reader.GetString(11);
                                bill.Items.Add(billItem);
                            }
                        }
                    }
                }
                foreach (var billItem in bill.Items)
                {
                    var item = ItemDao.GetOneByCode(billItem.Code);
                    if (item != null)
                    {
                        billItem.DealerPrice = item.DealerPrice;
                    }
                }
            }

            #endregion Items

            return bill;
        }

        private static void UpdateClosingStock(Bill bill, OleDbConnection connection)
        {
            using (OleDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = UpdateClosingStockQuery;
                foreach (BillItem item in bill.Items)
                {
                    object cs = GetCurrentClosingStock(item.Code);
                    if (cs != null)
                    {
                        int currentStock;
                        if (int.TryParse(cs.ToString(), out currentStock))
                        {
                            int closingStock = currentStock - item.Quantity;
                            cmd.Parameters.Add(new OleDbParameter("@p1", closingStock));
                            cmd.Parameters.Add(new OleDbParameter("@p2", item.Code));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }
            }
        }

        private static object GetCurrentClosingStock(string itemCode)
        {
            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = GetClosingStockQuery;
                    cmd.Parameters.Add(new OleDbParameter("@ITEMCODE", itemCode));
                    object cs = cmd.ExecuteScalar();
                    return cs;
                }
            }
        }

        private static void SaveItems(Bill bill, OleDbConnection connection)
        {
            foreach (BillItem item in bill.Items)
            {
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = SaveItemsQuery;
                    cmd.Parameters.Add(new OleDbParameter("@BILLNO", bill.BillNumnber));
                    cmd.Parameters.Add(new OleDbParameter("@BILLDATE", bill.BillDate.ToString("yyyyMMdd")));
                    cmd.Parameters.Add(new OleDbParameter("@CUSTOMERCODE", bill.PartyCode));
                    cmd.Parameters.Add(new OleDbParameter("@ITEMCODE", item.Code));
                    cmd.Parameters.Add(new OleDbParameter("@ITEMNAME", item.Name));
                    cmd.Parameters.Add(new OleDbParameter("@UNIT", "Nos"));
                    cmd.Parameters.Add(new OleDbParameter("@QTY", item.Quantity));
                    cmd.Parameters.Add(new OleDbParameter("@RATE", FixDecimaPoints(item.Rate)));
                    cmd.Parameters.Add(new OleDbParameter("@DISCPER", FixDecimaPoints(item.DiscountPercent)));
                    cmd.Parameters.Add(new OleDbParameter("@DISCOUNT",
                        Math.Round(item.Quantity*item.DiscountPercent*item.Rate/100, 2)));
                    cmd.Parameters.Add(new OleDbParameter("@SPLDISCPER", FixDecimaPoints(bill.SpecialDiscountPercent)));
                    cmd.Parameters.Add(new OleDbParameter("@SPLDISCOUNT", FixDecimaPoints(item.SpecialDiscountAmount)));
                    cmd.Parameters.Add(new OleDbParameter("@TAXPER", FixDecimaPoints(item.GstPercent)));
                    cmd.Parameters.Add(new OleDbParameter("@TAXAMT", FixDecimaPoints(item.TaxAmount)));
                    cmd.Parameters.Add(new OleDbParameter("@NETAMT", FixDecimaPoints(item.NetAmount)));
                    cmd.Parameters.Add(new OleDbParameter("@LC", FixDecimaPoints(item.LandingCost)));
                    cmd.Parameters.Add(new OleDbParameter("@SALESCODE", Convert.ToInt32(401000)));
                    cmd.Parameters.Add(new OleDbParameter("@SLNO", item.ItemNumber));
                    cmd.Parameters.Add(new OleDbParameter("@TAXCODE", FixDecimaPoints(item.MaximumRetailPrice)));
                    cmd.Parameters.Add(new OleDbParameter("@SUPPLIERCODE", item.SupplierCode));
                    cmd.Parameters.Add(new OleDbParameter("@TAXCATEGORY", "2 Cash"));
                    cmd.Parameters.Add(new OleDbParameter("@CESSPER", FixDecimaPoints(item.CessPercent)));
                    cmd.Parameters.Add(new OleDbParameter("@CESSAMT", FixDecimaPoints(item.CessAmount)));
                    cmd.Parameters.Add(new OleDbParameter("@MRP", FixDecimaPoints(item.MaximumRetailPrice)));
                    cmd.Parameters.Add(new OleDbParameter("@HSNORSAC", item.HsnOrSac));
                    cmd.Parameters.Add(new OleDbParameter("@SALESTYPE", bill.SalesType.EnumToString()));
                    cmd.Parameters.Add(new OleDbParameter("@GSTIN",
                        string.IsNullOrEmpty(bill.PartyGstIn) ? "gstin" : bill.PartyGstIn));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void SaveBill(Bill bill, OleDbConnection connection)
        {
            using (OleDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = SaveBillQuery;
                cmd.Parameters.Add(new OleDbParameter("@BILLNO", bill.BillNumnber));
                cmd.Parameters.Add(new OleDbParameter("@BILLDATE", bill.BillDate.ToString("yyyyMMdd")));
                cmd.Parameters.Add(new OleDbParameter("@BILLTYPE", "2 Cash"));
                cmd.Parameters.Add(new OleDbParameter("@CUSTOMERCODE", bill.PartyCode));
                cmd.Parameters.Add(new OleDbParameter("@CUSTOMERNAME", bill.PartyName));
                cmd.Parameters.Add(new OleDbParameter("@CUSTOMERADDRESS", bill.PartyAddress));
                cmd.Parameters.Add(new OleDbParameter("@TOTALAMT1", FixDecimaPoints(bill.TotalAmount1)));
                cmd.Parameters.Add(new OleDbParameter("@DISCOUNTAMT", FixDecimaPoints(bill.DsicountAmount)));
                cmd.Parameters.Add(new OleDbParameter("@TOTAL2", FixDecimaPoints(bill.TotalAmount2)));
                cmd.Parameters.Add(new OleDbParameter("@SPLDISCPER", FixDecimaPoints(bill.SpecialDiscountPercent)));
                cmd.Parameters.Add(new OleDbParameter("@SPLDISCOUNTAMT", FixDecimaPoints(bill.SpecialDiscountAmount)));
                cmd.Parameters.Add(new OleDbParameter("@TOTAL3", FixDecimaPoints(bill.TotalAmount3)));
                cmd.Parameters.Add(new OleDbParameter("@TAXAMT", FixDecimaPoints(bill.TaxAmount)));
                cmd.Parameters.Add(new OleDbParameter("@ASTPER", Convert.ToDouble(0)));
                cmd.Parameters.Add(new OleDbParameter("@ASTAMT", Convert.ToDouble(0)));
                cmd.Parameters.Add(new OleDbParameter("@TOTAL4", FixDecimaPoints(bill.TotalAmount4)));
                cmd.Parameters.Add(new OleDbParameter("@HANDLINGCH", Convert.ToDouble(0)));
                cmd.Parameters.Add(new OleDbParameter("@GTOTAL", FixDecimaPoints(bill.FinalBillAmount)));
                cmd.Parameters.Add(new OleDbParameter("@ROUNDEDOF", FixDecimaPoints(bill.RoundOffAmount)));
                cmd.Parameters.Add(new OleDbParameter("@BILLAMT", FixDecimaPoints(bill.FinalBillAmount)));
                cmd.Parameters.Add(new OleDbParameter("@BILLTIME", bill.BillDate.ToString("HH:mm:ss")));
                cmd.Parameters.Add(new OleDbParameter("@USERID", Convert.ToInt32(1)));
                cmd.Parameters.Add(new OleDbParameter("@TOTALCESSAMT",
                    Math.Round(bill.Items.Sum(item => item.CessAmount), 2)));
                cmd.Parameters.Add(new OleDbParameter("@BALANCE", FixDecimaPoints(bill.FinalBillAmount)));
                cmd.Parameters.Add(new OleDbParameter("@PFT", FixDecimaPoints(bill.Profit)));
                cmd.Parameters.Add(new OleDbParameter("@PAYMENTTYPE", "Cash"));
                cmd.Parameters.Add(new OleDbParameter("@SALESTYPE", bill.SalesType.EnumToString()));
                cmd.Parameters.Add(new OleDbParameter("@GSTIN", bill.PartyGstIn));
                cmd.ExecuteNonQuery();
            }
        }

        public static int GetLastBillNumber()
        {
            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = GetLastBillNumberQuery;
                object lbn = cmd.ExecuteScalar();
                if (lbn != null)
                {
                    int lastBillNumber;
                    if (int.TryParse(lbn.ToString(), out lastBillNumber))
                    {
                        return lastBillNumber;
                    }
                }
            }
            return -1;
        }

        private static double FixDecimaPoints(double value, int decimalPoints = 2)
        {
            return Math.Round(value, decimalPoints);
        }

        public static void DeleteBill(string billNumber)
        {
            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = DeleteBillQuery;
                    cmd.Parameters.Add("@p1", billNumber);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = DeleteItemsQuery;
                    cmd.Parameters.Add("@p1", billNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static double SafelyParseDoubleFromString(string s)
        {
            double number;
            if (double.TryParse(s, out number))
            {
                return number;
            }
            return 0.0;
        }
    }

    public static class ReportDao
    {
        private const string GetItemsSoldInDateRangeQuery =
            "SELECT GSTIN, BILLNO, BILLDATE, TAXPER, RATE, QTY, CESSPER, DISCOUNT, SPLDISCOUNT FROM SITEM WHERE BILLDATE >= ? AND BILLDATE <= ?  ";
        private const string GetBillsQuery = "SELECT BILLNO, BILLDATE, CUSTOMERCODE, TOTAL4, TAXAMT, CUSTOMERNAME FROM SALES WHERE ";
        private const string GetItemsQuery = "SELECT BILLNO, BILLDATE, CUSTOMERCODE, ITEMCODE, ITEMNAME, QTY FROM SITEM WHERE ";
        private const string GetAlBillsQuery = "SELECT DISTINCT BILLNO FROM SITEM WHERE BILLDATE >= ? AND BILLDATE <= ? ";
        private const string SalesTypeClause = "AND SALESTYPE = ? ";
        private const string GetItemDetailsQuery =
            "SELECT GSTIN, BILLNO, BILLDATE, TAXPER, RATE, QTY, CESSPER, DISCOUNT, SPLDISCOUNT, CUSTOMERCODE FROM SITEM WHERE BILLNO = ?";
        public static List<BillWiseRecord> GetBillsMatchingCriteria(BillWiseReportCriteria criteria)
        {
            string query = GetBillsQuery + " BILLDATE >= '" + criteria.StartDate.ToString("yyyyMMdd") + "'";
            query += " AND " + " BILLDATE <= '" + criteria.EndDate.ToString("yyyyMMdd") + "'";

            if (criteria.StartingBillNumber > 0 && criteria.EndingBillNumber > 0)
            {
                query += " AND " + " BILLNO >= " + criteria.StartingBillNumber;
                query += " AND " + " BILLNO <= " + criteria.EndingBillNumber;
            }

            if (!string.IsNullOrEmpty(criteria.CustomerCode))
            {
                query += " AND " + " CUSTOMERCODE = " + criteria.CustomerCode;
            }

            var items = new List<BillWiseRecord>();
            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                var command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            var bill = new BillWiseRecord
                            {
                                BillNumber = int.Parse(reader.GetString(0)),
                                BillDate = DateTime.ParseExact(reader.GetString(1), "yyyyMMdd", null),
                                CustomerCode = reader.GetString(2),
                                BillAmount = double.Parse(reader.GetString(3)),
                                TaxAmount = double.Parse(reader.GetString(4)),
                                CustomerName = reader.GetString(5)
                            };

                            items.Add(bill);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return items;
        }

        public static List<ItemWiseRecord> GetBillsMatchingCriteria(ItemWiseReportCriteria criteria)
        {
            string query = GetItemsQuery + " BILLDATE >= '" + criteria.StartDate.ToString("yyyyMMdd") + "'";
            query += " AND " + " BILLDATE <= '" + criteria.EndDate.ToString("yyyyMMdd") + "'";

            if (criteria.StartingBillNumber > 0 && criteria.EndingBillNumber > 0)
            {
                query += " AND " + " BILLNO >= " + criteria.StartingBillNumber;
                query += " AND " + " BILLNO <= " + criteria.EndingBillNumber;
            }

            if (!string.IsNullOrEmpty(criteria.CustomerCode))
            {
                query += " AND " + " CUSTOMERCODE = " + criteria.CustomerCode;
            }

            if (!string.IsNullOrEmpty(criteria.ItemCode))
            {
                query += " AND " + " ITEMCODE = " + criteria.ItemCode;
            }

            var items = new List<ItemWiseRecord>();
            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                var command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            var bill = new ItemWiseRecord
                            {
                                BillNumber = int.Parse(reader.GetString(0)),
                                BillDate = DateTime.ParseExact(reader.GetString(1), "yyyyMMdd", null),
                                CustomerCode = reader.GetString(2),
                                ItemCode = reader.GetString(3),
                                ItemName = reader.GetString(4),
                                Quantity = int.Parse(reader.GetString(5))
                            };

                            items.Add(bill);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return items;
        }

        public static List<ItemDetailRecord> GetItemDetailsInDateRange(SalesRegisterReportCriteria criteria)
        {
            var billNumbers = GetAllBillsInRange(criteria.StartDate, criteria.EndDate, criteria.SalesType);
            var itemDetails = new List<ItemDetailRecord>();

            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = GetItemDetailsQuery;
                    foreach (var billNumber in billNumbers)
                    {
                        cmd.Parameters.Add(new OleDbParameter("@p1", billNumber));
                        var reader = cmd.ExecuteReader();
                        while (reader != null && reader.Read())
                        {
                            var item = new ItemDetailRecord
                            {
                                GstIn = reader.GetString(0),
                                BillNumber = reader.GetString(1),
                                BillDate = DateTime.ParseExact(reader.GetString(2), "yyyyMMdd", null),
                                TaxPercentage = int.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(3))),
                                Rate = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(4))),
                                Quantity = int.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(5))),
                                CessPercentage = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(6))),
                                DiscountAmount = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(7))),
                                SpecialDiscountAmount = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(8))),
                                CustomerCode = reader.GetString(9)
                            };
                            itemDetails.Add(item);
                        }
                        if (reader != null) reader.Dispose();
                        cmd.Parameters.Clear();
                    }
                }
                var customerCodes = itemDetails.Select(item => item.CustomerCode).Distinct().ToList();
                foreach (var code in customerCodes)
                {
                    var party = PartyDao.GetOneByCode(code);
                    var code1 = code;
                    var matchingItems = itemDetails.Where(item => item.CustomerCode == code1);
                    foreach (var item in matchingItems)
                    {
                        item.CustomerName = party.Name;
                        item.CustomerAddress = party.Address;
                    }
                }
            }
            return itemDetails;
        }

        private static string GetDefaultValueIfNullOrEmpty(string p)
        {
            return string.IsNullOrEmpty(p) ? "0" : p;
        }

        private static List<string> GetAllBillsInRange(DateTime start, DateTime end, SalesType salesType)
        {
            List<string> bills = new List<string>();
             using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    if (salesType != SalesType.Both)
                    {
                        cmd.CommandText = GetAlBillsQuery + SalesTypeClause;
                        cmd.Parameters.Add(new OleDbParameter("@p1", start.ToString("yyyyMMdd")));
                        cmd.Parameters.Add(new OleDbParameter("@p2", end.ToString("yyyyMMdd")));
                        cmd.Parameters.Add(new OleDbParameter("@p3", salesType.EnumToString()));
                    }
                    else
                    {
                        cmd.CommandText = GetAlBillsQuery;
                        cmd.Parameters.Add(new OleDbParameter("@p1", start.ToString("yyyyMMdd")));
                        cmd.Parameters.Add(new OleDbParameter("@p2", end.ToString("yyyyMMdd")));
                    }
                    var reader = cmd.ExecuteReader();
                    while (reader != null && reader.Read())
                    {
                        var bill = reader.GetString(0);
                        bills.Add(bill);
                    }
                }
            }
            return bills;
        }

        public static List<ItemDetailRecord> GetItemDetailsInDateRange(DateTime startDate, DateTime endDate)
        {
            var itemDetails = new List<ItemDetailRecord>();

            using (OleDbConnection connection = DatabaseManager.GetConnection())
            {
                connection.Open();
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = GetItemsSoldInDateRangeQuery;
                        cmd.Parameters.Add(new OleDbParameter("@p1", startDate.Date.ToString("yyyyMMdd")));
                        cmd.Parameters.Add(new OleDbParameter("@p1", endDate.Date.ToString("yyyyMMdd")));
                        var reader = cmd.ExecuteReader();
                        while (reader != null && reader.Read())
                        {
                            var item = new ItemDetailRecord
                            {
                                GstIn = reader.GetString(0),
                                BillNumber = reader.GetString(1),
                                BillDate = DateTime.ParseExact(reader.GetString(2), "yyyyMMdd", null),
                                TaxPercentage = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(3))),
                                Rate = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(4))),
                                Quantity = int.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(5))),
                                CessPercentage = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(6))),
                                DiscountAmount = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(7))),
                                SpecialDiscountAmount = double.Parse(GetDefaultValueIfNullOrEmpty(reader.GetString(8)))
                            };
                            itemDetails.Add(item);
                        }
                        if (reader != null) reader.Dispose();
                        cmd.Parameters.Clear();
                }
            }
            return itemDetails;
        }
    }
}