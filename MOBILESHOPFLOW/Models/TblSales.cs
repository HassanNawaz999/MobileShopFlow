using System;
using System.Collections.Generic;

namespace MOBILESHOPFLOW.Models
{
    public partial class TblSales
    {
        [key]
        public int SaleId { get; set; }
        public int CatagoryId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
<<<<<<< HEAD
        public int PricePerUnit { get; set; }
        public int TotalPrice { get; set; }
=======
        public float Price { get; set; }
>>>>>>> 1f469b961d7db5815e8fafb2b87cdccf442cca9c
        public DateTime Date { get; set; }
    }
}
