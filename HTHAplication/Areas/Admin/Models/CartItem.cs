using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EF;
namespace HTHAplication.Areas.Admin.Models
{
    [Serializable]
    public class CartItem
    {
        public  HangHoa hanghoa{get;set;}
        public int SoLuong{get;set;}
        public int DonGia { get; set; }

    }
}