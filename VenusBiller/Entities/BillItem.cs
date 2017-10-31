#region

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VenusBiller.Reports;

#endregion

namespace VenusBiller.Entities
{
    public class BillItem : INotifyPropertyChanged
    {
        private double _discountPercent;
        private int _quantity;

        public BillItem()
        {
        }

        public BillItem(Item item)
        {
            Code = item.Code;
            Name = item.Name;
            MaximumRetailPrice = item.MaximumRetailPrice;
            DealerPrice = item.DealerPrice;
            GstPercent = item.Tax;
            CessPercent = item.Cess;
            LandingCost = item.LandingCost;
            SupplierCode = item.SupplierCode;
            HsnOrSac = item.HsnOrSac;
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("NetAmount");
            }
        }

        public double DiscountPercent
        {
            get { return _discountPercent; }
            set
            {
                _discountPercent = value;
                OnPropertyChanged("NetAmount");
            }
        }
        public double Rate
        {
            get
            {
                return Math.Round(DealerPrice / (1 + ((GstPercent + CessPercent) / 100)), 2);
            }
        }

        private double _netAmount;

        public double NetAmount
        {
            get { return Math.Round(_netAmount, 2); }
            set { _netAmount = value; }
        }

        public double GstPercent { get; set; }

        public double CessPercent { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public double MaximumRetailPrice { get; set; }
        [Browsable(false)]
        public double DealerPrice { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ItemNumber { get; set; }
        [Browsable(false)]
        public double LandingCost { get; set; }
        [Browsable(false)]
        public string SupplierCode { get; set; }
        [Browsable(false)]
        public double CessAmount
        {
            get
            {
                var priceAfterDiscount = (Rate - Rate*DiscountPercent/100)*Quantity;
                priceAfterDiscount -= SpecialDiscountAmount;
                var cessAmount = priceAfterDiscount*CessPercent/100;
                return cessAmount;
            }
        }

        public string HsnOrSac { get; set; }
        public double SpecialDiscountAmount { get; set; }

        public double TaxAmount
        {
            get
            {
                var priceAfterDiscount = Rate - Rate * DiscountPercent / 100 * Quantity;
                var gstAmount = (priceAfterDiscount-SpecialDiscountAmount) * GstPercent / 100;
                return gstAmount;
            }
        }
    }
}