#region

using System;
using System.Collections.Generic;
using VenusBiller.Reports;

#endregion

namespace VenusBiller.Entities
{
    public class Bill
    {
        public Bill()
        {
            Items = new List<BillItem>();
        }

        public List<BillItem> Items { get; set; }
        public string BillNumnber { get; set; }
        public DateTime BillDate { get; set; }
        public string PartyCode { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public double SpecialDiscountPercent { get; set; }
        public double SpecialDiscountAmount { get; set; }
        public double TaxAmount { get; set; }
        public double NetAmount { get; set; }
        public string SalesCode { get; set; }
        public string TaxCategory { get; set; }
        public double TotalAmount1 { get; set; }
        public double TotalAmount2 { get; set; }
        public double TotalAmount3 { get; set; }
        public double TotalAmount4 { get; set; }
        public double DsicountAmount { get; set; }
        public double FinalBillAmount { get; set; }
        public double RoundOffAmount { get; set; }
        public double Profit { get; set; }
        public string PartyGstIn { get; set; }
        public SalesType SalesType { get; set; }
    }
}