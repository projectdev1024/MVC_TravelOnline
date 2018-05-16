using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class KhuyenMaiDAO
    {
        TravelOnlineDbContext db = null;
        public KhuyenMaiDAO()
        {
            db = new TravelOnlineDbContext();
        }

        public long Insert(tblKHUYENMAI entity)
        {
            db.tblKHUYENMAIs.Add(entity);
            db.SaveChanges();
            return entity.matourkm;
        }

        public IEnumerable<KhuyenMaiViewModel> ListAllPaging(int page, int pageSize)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblKHUYENMAIs on a.matour equals b.matour
                        select new KhuyenMaiViewModel()
                        {
                            matourkm = b.matourkm,
                            tentour = a.tentour,
                            batdau = b.batdau,
                            kethuc = b.kethuc,
                            giam = b.giam,
                            matour = a.matour
                        };
            return model.OrderByDescending(x => x.matourkm).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var tour = db.tblKHUYENMAIs.Find(id);
                db.tblKHUYENMAIs.Remove(tour);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public tblKHUYENMAI ViewDetail(int id)
        {
            return db.tblKHUYENMAIs.Find(id);
        }

        public bool Update(tblKHUYENMAI entity)
        {
            try
            {
                var khuyenmai = db.tblKHUYENMAIs.Find(entity.matourkm);
                khuyenmai.matour = entity.matour;
                khuyenmai.giam = entity.giam;
                khuyenmai.batdau = entity.batdau;
                khuyenmai.kethuc = entity.kethuc;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
