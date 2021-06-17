using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModel
{
   
    public class HienThiSPDao
    {
        private TranVoLapContext db = null;
        public HienThiSPDao()
        {
            db = new TranVoLapContext();
        }

        public List<Product> ListALLProduct()
        {
            return db.Products.ToList();
        }
        public Product ListALLProduct(string id)
        {
            return db.Products.Where(s => s.IDProduct.CompareTo(id) == 0).FirstOrDefault();

        }

    }
   
}
