namespace VenusBiller.Services
{
    public static class DataService
    {
        public static PartyService Party = new PartyService();
        public static ItemService Item = new ItemService();
        public static BillService Bill = new BillService();
        public static ReportService Report = new ReportService();
    }
}