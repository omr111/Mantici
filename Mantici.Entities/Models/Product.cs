using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            this.rezervedFoods = new List<rezervedFood>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public string coverPicture { get; set; }
        public int categoryID { get; set; }
        public Nullable<int> pictureID { get; set; }
        public Nullable<decimal> price { get; set; }
        public virtual Category Category { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual ICollection<rezervedFood> rezervedFoods { get; set; }
    }
}
