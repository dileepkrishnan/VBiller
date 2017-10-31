using System;

namespace VenusBiller.Reports.Entities
{
    public class BillWiseRecord
    {
        public int BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public double BillAmount { get; set; }
        public double TaxAmount { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
    }
}