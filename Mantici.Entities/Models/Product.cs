using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mantici.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            this.rezervedFoods = new List<rezervedFood>();
        }

        public int id { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        public string name { get; set; }
        [Required("Bu alan boþ geçilemez!"), MaxLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz")]
        public string caption { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public string description { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public string coverPicturePath { get; set; }
       
        public string pictureAlt { get; set; }
        public int categoryID { get; set; }
     
        public Nullable<int> pictureID { get; set; }
        [Required("Bu alan boþ geçilemez!")]
        public Nullable<decimal> price { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<rezervedFood> rezervedFoods { get; set; }
    }
}
