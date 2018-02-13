using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MOBILESHOPFLOW.Models
{
    public partial class TblPurchase
    {
        [key]
        public int PurchaseId { get; set; }
        public int CatagoryId { get; set; }
        public int VendorId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int PricePerUnit { get; set; }
        public int TotalPrice { get; set; }
<<<<<<< HEAD
        public DateTime Date { get; set; }
=======
        [DisplayName(displayName: "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DataType DataTime { get; set; }
>>>>>>> 1f469b961d7db5815e8fafb2b87cdccf442cca9c

    }
}
