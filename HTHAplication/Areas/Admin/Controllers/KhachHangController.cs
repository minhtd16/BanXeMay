using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        private HTHApplicationDbContext db = new HTHApplicationDbContext();
        // GET: Admin/KhachHang

        //public ActionResult Index()
        //{
        //    var dao = new KhachHangDao();
        //    var model = dao.ListAll();
        //    return View(model);
        //}
        public ActionResult Index(string tenkh, int page = 1, int pageSize = 5)
        {
            var dao = new KhachHangDao();
            var model = dao.ListAllPaging(tenkh, page, pageSize);
            ViewBag.tenkh = tenkh;
            return View(model);
        }

        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        public void loaiKH(int? selectedId = null)
        {
            var dao = new LoaiKhachHangDao();
            ViewBag.LoaiKH = new SelectList(dao.ListAll(), "ID", "Ten", selectedId);
        }
        public void gTinh(int? selectedId = null)
        {
            var dao = new GioiTinhDao();
            ViewBag.GioiTinh = new SelectList(dao.ListAll(), "iD", "tenGT", selectedId);
        }
        public ActionResult Create()
        {
            loaiKH();
            gTinh();
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang entity)
        {

            if (ModelState.IsValid)
            {
                gTinh();
                loaiKH();
                entity.CreatedDate = DateTime.Now;
                entity.CreateBy = Session["UserName"].ToString();
                entity.Status = true;
                db.KhachHangs.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
                //   return View();
            }
            else
                return View(entity);
        }
            
        public ActionResult Edit(int id)
        {
            var dao = new KhachHangDao();
            loaiKH();
            gTinh();
            var model = dao.GetByID(id);
            return View(model);
        }      
        [HttpPost]

        public ActionResult Edit(KhachHang entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                loaiKH();
                gTinh();
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Session["UserName"].ToString();
                entity.Status = true;

                if (dao.Update(entity))
                {
                    return RedirectToAction("Index");
                }
                else
                {                   
             //       SetAlert("Lỗi cập nhật chủng loại!", "error");
                    return View(entity);
                }
            }
            else
            {
              //  SetAlert("Lỗi cập nhật chủng loại!", "error");
                return View(entity);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new KhachHangDao();
            var model = dao.GetByID(id);
            if (model != null)
            {
                dao.Delete(model);
            }
            return RedirectToAction("Index");
        }

    }
}