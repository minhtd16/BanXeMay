using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.Dao;
using Models.EF;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class GioiTinhController : Controller
    {
        private HTHApplicationDbContext db = new HTHApplicationDbContext();
        // GET: Admin/GioiTinh
        public ActionResult Index()
        {
            var dao = new GioiTinhDao();
            var model = dao.ListAll();
            return View(model);
        }
    }
}