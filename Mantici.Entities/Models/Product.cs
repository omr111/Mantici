using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            this.ProductPictures = new List<ProductPicture>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public string coverPicture { get; set; }
        public int categoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
