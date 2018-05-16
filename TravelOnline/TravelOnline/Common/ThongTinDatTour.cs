using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelOnline.Common
{
    [Serializable]
    public class ThongTinDatTour
    {
        public int matour { get; set; }
        public int? songuoilon { get; set; }
        public int? sotreem { get; set; }
        public string hoten { get; set; }
        public string cmt { get; set; }
        public string diachi { get; set; }
        public string dienthoai { get; set; }
        public string email { get; set; }
        public double tongtien { get; set; }
        public DateTime? ngaydattour { get; set; }
    }
}