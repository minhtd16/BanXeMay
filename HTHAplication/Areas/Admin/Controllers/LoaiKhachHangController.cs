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
    }
}