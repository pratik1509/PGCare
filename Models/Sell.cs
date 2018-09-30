using System.Collections.Generic;

namespace PGCare.Models {
    public class Sell : BaseModel {
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }
        public List<SellItem> SellItems { get; set; }
        
        public double Total { get; set; }
        public double GSTTotal { get; set; }
        public double DiscountInPercentage { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    public class SellItem {
        public string StockId { get; set; } //Represents which stock entry was updated, due to this sell
        public string MedicineId { get; set; }
        public double Quantity { get; set; }
        public string BatchNo { get; set; }
        public double DiscountPercent { get; set; }
        public string ExpiryDate { get; set; }
        public double VAT  { get; set; }
         public double IGST { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }        
        public double Price { get; set; }
    }
}