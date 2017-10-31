using System;

namespace VenusBiller.Reports
{
    public class SalesRegisterReportCriteria
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SalesType SalesType { get; set; }
        public bool PrintAfterGeneration { get; set; }
    }
}