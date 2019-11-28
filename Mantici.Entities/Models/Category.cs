using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int id { get; set; }
      
        public string categoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
