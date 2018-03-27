using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}