using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Funtion
{
    public class LoaiSachFuntion
    {
        private TranVoLapContext db = null;
        public LoaiSachFuntion()
        {
            db = new TranVoLapContext();
        }

        public Category GetLoaiSachById(string id)
        {
            return db.Categories.Where(s => s.IDCategory.CompareTo(id) == 0).FirstOrDefault();

        }
        //Tìm kiếm loại sách + phân trang
        public List<Category> ListAllLSP()
        {
            return db.Categories.ToList();
        }
        public object ListAllPagingLSP(string searchString, int page)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Category> ListAllPagingLSP(string keysearch, int page, int pagesize)
        {
            IEnumerable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.IDCategory.Contains(keysearch) || x.NameCategory.Contains(keysearch));
            }
            return model.OrderByDescending(x => x.IDCategory).ToPagedList(page, pagesize);
        }
    }
}
