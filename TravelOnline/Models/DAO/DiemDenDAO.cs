using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Models.ViewModel;

namespace Models.DAO
{
    public class DiemDenDAO
    {
        TravelOnlineDbContext db = null;
        public DiemDenDAO()
        {
            db = new TravelOnlineDbContext();
        }

        public long Insert(tblDIEMDEN entity)
        {
            db.tblDIEMDENs.Add(entity);
            db.SaveChanges();
            return entity.madd;
        }

        public IEnumerable<tblDIEMDEN> ListAllPaging(int page, int pageSize)
        {
            return db.tblDIEMDENs.OrderByDescending(x => x.madd).ToPagedList(page, pageSize);
        }

        public tblDIEMDEN ViewDetail(int id)
        {
            return db.tblDIEMDENs.Find(id);
        }

        public bool Update(tblDIEMDEN entity)
        {
            try
            {
                var diadiem = db.tblDIEMDENs.Find(entity.madd);
                diadiem.diemden = entity.diemden;
                diadiem.loaitour = entity.loaitour;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool Delete(int id)
        {
            try
            {
                var diadiem = db.tblDIEMDENs.Find(id);
                db.tblDIEMDENs.Remove(diadiem);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<tblDIEMDEN> ListAll()
        {
            return db.tblDIEMDENs.ToList();
        }

        public tblDIEMDEN GetDiemDen(int madd)
        {
            return db.tblDIEMDENs.Find(madd);
        }

        public List<DiemDenViewModel> Seach(int id)
        {
            String loaitour;
            if (id == 1)
                loaitour = "Trong nước";
            else loaitour = "Quốc tế";
            var model = from a in db.tblDIEMDENs
                        where a.loaitour == loaitour
                        select new DiemDenViewModel()
                        {
                            madd = a.madd,
                            diemden = a.diemden,
                            loaitour = a.loaitour 
                        };
            return model.ToList();
        }
    }
}
