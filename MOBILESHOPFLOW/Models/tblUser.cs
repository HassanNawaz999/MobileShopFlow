using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOBILESHOPFLOW.Models
{
    public partial class tblUser
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int userId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
