using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;

namespace HTHAplication.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            var _dsKH = new KhachHangDao();
            var model = _dsKH.ListAll();
            return View(model);
        }
    }
}