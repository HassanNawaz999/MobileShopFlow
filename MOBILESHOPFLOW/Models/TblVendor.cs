using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBILESHOPFLOW.Models
{
    public partial class TblVendor
    {
        [key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
