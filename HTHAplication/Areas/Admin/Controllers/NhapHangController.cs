using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTHAplication.Areas.Admin.Models;
using Models.Dao;
using Models.EF;
using HTHApplication.Common;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: Admin/NhapHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhapTuNCC()
        {
            var daoID = new CauHinhIDDao();
            var id = daoID.GetValueByID("NH");
            string ma_chung_tu = CommonFunction.GeneratedID("NH", id.Value+1);
            NhapKhoView model = new NhapKhoView() { chung_tu_nhap = new NhapHang() { IDNhap = ma_chung_tu, CreatedDate = DateTime.Now, LoaiGiaoDichID = 3 } };
            return View(model);
        }
    }
}