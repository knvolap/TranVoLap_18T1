using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class LeftMainMenuDao
    {
        private TranVoLapContext db = null;
        public LeftMainMenuDao()
        {
            db = new TranVoLapContext();

        }

        public List<Category> ListAllLLeftMenu()
        {
            return db.Categories.ToList();
        }
        public Category ListAllLLeftMenu(string id)
        {
            return db.Categories.Where(s => s.IDCategory.CompareTo(id) == 0).FirstOrDefault();

        }

    }
}
