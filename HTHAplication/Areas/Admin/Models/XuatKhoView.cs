using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EF;
namespace HTHAplication.Areas.Admin.Models
{
    public class XuatKhoView
    {
        public XuatHang chung_tu_xuat { get; set; }
        public List<ChiTietXuat> lst_CT_xuat { get; set; }
        public List<HangHoa> hang_hoa { get; set; }
    }
}