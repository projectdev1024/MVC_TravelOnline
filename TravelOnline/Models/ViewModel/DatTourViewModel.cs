using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DatTourViewModel
    {
        public int madattour { get; set; }
        public int matour { get; set; }
        public string tentour { get; set; }
        public DateTime ngaykhoihanh { get; set; }
        public DateTime ngayketthuc { get; set; }
        public DateTime ngaydattour { get; set; }
        public int? songuoilon { get; set; }
        public int? sotreem { get; set; }
        public int? makh { get; set; }
        public string hoten { get; set; }
        public string cmt { get; set; }
        public string diachi { get; set; }
        public string dienthoai { get; set; }
        public string email { get; set; }
        public double tongtien { get; set; }
        public bool? dathanhtoan { get; set; }
    }
}
