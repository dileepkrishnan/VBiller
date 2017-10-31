using System;

namespace VenusBiller.Reports
{
    public class BillWiseReportCriteria
    {
        public int StartingBillNumber { get; set; }
        public int EndingBillNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerCode { get; set; }
        public SortType SortType { get; set; }
        public bool PrintAfterGeneration { get; set; }
    }
}