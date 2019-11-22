using System;
using System.Collections.Generic;

namespace Mantici.Entities.Models
{
    public partial class banner
    {
        public int id { get; set; }
        public string bannerPath { get; set; }
        public string altName { get; set; }
        public string text { get; set; }
    }
}
