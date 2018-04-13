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
        private HTHApplicationDbContext db = new HTHApplicationDbContext();

        // GET: Admin/MauSac
        public ActionResult Index()
        {
            var dao = new MauSacDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MauSac mausac)
        {
            var dao = new MauSacDao();
            dao.Insert(mausac);
            return View();
        }
        public ActionResult Edit(int id)
        {
            var dao = new MauSacDao();
            var model = dao.GetByID(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MauSac entity)
        {
            var dao = new MauSacDao();
            dao.Edit(entity);          
            return View(entity);          
        }
    }
}