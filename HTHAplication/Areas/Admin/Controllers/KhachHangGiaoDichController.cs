using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.EF;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class KhachHangGiaoDichController : Controller
    {
        private HTHApplicationDbContext db = new HTHApplicationDbContext();

        // GET: Admin/KhachHangGiaoDichDaoTM
        public ActionResult Index()
        {
            return View(db.KhachHangGiaoDiches.ToList());
        }

        // GET: Admin/KhachHangGiaoDich
       
    }
}