using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Text.RegularExpressions;
using TravelOnline.Models;

namespace Models.DAO
{
    public class TourDAO
    {
        TravelOnlineDbContext db = null;
        DateTime dtkhoihanh;
        public TourDAO ()
        {
            db = new TravelOnlineDbContext();
        }



        public long Insert(tblTOUR entity)
        {
            TimeSpan remtime = entity.ketthuc - entity.khoihanh;
            int songay = remtime.Days+1;
            entity.thoigian = songay.ToString() + " ngày," + songay.ToString() + " đêm";
            string metatitle = ToAscii(entity.tentour);
            entity.metatitle = metatitle;
            db.tblTOURs.Add(entity);      
            db.SaveChanges();
            return entity.matour;
        }

        public IEnumerable<tblTOUR> ListAllPaging(int page, int pageSize)
        {
            return db.tblTOURs.OrderByDescending(x => x.matour).ToPagedList(page, pageSize);
        }

        public TourViewModel ViewDetail(int id)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblKHUYENMAIs on a.matour equals b.matour into gj
                        from x in gj.DefaultIfEmpty()
                        where a.matour == id
                        select new TourViewModel()
                        {
                            matour = a.matour,
                            metatitle = a.metatitle,
                            khoihanh = a.khoihanh,
                            ketthuc = a.ketthuc,
                            chitiettour = a.chitiettour,
                            giatour = a.giatour,
                            giam = x.giam,
                            batdaukm = x.batdau,
                            ketthuckm = x.kethuc,
                            giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                            tentour = a.tentour,
                            thoigian = a.thoigian,
                            socho = a.socho,
                            madd = a.madd,
                            hinhanh = a.hinhanh,
                            phuongtien = a.phuongtien
                        };
            return model.SingleOrDefault();
        }

        public bool Update(tblTOUR entity)
        {
            try
            {
                var tour = db.tblTOURs.Find(entity.matour);
                tour.tentour = entity.tentour;
                tour.chitiettour = entity.chitiettour;
                tour.hinhanh = entity.hinhanh;
                tour.socho = entity.socho;
                tour.giatour = entity.giatour;
                tour.khoihanh = entity.khoihanh;
                tour.ketthuc = entity.ketthuc;
                tour.madd = entity.madd;
                tour.phuongtien = entity.phuongtien;
                TimeSpan remtime = entity.ketthuc - entity.khoihanh;
                int songay = remtime.Days +1;
                tour.thoigian = songay.ToString() + " ngày," + songay.ToString() + " đêm";
                string metatitle = ToAscii(entity.tentour);
                tour.metatitle = metatitle;
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
                var tour = db.tblTOURs.Find(id);
                db.tblTOURs.Remove(tour);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<tblTOUR> ListAll()
        {

            return db.tblTOURs.ToList();
        }

        public List<TourViewModel> TourChuaKhuyenMai()
        {
            var model = from a in db.tblTOURs
                        join b in db.tblKHUYENMAIs on a.matour equals b.matour into gj
                        from x in gj.DefaultIfEmpty()
                        where x.matourkm==null
                        select new TourViewModel()
                        {
                            matour = a.matour,
                            metatitle = a.metatitle,
                            khoihanh = a.khoihanh,
                            ketthuc = a.ketthuc,
                            chitiettour = a.chitiettour,
                            giatour = a.giatour,
                            giam = x.giam,
                            batdaukm = x.batdau,
                            ketthuckm = x.kethuc,
                            giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                            tentour = a.tentour,
                            thoigian = a.thoigian,
                            socho = a.socho,
                            madd = a.madd,
                            hinhanh = a.hinhanh,
                            phuongtien = a.phuongtien

                        };
            return model.OrderByDescending(x => x.matour).ToList();
        }

        public List<TourViewModel> ListNewTour(int top)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblKHUYENMAIs on a.matour equals b.matour into gj
                        from x in gj.DefaultIfEmpty()
                        select new TourViewModel()
                        {
                            matour = a.matour,
                            metatitle = a.metatitle,
                            khoihanh = a.khoihanh,
                            ketthuc = a.ketthuc,
                            chitiettour = a.chitiettour,
                            giatour = a.giatour,
                            giam = x.giam,
                            batdaukm = x.batdau,
                            ketthuckm = x.kethuc,
                            giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                            tentour = a.tentour,
                            thoigian = a.thoigian,
                            socho = a.socho,
                            madd = a.madd,
                            hinhanh = a.hinhanh,
                            phuongtien = a.phuongtien

                        };
            return model.OrderByDescending(x => x.matour).Take(top).ToList();
        }

        public string ToAscii(string unicode)
        {
            unicode = Regex.Replace(unicode, "[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            unicode = Regex.Replace(unicode, "[óòỏõọôồốổỗộơớờởỡợ]", "o");
            unicode = Regex.Replace(unicode, "[éèẻẽẹêếềểễệ]", "e");
            unicode = Regex.Replace(unicode, "[íìỉĩị]", "i");
            unicode = Regex.Replace(unicode, "[úùủũụưứừửữự]", "u");
            unicode = Regex.Replace(unicode, "[ýỳỷỹỵ]", "y");
            unicode = Regex.Replace(unicode, "[đ]", "d");
            //unicode = Regex.Replace(unicode, "[-\\s+/]+", "-");
            unicode = Regex.Replace(unicode, "\\W+", "-"); //Nếu bạn muốn thay dấu khoảng trắng thành dấu "_" hoặc dấu cách " " thì thay kí tự bạn muốn vào đấu "-"
            return unicode;
        }

        public IEnumerable<TourViewModel> GetListTourOfCategory(string loaitour, int page, int pageSize)
        {
            var model = from a in db.tblTOURs
                        join b in db.tblDIEMDENs on a.madd equals b.madd
                        join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                        from x in gj.DefaultIfEmpty()
                        where b.loaitour == loaitour
                        select new TourViewModel()
                        {
                            matour = a.matour,
                            metatitle = a.metatitle,
                            khoihanh = a.khoihanh,
                            ketthuc = a.ketthuc,
                            chitiettour = a.chitiettour,
                            giatour = a.giatour,
                            giam = x.giam,
                            batdaukm = x.batdau,
                            ketthuckm = x.kethuc,
                            giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                            tentour = a.tentour,
                            thoigian = a.thoigian,
                            socho = a.socho,
                            madd = a.madd,
                            hinhanh = a.hinhanh,
                            phuongtien = a.phuongtien        
                        };
            return model.OrderByDescending(x=>x.matour).ToPagedList(page, pageSize);
        }

        public IEnumerable<TourViewModel> GetTourKhuyenMai(int page, int pageSize)
        {
            var model = from a in db.tblTOURs
                        join x in db.tblKHUYENMAIs on a.matour equals x.matour
                        select new TourViewModel()
                        {
                            matour = a.matour,
                            metatitle = a.metatitle,
                            khoihanh = a.khoihanh,
                            ketthuc = a.ketthuc,
                            chitiettour = a.chitiettour,
                            giatour = a.giatour,
                            giam = x.giam,
                            batdaukm = x.batdau,
                            ketthuckm = x.kethuc,
                            giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                            tentour = a.tentour,
                            thoigian = a.thoigian,
                            socho = a.socho,
                            madd = a.madd,
                            hinhanh = a.hinhanh,
                            phuongtien = a.phuongtien
                        };
            return model.OrderByDescending(x => x.matour).ToPagedList(page, pageSize);
        }
        public bool CapNhatSoCho(int matour, int socho)
        {
            try
            {
                var tour = db.tblTOURs.Find(matour);
                tour.socho = tour.socho - socho;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<tblTOUR> GetTourGanDay(int top)
        {
            return db.tblTOURs.Where(x => x.khoihanh > DateTime.Today).OrderBy(x => x.khoihanh).Take(top).ToList();
        }

        public List<TourViewModel> SearchTour(int diemden, int giatour, string khoihanh)
        {
            
            double tu=0,den=0;
         
            if (khoihanh != "") { 
                dtkhoihanh = DateTime.Parse(khoihanh);
            }
            //var tour = db.tblTOURs.Find(6);
            //if (DateTime.Compare(dtkhoihanh, tour.khoihanh) == 0)
            //{
            //    tu = 2;
            //}
            switch (giatour)
            {
                case 1:
                    {
                        tu = 1000000;
                        den = 5000000;
                        break;
                    }
                case 2:
                    {
                        tu = 5000000;
                        den = 10000000;
                        break;
                    }
        
            }

            if (diemden != 0 && giatour!=0 && khoihanh!="")
            {
               var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                           where b.madd == diemden && tu <= a.giatour && a.giatour <= den && DateTime.Compare(dtkhoihanh, a.khoihanh)==0
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
               return model.OrderByDescending(x => x.matour).ToList();
            }

            if (diemden != 0 && giatour == 0 && khoihanh == "")
            {
                var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                            where b.madd == diemden
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
                return model.OrderByDescending(x => x.matour).ToList();
            }


            if (diemden == 0 && giatour != 0 && khoihanh == "")
            {
                var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                            where tu <= a.giatour && a.giatour <= den
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
                return model.OrderByDescending(x => x.matour).ToList();
            }

            if (diemden == 0 && giatour == 0 && khoihanh != "")
            {
                var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                            where DateTime.Compare(dtkhoihanh, a.khoihanh) == 0
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
                return model.OrderByDescending(x => x.matour).ToList();
            }

            if (diemden != 0 && giatour != 0 && khoihanh == "")
            {
                var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                            where b.madd == diemden && tu <= a.giatour && a.giatour <= den
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
                return model.OrderByDescending(x => x.matour).ToList();
            }

            if (diemden == 0 && giatour != 0 && khoihanh != "")
            {
                var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                            where tu <= a.giatour && a.giatour <= den && DateTime.Compare(dtkhoihanh, a.khoihanh) == 0
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
                return model.OrderByDescending(x => x.matour).ToList();
            }

            if (diemden != 0 && giatour == 0 && khoihanh != "")
            {
                var model = from a in db.tblTOURs
                            join b in db.tblDIEMDENs on a.madd equals b.madd
                            join c in db.tblKHUYENMAIs on a.matour equals c.matour into gj
                            from x in gj.DefaultIfEmpty()
                            where b.madd == diemden && DateTime.Compare(dtkhoihanh, a.khoihanh) == 0
                            select new TourViewModel()
                            {
                                matour = a.matour,
                                metatitle = a.metatitle,
                                khoihanh = a.khoihanh,
                                ketthuc = a.ketthuc,
                                chitiettour = a.chitiettour,
                                giatour = a.giatour,
                                giam = x.giam,
                                batdaukm = x.batdau,
                                ketthuckm = x.kethuc,
                                giakhuyenmai = a.giatour - (x.giam * a.giatour) / 100,
                                tentour = a.tentour,
                                thoigian = a.thoigian,
                                socho = a.socho,
                                madd = a.madd,
                                hinhanh = a.hinhanh,
                                phuongtien = a.phuongtien
                            };
                return model.OrderByDescending(x => x.matour).ToList();
            }


            return null;
        }
    }


}
