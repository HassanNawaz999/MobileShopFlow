using System;
using System.Collections.Generic;

namespace MOBILESHOPFLOW.Models
{
    public partial class TblItem
    {
        [key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Image { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int CatagoryId { get; set; }
    }
}
