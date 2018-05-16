using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LienHeDAO
    {
        TravelOnlineDbContext db = null;
        public LienHeDAO()
        {
            db = new TravelOnlineDbContext();
        }

        public tblLIENHE LayThongTinLienHe()
        {
            return db.tblLIENHEs.Single(x => x.status == true);
        }
    }
}
