using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

using Models.EF;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class KhoController : Controller
    {
        private HTHApplicationDbContext db = new HTHApplicationDbContext();
        // GET: Admin/Kho
        public ActionResult Index()
        {
            var dao = new KhoDao();
            var model = dao.ListAll();
            return View(model);
        }      

        // GET: Admin/Khoes/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kho entity)
        {
            var dao = new KhoDao();
            dao.Insert(entity);
            return RedirectToAction("Index");
        }

        // GET: Admin/Khoes/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new KhoDao();          
            var model = dao.GetByID(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kho entity)
        {
            var dao = new KhoDao();

            if(dao.Update(entity))
            {
                return RedirectToAction("Index");
            }
            else
            {                
                return View(entity);
            }       
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new KhoDao();
            var model = dao.GetByID(id);
            if (model != null)
            {
                dao.Delete(model);
            }
            return RedirectToAction("Index");         
        }
    }
}