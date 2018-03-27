using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
namespace HTHAplication.Areas.Admin.Controllers
{
    public class MauSacController : Controller
    {
        // GET: Admin/MauSac
        public ActionResult Index()
        {
            var dao = new MauSacDao();
            var model = dao.LayTatCa();
            return View(model);
        }
        public ActionResult Create(MauSac mausac )
        {
            var dao = new MauSacDao();
            dao.Insert(mausac);
            return View();
        }

    }
}