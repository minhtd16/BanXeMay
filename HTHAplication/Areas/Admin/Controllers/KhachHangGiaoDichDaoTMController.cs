using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class KhachHangGiaoDichDaoTMController : Controller
    {
        private HTHApplicationDbContext db = new HTHApplicationDbContext();

        // GET: Admin/KhachHangGiaoDichDaoTM
        public ActionResult Index()
        {
            return View(db.KhachHangGiaoDiches.ToList());
        }

        // GET: Admin/KhachHangGiaoDichDaoTM/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHangGiaoDich khachHangGiaoDich = db.KhachHangGiaoDiches.Find(id);
            if (khachHangGiaoDich == null)
            {
                return HttpNotFound();
            }
            return View(khachHangGiaoDich);
        }

        // GET: Admin/KhachHangGiaoDichDaoTM/Create
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DonHangID,KhachHangID,NgayGiaoDich,TongTien,SoLuong,TrangThai")] KhachHangGiaoDich khachHangGiaoDich)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangGiaoDiches.Add(khachHangGiaoDich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHangGiaoDich);
        }

        // GET: Admin/KhachHangGiaoDichDaoTM/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHangGiaoDich khachHangGiaoDich = db.KhachHangGiaoDiches.Find(id);
            if (khachHangGiaoDich == null)
            {
                return HttpNotFound();
            }
            return View(khachHangGiaoDich);
        }

        // POST: Admin/KhachHangGiaoDichDaoTM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DonHangID,KhachHangID,NgayGiaoDich,TongTien,SoLuong,TrangThai")] KhachHangGiaoDich khachHangGiaoDich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHangGiaoDich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHangGiaoDich);
        }

        // GET: Admin/KhachHangGiaoDichDaoTM/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHangGiaoDich khachHangGiaoDich = db.KhachHangGiaoDiches.Find(id);
            if (khachHangGiaoDich == null)
            {
                return HttpNotFound();
            }
            return View(khachHangGiaoDich);
        }

        // POST: Admin/KhachHangGiaoDichDaoTM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            KhachHangGiaoDich khachHangGiaoDich = db.KhachHangGiaoDiches.Find(id);
            db.KhachHangGiaoDiches.Remove(khachHangGiaoDich);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
