using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class sliderProduct
    {
        public int id { get; set; }
        public int productId { get; set; }
        public virtual Product Product { get; set; }
    }
}
