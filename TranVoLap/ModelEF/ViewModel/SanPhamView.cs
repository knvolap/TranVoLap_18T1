using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModel
{
    public class SanPhamView
    {
         
        public string IDProduct { get; set; }
       
        public string IDCategory { get; set; }
      
        public string NameCategory { get; set; }
      
        public string NameProduct { get; set; }
    
        public string MetaName { get; set; }
      
        public int? Quantity { get; set; }
       
        public double? UnitCost { get; set; }
       
        public string Image { get; set; }
        
        public string Author { get; set; }
       
        public string Description { get; set; }
       
        public bool? Status { get; set; }
      
    }
}

