#region

using System.ComponentModel;
using VenusBiller.Reports;

#endregion

namespace VenusBiller.Entities
{
    public class Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int ClosingStock { get; set; }
        public double MaximumRetailPrice { get; set; }
        public double DealerPrice { get; set; }
        public double Price3 { get; set; }
        public double Price4 { get; set; }
        public double LandingCost { get; set; }

        [Browsable(false)]
        public double Tax { get; set; }

        [Browsable(false)]
        public double Cess { get; set; }

        [Browsable(false)]
        public string SupplierCode { get; set; }

        [Browsable(false)]
        public string HsnOrSac { get; set; }
    }
}