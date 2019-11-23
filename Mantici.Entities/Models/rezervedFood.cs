using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class rezervedFood
    {
        public int id { get; set; }
        public int productID { get; set; }
        public int count { get; set; }
        public virtual Product Product { get; set; }
    }
}
