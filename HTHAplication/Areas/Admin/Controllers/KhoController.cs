using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class KhoController : Controller
    {
        // GET: Admin/Kho
        public ActionResult Index()
        {
            var dao = new KhoDao();
            var model = dao.ListAll();
            return View(model);
        }
    }
}