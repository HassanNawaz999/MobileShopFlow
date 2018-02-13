using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBILESHOPFLOW.Models
{
    public partial class TblCatagories
    {
        [key]
        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }
        public string Model { get; set; }
    }
}
