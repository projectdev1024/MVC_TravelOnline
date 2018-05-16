using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using System.Data.SqlClient;

namespace Models.DAO
{

    public class UserDao
    {
        TravelOnlineDbContext db = null;

        public UserDao()
        {
            db = new TravelOnlineDbContext();
        }

        public long Insert(tblADMIN entity)
        {
            db.tblADMINs.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public tblADMIN GetByID(string UserName)
        {
            return db.tblADMINs.SingleOrDefault(x=>x.taikhoan == UserName);
        }

        public int Login(string userName,string passWord)
        {
            var result = db.tblADMINs.SingleOrDefault(x => x.taikhoan == userName);
            if (result == null)
                return 0;
            else 
            {
                if (result.matkhau == passWord)
                    return 1;
                else return -2;

            }
        }
    }
}
