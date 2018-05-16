using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class QuangCaoDAO
    {
        TravelOnlineDbContext db = null;
        public QuangCaoDAO()
        {
            db = new TravelOnlineDbContext();
        }

        public long Insert(tblQUANGCAO entity)
        {
            db.tblQUANGCAOs.Add(entity);
            db.SaveChanges();
            return entity.maqc;
        }

        public List<tblQUANGCAO> DanhSachQuangCao()
        {
            return db.tblQUANGCAOs.OrderByDescending(x => x.maqc).ToList();
        }

        public IEnumerable<tblQUANGCAO> ListAllPaging(int page, int pageSize)
        {
            return db.tblQUANGCAOs.OrderByDescending(x => x.maqc).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var qc = db.tblQUANGCAOs.Find(id);
                db.tblQUANGCAOs.Remove(qc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(tblQUANGCAO entity)
        {
            try
            {
                var qc = db.tblQUANGCAOs.Find(entity.maqc);
                qc.tenqc = entity.tenqc;
                qc.url = entity.url;
                qc.urlanh = entity.urlanh;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public tblQUANGCAO ViewDetail(int id)
        {
            return db.tblQUANGCAOs.Find(id);
        }
    }


}
