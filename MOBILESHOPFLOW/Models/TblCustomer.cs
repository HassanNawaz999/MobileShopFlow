using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace MOBILESHOPFLOW.Models
{
    public partial class TblCustomer
    {
    [key]
        public int Cusotmer_id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
