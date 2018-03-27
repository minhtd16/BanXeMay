using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
namespace HTHAplication.Areas.Admin.Controllers
{
    public class LoaiMatHangController : BaseController
    {
        // GET: Admin/LoaiMatHang
        public ActionResult Index()
        {
            var dao = new LoaiMatHangDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            var dao =new LoaiMatHangDao();
            var model = dao.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(LoaiMatHang entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiMatHangDao();
                if (dao.Insert(entity))
                {
                    SetAlert("Thêm thành công!", "success");
                }
                else
                {
                    SetAlert("Lỗi thêm hàng hóa!", "error");
                }
            }
            else
            {
                SetAlert("Lỗi thêm hàng hóa!", "error");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(LoaiMatHang entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiMatHangDao();
               if (dao.Update(entity))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Lỗi cập nhật chủng loại!", "error");
                    return View(entity);
                }
            }
            else
            {
                SetAlert("Lỗi cập nhật chủng loại!", "error");
                return View(entity);
            }
            
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new LoaiMatHangDao();
            var model = dao.GetByID(id);
            if (model != null)
            {
                dao.Delete(model);
            }
            return RedirectToAction("Index");
        }
    }
}