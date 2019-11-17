using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class rezervation
    {
        public int id { get; set; }
        public int rezerveFoodID { get; set; }
        public System.DateTime rezerveDate { get; set; }
        public Nullable<int> personCount { get; set; }
        public virtual rezervedFood rezervedFood { get; set; }
    }
}
