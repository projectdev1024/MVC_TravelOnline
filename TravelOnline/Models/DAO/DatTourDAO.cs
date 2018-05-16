using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DatTourDAO
    {
        TravelOnlineDbContext db = null;
        public DatTourDAO()
        {
            db = new TravelOnlineDbContext();
        }
        public long Insert(tblDATTOUR entity)
        {
            db.tblDATTOURs.Add(entity);
            db.SaveChanges();
            return entity.madattour;
        }
        public bool Update(tblDATTOUR entity)
        {
            try
            {

                var dattour = db.tblDATTOURs.Find(entity.madattour);
                dattour.songuoilon = entity.songuoilon;
                dattour.sotreem = entity.sotreem;
                dattour.hoten = entity.hoten;
                dattour.tongtien = entity.tongtien;
                dattour.cmt = entity.cmt;
                dattour.diachi = entity.diachi;
                dattour.dienthoai = entity.dienthoai;
                dattour.email = entity.email;
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
                var tourdat = db.tblDATTOURs.Find(id);
                db.tblDATTOURs.Remove(tourdat);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DatTourViewModel> TourChuaThanhToanTheoKhachHang(int makh)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblDATTOURs on a.matour equals b.matour
                        where b.makh == makh && b.dathanhtoan==false
                        select new DatTourViewModel()
                        {
                            matour = a.matour,
                            tentour = a.tentour,
                            madattour = b.madattour,
                            ngaykhoihanh = a.khoihanh,
                            ngayketthuc = a.ketthuc,
                            songuoilon = b.songuoilon,
                            sotreem = b.sotreem,
                            makh = b.makh,
                            hoten = b.hoten,
                            cmt = b.cmt,
                            ngaydattour = b.ngaydattour,
                            diachi =b.diachi,
                            dienthoai = b.dienthoai,
                            email = b.email,
                            tongtien = b.tongtien,
                            dathanhtoan = b.dathanhtoan
                        };
            return model.ToList();
       
        }

        public bool CheckDatTour(int makh)
        {
            var model = db.tblDATTOURs.Where(x => x.makh == makh && x.dathanhtoan == false);
            if (model.Count() > 0)
                return false;
            return true;
        }

        public DatTourViewModel TourChuaThanhToan(int madattour)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblDATTOURs on a.matour equals b.matour
                        where b.madattour == madattour && b.dathanhtoan==false
                        select new DatTourViewModel()
                        {
                            matour = a.matour,
                            tentour = a.tentour,
                            madattour = b.madattour,
                            ngaykhoihanh = a.khoihanh,
                            ngayketthuc = a.ketthuc,
                            songuoilon = b.songuoilon,
                            sotreem = b.sotreem,
                            makh = b.makh,
                            hoten = b.hoten,
                            cmt = b.cmt,
                            ngaydattour = b.ngaydattour,
                            diachi = b.diachi,
                            dienthoai = b.dienthoai,
                            email = b.email,
                            tongtien = b.tongtien,
                            dathanhtoan = b.dathanhtoan
                        };
            return model.SingleOrDefault();
        }

        public List<DatTourViewModel> TourChuaThanhToan()
        {
            var model = from a in db.tblTOURs
                        join b in db.tblDATTOURs on a.matour equals b.matour
                        where b.dathanhtoan == false
                        select new DatTourViewModel()
                        {
                            matour = a.matour,
                            tentour = a.tentour,
                            madattour = b.madattour,
                            ngaykhoihanh = a.khoihanh,
                            ngayketthuc = a.ketthuc,
                            songuoilon = b.songuoilon,
                            sotreem = b.sotreem,
                            makh = b.makh,
                            hoten = b.hoten,
                            cmt = b.cmt,
                            ngaydattour = b.ngaydattour,
                            diachi = b.diachi,
                            dienthoai = b.dienthoai,
                            email = b.email,
                            tongtien = b.tongtien,
                            dathanhtoan = b.dathanhtoan
                        };
            return model.ToList();
        }

        public DatTourViewModel TourDaThanhToan(int madattour)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblDATTOURs on a.matour equals b.matour
                        where b.madattour == madattour && b.dathanhtoan == true
                        select new DatTourViewModel()
                        {
                            matour = a.matour,
                            tentour = a.tentour,
                            madattour = b.madattour,
                            ngaykhoihanh = a.khoihanh,
                            ngayketthuc = a.ketthuc,
                            songuoilon = b.songuoilon,
                            sotreem = b.sotreem,
                            makh = b.makh,
                            hoten = b.hoten,
                            cmt = b.cmt,
                            ngaydattour = b.ngaydattour,
                            diachi = b.diachi,
                            dienthoai = b.dienthoai,
                            email = b.email,
                            tongtien = b.tongtien,
                            dathanhtoan = b.dathanhtoan
                        };
            return model.SingleOrDefault();
        }

        public bool XacNhanThanhToan(int id)
        {
            try
            {

                var dattour = db.tblDATTOURs.Find(id);
           
                dattour.dathanhtoan = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }        
        }

        public List<DatTourViewModel> DanhSachTourDaDat(int matour)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblDATTOURs on a.matour equals b.matour
                        where a.matour == matour && b.dathanhtoan==true
                        select new DatTourViewModel()
                        {
                            matour = a.matour,
                            tentour = a.tentour,
                            madattour = b.madattour,
                            ngaykhoihanh = a.khoihanh,
                            ngayketthuc = a.ketthuc,
                            songuoilon = b.songuoilon,
                            sotreem = b.sotreem,
                            makh = b.makh,
                            hoten = b.hoten,
                            cmt = b.cmt,
                            ngaydattour = b.ngaydattour,
                            diachi = b.diachi,
                            dienthoai = b.dienthoai,
                            email = b.email,
                            tongtien = b.tongtien,
                            dathanhtoan = b.dathanhtoan
                        };
            return model.ToList();
        }
    }
}
