using Models.EF;
using Models.Dao;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class LoaiKhachHangController : Controller
    {
        // GET: Admin/LoaiKhachHang
        private HTHApplicationDbContext db = new HTHApplicationDbContext();
        public ActionResult Index()
        {
            var dao = new LoaiKhachHangDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiKhachHang entity)
        {
            if (ModelState.IsValid)
            {
                db.LoaiKhachHangs.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
                //   return View();
            }
            else
                return View(entity);       
                //   return View();
        }

        public ActionResult Edit(int id)
        {
            var dao = new LoaiKhachHangDao();
            var model = dao.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(LoaiKhachHang entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiKhachHangDao();
                if (dao.Update(entity))
                {
                    return RedirectToAction("Index");
                }
                else
                {               
                    return View(entity);
                }
            }
            else
            {
                return View(entity);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new LoaiKhachHangDao();
            var model = dao.GetByID(id);
            if (model != null)
            {
                dao.Delete(model);
            }
            return RedirectToAction("Index");
        }
    }
}