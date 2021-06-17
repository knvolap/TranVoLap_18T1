using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private TranVoLapContext db;
        public UserDao()
        {
            db = new TranVoLapContext();
        }

        public int login(string UserName, string password)
        {
            var result = db.UserAccounts.FirstOrDefault(x => x.UserName == UserName.Trim());
            if (result == null)
            {
                //Tài khoản ko tồn tại
                return 0;
            }
            else
            {
                if (result.Password == password)
                {
                    if (result.Status == true)
                    {
                        //Vừa đúng use name & mật khẩu vừa status == true
                        return 1;
                    }
                    else
                    {
                        //Vừa đúng use name & mật khẩu vừa status == false
                        return -1;
                    }
                    //Đúng cảcuser name và pass
                }
                else
                {
                    //Sai mật khẩu
                    return -2;
                }

            }
        }

        //Tìm kiếm user + phân trang
        public List<UserAccount>ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public object ListAllPaging(string searchString, int page)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<UserAccount> ListAllPaging(string keysearch, int page, int pagesize)
        {
            IEnumerable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.IDUser.Contains(keysearch) || x.UserName.Contains(keysearch))  ;
            }
            return model.OrderByDescending(x => x.IDUser).ToPagedList(page, pagesize);
        }


        ////Tìm kiếm sản phẩm + phân trang
        //public List<Product> ListAllSP()
        //{
        //    return db.Products.ToList();
        //}
        //public object ListAllPagingSP(string searchString, int page)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public IEnumerable<Product> ListAllPagingSP(string keysearch, int page, int pagesize)
        //{
        //    IEnumerable<Product> model = db.Products;
        //    if (!string.IsNullOrEmpty(keysearch))
        //    {
        //        model = model.Where(x => x.IDProduct.Contains(keysearch) || x.IDCategory.Contains(keysearch) || x.NameProduct.Contains(keysearch));
        //    }
        //    return model.OrderByDescending(x => x.IDProduct).ToPagedList(page, pagesize);
        //}

      

        //Tìm kiếm đơn hàng + phân trang
        public List<UserOder> ListAllDH()
        {
            return db.UserOders.ToList();
        }
        public object ListAllPagingDH(string searchString, int page)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<UserOder> ListAllPagingDH(string keysearch, int page, int pagesize)
        {
            IEnumerable<UserOder> model = db.UserOders;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.IDOder.Contains(keysearch) || x.IDProduct.Contains(keysearch) || x.UserName.Contains(keysearch));
            }
            return model.OrderByDescending(x => x.IDOder).ToPagedList(page, pagesize);
        }

        ////Tìm kiếm loại sách + phân trang
        //public List<Category> ListAllLSP()
        //{
        //    return db.Categories.ToList();
        //}
        //public object ListAllPagingLSP(string searchString, int page)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public IEnumerable<Category> ListAllPagingLSP(string keysearch, int page, int pagesize)
        //{
        //    IEnumerable<Category> model = db.Categories;
        //    if (!string.IsNullOrEmpty(keysearch))
        //    {
        //        model = model.Where(x => x.IDCategory.Contains(keysearch) || x.NameCategory.Contains(keysearch));
        //    }
        //    return model.OrderByDescending(x => x.IDCategory).ToPagedList(page, pagesize);
        //}
    }
}
