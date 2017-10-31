using System;

namespace VenusBiller.Reports.Entities
{
    public class ItemDetailRecord
    {
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public string GstIn { get; set; }
        public double TaxPercentage { get; set; }
        public double CessPercentage { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double DiscountAmount { get; set; }
        public double SpecialDiscountAmount { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}