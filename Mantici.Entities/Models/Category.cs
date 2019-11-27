using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int id { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        public string categoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
