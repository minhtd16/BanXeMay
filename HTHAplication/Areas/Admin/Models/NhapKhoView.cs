using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EF;
namespace HTHAplication.Areas.Admin.Models
{
    public class NhapKhoView
    {
        public NhapHang chung_tu_nhap { get; set; }
        public List<ChiTietNhap> lst_CT_nhap { get; set; }
        public List<HangHoa> hang_hoa { get; set; }
    }
}