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
            this.sliderProducts = new List<sliderProduct>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez."), MaxLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        public string caption { get; set; }


        public string description { get; set; }

    
        public string coverPicturePath { get; set; }

      
        public string pictureAlt { get; set; }
        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public int categoryID { get; set; }
        public Nullable<int> pictureID { get; set; }

        [Required(ErrorMessage = "Bu alan boþ geçilemez.")]
        public Nullable<decimal> price { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<rezervedFood> rezervedFoods { get; set; }
        public virtual ICollection<sliderProduct> sliderProducts { get; set; }
    }
}
