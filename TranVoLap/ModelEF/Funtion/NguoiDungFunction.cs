using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Funtion
{
   public class NguoiDungFunction
    {
        private TranVoLapContext db = null;
        public NguoiDungFunction()
        {
            db = new TranVoLapContext();
        }

        public UserAccount GetNhanVienById(string id)
        {
            return db.UserAccounts.Where(s => s.IDUser.CompareTo(id) == 0).FirstOrDefault();
        }

        public void ThemND(UserAccount nguoidung)
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

        public void XoaND(string id)
        {
            UserAccount nd = GetNhanVienById(id);
            db.UserAccounts.Remove(nd);
            db.SaveChanges();
        }

    }
}
