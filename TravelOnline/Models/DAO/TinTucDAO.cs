using Models.EF;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Text.RegularExpressions;

namespace Models.DAO
{
    public class TinTucDAO
    {
        TravelOnlineDbContext db = null;
        public TinTucDAO()
        {
            db = new TravelOnlineDbContext();
        }

        public long Insert(tblTINTUC entity)
        {
            entity.ngaydang = DateTime.Today;
            entity.metatitle = ToAscii(entity.tieude);
            db.tblTINTUCs.Add(entity);
            db.SaveChanges();
            return entity.matin;
        }
        public IEnumerable<tblTINTUC> ListAllPaging(int page, int pageSize)
        {
            return db.tblTINTUCs.OrderByDescending(x => x.matin).ToPagedList(page, pageSize);
        }

        public tblTINTUC ViewDetail(int id)
        {
            return db.tblTINTUCs.Find(id);
        }

        public bool Update(tblTINTUC entity)
        {
            try
            {
                var tintuc = db.tblTINTUCs.Find(entity.matin);
                tintuc.tieude = entity.tieude;
                tintuc.metatitle = ToAscii(entity.tieude);
                tintuc.tomtat = entity.tomtat;
                tintuc.noidung = entity.noidung;
                tintuc.hinhanh = entity.hinhanh;
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
                var tintuc = db.tblTINTUCs.Find(id);
                db.tblTINTUCs.Remove(tintuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<tblTINTUC> ListNews(int top)
        {
            return db.tblTINTUCs.OrderByDescending(x => x.matin).Take(top).ToList();
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

        public IEnumerable<tblTINTUC> ListAll(int page, int pageSize)
        {
            var model =  db.tblTINTUCs.OrderByDescending(x=>x.ngaydang).ToPagedList(page, pageSize);
            return model;
        }
    }
}
