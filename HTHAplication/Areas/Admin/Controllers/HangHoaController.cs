using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTHApplication.Common;
using Models.Dao;
using Models.EF;
namespace HTHAplication.Areas.Admin.Controllers
{
    public class HangHoaController : BaseController
    {

        // GET: Admin/HangHoa

        public ActionResult Index(string masp, int page = 1, int pageSize = 9)
        {
            var dao = new HangHoaDao();
            var model = dao.ListAllPaging(masp, page, pageSize);
            ViewBag.masp = masp;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetLoaiMH();
            SetMauSac();
            SetNuocSanXuat();
            SetDVT();
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new HangHoaDao();
            var model = dao.GetByID(id);
            if (model != null)
            {
                dao.Delete(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new HangHoaDao();
            var model = dao.GetByID(id);
            if (model != null)
            {
                SetLoaiMH(model.MaHH);
                SetMauSac(model.MauID);
                SetNuocSanXuat(model.NuocSXID);
                SetDVT(model.DVT);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(HangHoa entity)
        {
            SetLoaiMH();
            SetMauSac();
            SetNuocSanXuat();
            SetDVT();
            if (ModelState.IsValid)
            {
                var dao = new HangHoaDao();
                var cauhinhID = new CauHinhIDDao();
                var chID = cauhinhID.GetValueByID(entity.LoaiMH);
                string maHH = CommonFunction.GenerateMaHang(entity.LoaiMH, chID.Value + 1);
                entity.MaHH = maHH;
                entity.SoLuong = 0;
                entity.Status = true;
                entity.CreatedDate = DateTime.Now;
                if (entity.Anh == null)
                {
                    entity.Anh = "/Data/images/no-image.jpg";
                }
                entity.CreateBy = Session["UserName"].ToString();
                dao.Insert(entity);
                cauhinhID.Update(entity.LoaiMH);//Tăng biến đếm
                SetAlert("Thêm hàng hóa thành công!", "success");
            }
            else
            {
                SetAlert("Lỗi thêm hàng hóa!", "error");
            }
            return View();

        }
        [HttpPost]
        public ActionResult Edit(HangHoa entity)
        {
            SetLoaiMH(entity.MaHH);
            SetMauSac(entity.MauID);
            SetNuocSanXuat(entity.NuocSXID);
            SetDVT(entity.DVT);
            if (ModelState.IsValid)
            {
                var dao = new HangHoaDao();
                entity.ModifiedBy = Session["UserName"].ToString();
                if (dao.Update(entity))
                {
                   return RedirectToAction("Index");                    
                }
                else
                {
                    SetAlert("Lỗi cập nhật hàng hóa!", "error");
                    return View(entity);
                }
            }
            else
            {
                SetAlert("Lỗi cập nhật hàng hóa!", "error");
                return View(entity);
            }


        }

        public void SetLoaiMH(string selectedId = null)
        {
            var dao = new LoaiMatHangDao();
            ViewBag.LoaiMH = new SelectList(dao.ListAll(), "ID", "Ten", selectedId);
        }
        public void SetNuocSanXuat(int? selectedId = null)
        {
            var dao = new NuocSanXuatDao();
            ViewBag.NuocSXID = new SelectList(dao.ListALl(), "ID", "Ten", selectedId);
        }
        public void SetMauSac(int? selectedId = null)
        {
            var dao = new MauSacDao();
            ViewBag.MauID = new SelectList(dao.ListAll(), "ID", "Ten", selectedId);
        }
        public void SetDVT(int? selectedId = null)
        {
            var dao = new DonViTinhDao();
            ViewBag.DVT = new SelectList(dao.ListAll(), "ID", "Ten", selectedId);
        }
    }
}