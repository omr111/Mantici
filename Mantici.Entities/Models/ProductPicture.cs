using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class ProductPicture
    {
        public int id { get; set; }
        public string productPicturePath { get; set; }
        public string pictureAlt { get; set; }
        public int productID { get; set; }
        public virtual Product Product { get; set; }
    }
}
