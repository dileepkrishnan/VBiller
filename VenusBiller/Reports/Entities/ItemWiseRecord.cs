namespace VenusBiller.Reports.Entities
{
    public class ItemWiseRecord : BillWiseRecord
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
    }
}