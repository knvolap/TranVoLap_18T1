using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Funtion
{
   public class DonHangFunction
    {
        private TranVoLapContext db = null;
        public DonHangFunction()
        {
            db = new TranVoLapContext();
        }

        public UserOder GetDatHangById(string id)
        {
            return db.UserOders.Where(s => s.IDOder.CompareTo(id) == 0).FirstOrDefault();

        }

		
	}
}

