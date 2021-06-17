using ModelEF.Model;
using ModelEF.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Funtion
{
    public class SanPhamFunction
    {
        private TranVoLapContext db = null;
        public SanPhamFunction()
        {
            db = new TranVoLapContext();
        }


        //Tìm kiếm sản phẩm + phân trang
        //public List<Product> ListAll()
        //{
        //    return db.Products.ToList();
        //}
        //public object GetListSanPham(string searchString, int page)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public IEnumerable<Product> GetListSanPham(string keysearch, int page, int pagesize)
        //{
        //    IEnumerable<Product> model = db.Products;
        //    if (!string.IsNullOrEmpty(keysearch))
        //    {
        //        model = model.Where(x => x.IDProduct.Contains(keysearch) || x.IDCategory.Contains(keysearch) || x.NameProduct.Contains(keysearch));
        //    }
        //    return model.OrderByDescending(x => x.IDProduct).ToPagedList(page, pagesize);
        //}
        public List<SanPhamView> GetListSanPham()
        {
            var query = from sp in db.Products
                        join c in db.Categories on sp.IDCategory equals c.IDCategory
                        select new { sp, c };
            var result = query.Select(x => new SanPhamView()
            {
                IDProduct = x.sp.IDProduct,
                NameProduct = x.sp.NameProduct,
                MetaName = x.sp.MetaName,
                Quantity = x.sp.Quantity,
                UnitCost = x.sp.UnitCost,
                Image = x.sp.Image,
                Author = x.sp.Author,
                Description = x.sp.Description,
                Status = x.sp.Status,
                IDCategory = x.c.IDCategory,
                NameCategory = x.c.NameCategory,

            }).ToList();
            return result;
        }

        //chi tiết sản phẩm
        public Product GetSanPhamById(string id)
        {
            return db.Products.Where(s => s.IDProduct.CompareTo(id) == 0).SingleOrDefault();
        }
        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public void ThemSP(Product sanpham)
        {
            var id = db.Products.Max(x => x.IDProduct);
            string phanDau = id.Substring(0, 2);
            int so = Convert.ToInt32(id.Substring(2, 2)) + 1;
            var sanpham1 = new Product()
            {
                IDProduct = so > 9 ? phanDau + so : phanDau + "0" + so,
                IDCategory = sanpham.IDCategory,
                NameProduct = sanpham.NameProduct,
                MetaName = sanpham.MetaName,
                Quantity = sanpham.Quantity,
                UnitCost = sanpham.UnitCost,
                Image = sanpham.Image,
                Author = sanpham.Author,
                Description = sanpham.Description,
                Status = sanpham.Status
            };
            db.Products.Add(sanpham1);
            db.SaveChanges();
        }
        //Sửa
        public void SuaSP(Product sanpham)
        {
            Product sp = GetSanPhamById(sanpham.IDProduct);
            sp.IDCategory = sanpham.IDCategory;
            sp.NameProduct = sanpham.NameProduct;
            sp.MetaName = sanpham.MetaName;
            sp.Quantity = sanpham.Quantity;
            sp.UnitCost = sanpham.UnitCost;
            sp.Image = sanpham.Image;
            sp.Author = sanpham.Author;
            sp.Description = sanpham.Description;
            sp.Status = sanpham.Status;
            db.SaveChanges();
        }

        //xóa sản phẩm
        public void XoaSP(string id)
        {
            Product nd = GetSanPhamById(id);
            db.Products.Remove(nd);
            db.SaveChanges();
        }
      
       
    }
}
