using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class KhachHangDAO
    {
        TravelOnlineDbContext db = null;
        public KhachHangDAO()
        {
            db = new TravelOnlineDbContext();
        }

        public long Insert(tblKHACHHANG entity)
        {
            
            db.tblKHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.makh;
        }

        public bool Update(tblKHACHHANG entity)
        {
            try
            {
                var khachHang = db.tblKHACHHANGs.Find(entity.makh);
                if (!string.IsNullOrEmpty(entity.matkhau))
                {
                    khachHang.matkhau = entity.matkhau;
                }
                khachHang.hoten = entity.hoten;
                khachHang.ngaysinh = entity.ngaysinh;
                khachHang.diachi = entity.diachi;
                khachHang.dienthoai = entity.dienthoai;
                khachHang.email = entity.email;
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }        
        }

        public int kiemTraTaiKhoan(string userName)
        {
            var taikhoan = db.tblKHACHHANGs.Count(x => x.taikhoan == userName);
            if (taikhoan > 0)
                return 1;
            else
            {       
                return 0;
            }
        }

        public int kiemTraEmail(string email)
        {
            var ktrEmail = db.tblKHACHHANGs.Count(x => x.email == email);
            if (ktrEmail > 0)
                return 1;
            else
            {
                return 0;
            }
        }
        public IEnumerable<tblKHACHHANG> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<tblKHACHHANG> model = db.tblKHACHHANGs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.taikhoan.Contains(searchString) || x.hoten.Contains(searchString));
            }
            return model.OrderByDescending(x => x.makh).ToPagedList(page, pageSize);
        }

        public tblKHACHHANG ViewDetail (int id)
        {
            return db.tblKHACHHANGs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.tblKHACHHANGs.Find(id);
                db.tblKHACHHANGs.Remove(user);
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public int Login(string userName, string passWord)
        {
            var result = db.tblKHACHHANGs.SingleOrDefault(x => x.taikhoan == userName);
            if (result == null)
                return 0;
            else
            {
                if (result.matkhau == passWord)
                    return 1;
                else return -2;

            }
        }

        public tblKHACHHANG GetByID(string UserName)
        {
            return db.tblKHACHHANGs.SingleOrDefault(x => x.taikhoan == UserName);
        }

        public bool kiemTraTaiKhoanEmail(string taikhoan,string email)
        {
            var result = db.tblKHACHHANGs.Count(x => x.email == email && x.taikhoan==taikhoan);
            if (result > 0)
                return true;
            else
            {
                return false;
            }
        }

        //Thêm rd code
        public bool UpdateRDCode(string taikhoan,string rdcode)
        {
            try
            {
                var khachHang = db.tblKHACHHANGs.Where(x=>x.taikhoan==taikhoan).SingleOrDefault();
                khachHang.rdcode = rdcode;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool KiemTraTaiKhoanEmailRDCode(string taikhoan,string email, string rdcode)
        {
            try
            {
                var khachHang = db.tblKHACHHANGs.Where(x => x.taikhoan == taikhoan && x.email==email && x.rdcode==rdcode).SingleOrDefault();
                khachHang.rdcode = rdcode;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CapNhatMatKhau(string taikhoan, string matkhau,string rdcode)
        {
            try
            {
                var khachHang = db.tblKHACHHANGs.Where(x => x.taikhoan == taikhoan).SingleOrDefault();
                khachHang.rdcode = rdcode;
                khachHang.matkhau = matkhau;
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
