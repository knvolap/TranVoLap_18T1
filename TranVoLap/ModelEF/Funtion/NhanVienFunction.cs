using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Funtion
{
   public class NhanVienFunction
    {
        private TranVoLapContext db = null;
        public NhanVienFunction()
        {
            db = new TranVoLapContext();
        }

        public UserAccount GetNhanVienById(string id)
        {
            return db.UserAccounts.Where(s => s.IDUser.CompareTo(id) == 0).FirstOrDefault();
        }

        public void ThemNV(UserAccount nguoidung)
        {
            var id = db.UserAccounts.Max(x => x.IDUser);
            string phanDau = id.Substring(0, 2);
            int so = Convert.ToInt32(id.Substring(2, 2)) + 1;
            var nguoidung1 = new UserAccount()
            {
                IDUser = so > 9 ? phanDau + so : phanDau + "0" + so,
                UserName = nguoidung.UserName,
                Password = nguoidung.Password,
                PhoneNumber = nguoidung.PhoneNumber,           
                UserType = nguoidung.UserType,
                Status = nguoidung.Status
            };
            db.UserAccounts.Add(nguoidung1);
            db.SaveChanges();
        }

        public bool XoaNV(string id)
        {
            try 
            {
                var nd = db.UserAccounts.Find(id);
                
                db.UserAccounts.Remove(nd);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
           
        }
      
        public List<UserAccount> GetCategories()
        {
            return db.UserAccounts.ToList();
        }

        //Sửa
        public void SuaNV(UserAccount nhanvien)
        {
            UserAccount nv = GetNhanVienById(nhanvien.IDUser);
            nv.UserName = nhanvien.UserName;
            nv.Password = nhanvien.Password;
            nv.PhoneNumber = nhanvien.PhoneNumber;
            nv.UserType = nhanvien.UserName;
            nv.Status = nhanvien.Status;
            db.SaveChanges();
        }

    }
}
