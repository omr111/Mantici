using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class Picture
    {
        public Picture()
        {
            this.Branches = new List<Branch>();
            this.Products = new List<Product>();
        }

        public int id { get; set; }
        public string smallPath { get; set; }
        public string bigPath { get; set; }
        public string pictureAlt { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
