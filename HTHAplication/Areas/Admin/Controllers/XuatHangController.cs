using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using HTHApplication.Common;
using HTHAplication.Areas.Admin.Models;
using HTHAplication.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class XuatHangController : BaseController
    {
        // GET: Admin/XuatHang
        public ActionResult Index()
        {
            var daoID = new CauHinhIDDao();
            var id = daoID.GetValueByID("BH");
            string ma_chung_tu = CommonFunction.GeneratedID("BH", id.Value + 1);
            XuatKhoView model = new XuatKhoView() { chung_tu_xuat = new XuatHang() { IDXuat = ma_chung_tu, CreatedDate = DateTime.Now, LoaiGiaoDichID = 1 } };
            return View(model);

        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetKhoByHangId(string mahh)
        {
            var dao = new KhoHangDao();
            List<KhoHang> objkho = new List<KhoHang>();
            objkho = dao.GetByMaHH(mahh);
            List<Kho> lst_kho = new List<Kho>();

            for (int i = 0; i < objkho.Count; i++)
            {
                Kho obj = new Kho();
                obj.ID = objkho[i].MaKho.Value;
                obj.Ten = objkho[i].Kho.Ten;
                lst_kho.Add(obj);
            }

            SelectList obgkho = new SelectList(lst_kho, "Id", "Ten", 0);
            return Json(obgkho);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetQuantityProduct(int makho, string mahh)
        {
            bool success = true;
            string soluong = "";
            try
            {
                var dao = new KhoHangDao();
                soluong = dao.GetQuantity(makho, mahh);
                success = true;

            }
            catch (Exception e)
            {
                success = false;
                soluong = "0";
            }
            return Json(new
            {
                success = success,
                soluong = soluong
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreatePXK(string khach_hang, string sdt, string dia_chi, string ngay_xuat, string ma,
            string thu_kho, string nguoi_lap_phieu, string dien_giai, string tong_tien)
        {
            bool success = true;
            string message = "Kết quả: Tạo phiếu xuất kho thành công!";
            //Thêm khách hàng
            var daoKH = new KhachHangDao();
            KhachHang obj_kh = new KhachHang();
            obj_kh.TenKH = khach_hang;
            obj_kh.SDT = sdt;
            obj_kh.DiaChi = dia_chi;
            obj_kh.CreatedDate = DateTime.Now;
            obj_kh.Status = true;
            obj_kh.CreateBy = Session["UserName"].ToString();
            int ma_kh = -1;
            try
            {
                ma_kh = daoKH.Insert(obj_kh);

            }
            catch (Exception ex)
            {
                success = false;
                message = "Kết quả: " + ex.ToString() + ".";
            }
            if (ma_kh != -1)
            {
                //Thêm phiếu xuất hàng
                var dao = new XuatHangDao();
                var daoID = new CauHinhIDDao();
                XuatHang obj = new XuatHang();
                obj.IDXuat = ma;
                obj.KhachHang = ma_kh;
                obj.NgayXuat = DateTime.ParseExact(ngay_xuat, "dd/MM/yyyy", null);
                obj.ThuKho = thu_kho;
                obj.NguoiLapPhieu = nguoi_lap_phieu;
                obj.DienGiai = dien_giai;
                obj.LoaiGiaoDichID = 1;
                obj.TongTien = decimal.Parse(tong_tien);
                obj.CreatedDate = DateTime.Now;
                obj.CreateBy = Session["UserName"].ToString();
                obj.TrangThai = 1;

                try
                {
                    dao.Insert(obj);
                    daoID.Update("BH");
                }
                catch (Exception ex)
                {
                    success = false;
                    message = "Kết quả: " + ex.ToString() + ".";
                }
            }
            return Json(new
            {
                success = success,
                message = message
            });

        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateCT_PXK(string ma_pxk, string ma_hang_s, string ma_kho_s, string so_luong_s, string don_gia_s)
        {
            bool success = true;
            string message = "Kết quả: Hoàn thành việc nhập kho!";
            var daoCT = new ChiTietXuatDao();
            var daoHH = new HangHoaDao();
            var daoKho = new KhoHangDao();
            string[] lst_ma_hang = ma_hang_s.Split(',');
            string[] lst_so_luong = so_luong_s.Split(',');
            string[] lst_don_gia = don_gia_s.Split(',');
            string[] lst_ma_kho = ma_kho_s.Split(',');
            try
            {
                for (int i = 0; i < lst_ma_hang.Length; i++)
                {
                    ChiTietXuat obj = new ChiTietXuat();
                    obj.XuatID = ma_pxk;
                    obj.MaHH = lst_ma_hang[i].ToString();
                    obj.SoLuong = int.Parse(lst_so_luong[i].ToString());
                    obj.DonGia = decimal.Parse(lst_don_gia[i].ToString());
                    obj.MaKho = int.Parse(lst_ma_kho[i].ToString());
                    obj.CreatedDate = DateTime.Now;
                    obj.CreateBy = Session["UserName"].ToString();
                    obj.ThanhTien = decimal.Parse(lst_don_gia[i].ToString()) * int.Parse(lst_so_luong[i].ToString());

                    daoCT.Insert(obj);
                    daoHH.XuatHang(lst_ma_hang[i].ToString(), int.Parse(lst_so_luong[i].ToString()),
                        decimal.Parse(lst_don_gia[i].ToString()), Session["UserName"].ToString());

                    daoKho.BanHang(int.Parse(lst_ma_kho[i].ToString()),
                        lst_ma_hang[i].ToString(), int.Parse(lst_so_luong[i].ToString()));

                }


            }
            catch (Exception ex)
            {
                success = false;
                message = "Kết quả: " + ex.ToString() + ".";
            }

            return Json(new
            {
                success = success,
                message = message
            });
        }
        // POST: /XuatKho/PostExport

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult PostExport(string ma)
        {

            bool success = true;
            string message = "Kết quả: Xuất báo cáo thành công.";

            try
            {
                var daoNH = new XuatHangDao();
                XuatHang obj_PXK = daoNH.GetByID(ma);
                List<ChiTietXuat> lst_CT_PXK = obj_PXK.ChiTietXuats.OrderBy(obj => (obj.ID)).ToList();
                List<DT_XuatKho> lst_DT_XK = new List<DT_XuatKho>();

                for (int i = 0; i < lst_CT_PXK.Count; i++)
                {
                    DT_XuatKho obj_DT_XK = new DT_XuatKho();

                    obj_DT_XK.STT = (i + 1).ToString();
                    obj_DT_XK.Mat_Hang = lst_CT_PXK.ElementAt(i).HangHoa.TenHH.ToString();
                    obj_DT_XK.So_Luong = lst_CT_PXK.ElementAt(i).SoLuong.ToString();
                    obj_DT_XK.DVT = lst_CT_PXK.ElementAt(i).HangHoa.DonViTinh.Ten;
                    obj_DT_XK.Don_Gia = lst_CT_PXK.ElementAt(i).DonGia.ToString();
                    obj_DT_XK.Ma_Kho = lst_CT_PXK.ElementAt(i).MaKho.ToString();
                    obj_DT_XK.Thanh_Tien = (int.Parse(obj_DT_XK.So_Luong) * double.Parse(obj_DT_XK.Don_Gia)).ToString();

                    lst_DT_XK.Add(obj_DT_XK);
                }

                System.Web.HttpContext.Current.Session["Khach_Hang"] = obj_PXK.KhachHang1.TenKH;
                System.Web.HttpContext.Current.Session["SDT"] = obj_PXK.KhachHang1.SDT;
                System.Web.HttpContext.Current.Session["Dia_Chi"] = obj_PXK.KhachHang1.DiaChi;
                System.Web.HttpContext.Current.Session["Thu_Kho"] = obj_PXK.ThuKho;
                System.Web.HttpContext.Current.Session["Nguoi_Lap"] = obj_PXK.NguoiLapPhieu;
                System.Web.HttpContext.Current.Session["Dien_Giai"] = obj_PXK.DienGiai;
                System.Web.HttpContext.Current.Session["So_CT"] = obj_PXK.IDXuat;                
                System.Web.HttpContext.Current.Session["Ngay_HT"] = obj_PXK.NgayXuat.Value.Day.ToString() + "/" + obj_PXK.NgayXuat.Value.Month.ToString() + "/" + obj_PXK.NgayXuat.Value.Year.ToString();
                System.Web.HttpContext.Current.Session["Tong_Tien"] = String.Format("{0:0,0}", obj_PXK.TongTien.Value);
                System.Web.HttpContext.Current.Session["Tien_Chu"] = CommonFunction.ConvertCurrency(obj_PXK.TongTien.Value);
                System.Web.HttpContext.Current.Session["Data_Source"] = lst_DT_XK;
            }
            catch (Exception ex)
            {
                success = false;
                message = "Kết quả: " + ex.ToString() + ".";
            }

            return Json(new
            {
                success = success,
                message = message
            });

        }

        // GET: /NhapKho/GetExport

        [HttpGet]
        [ValidateInput(false)]
        public void GetExport()
        {
            string khach_hang = System.Web.HttpContext.Current.Session["Khach_Hang"].ToString();
            string sdt = System.Web.HttpContext.Current.Session["SDT"].ToString();
            string dia_chi = System.Web.HttpContext.Current.Session["Dia_Chi"].ToString();
            string thu_kho = System.Web.HttpContext.Current.Session["Thu_Kho"].ToString();
            string nguoi_lap = System.Web.HttpContext.Current.Session["Nguoi_Lap"].ToString();
            string dien_giai = System.Web.HttpContext.Current.Session["Dien_Giai"].ToString();
            string so_ct = System.Web.HttpContext.Current.Session["So_CT"].ToString();
            string ngay_ht = System.Web.HttpContext.Current.Session["Ngay_HT"].ToString();
            string tong_tien = System.Web.HttpContext.Current.Session["Tong_Tien"].ToString();
            string tien_chu = System.Web.HttpContext.Current.Session["Tien_Chu"].ToString();
            var data_source = System.Web.HttpContext.Current.Session["Data_Source"];

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/") + "/Reports/CR-XuatKho.rpt");

            rd.SetDataSource(data_source);
            rd.SetParameterValue("khach_hang", khach_hang);
            rd.SetParameterValue("sdt", sdt);
            rd.SetParameterValue("dia_chi", dia_chi);
            rd.SetParameterValue("thu_kho", thu_kho);
            rd.SetParameterValue("nguoi_lap", nguoi_lap);
            rd.SetParameterValue("dien_giai", dien_giai);
            rd.SetParameterValue("so_ct", so_ct);
            rd.SetParameterValue("ngay_ht", ngay_ht);
            rd.SetParameterValue("tong_tien", tong_tien);
            rd.SetParameterValue("tien_chu", tien_chu);

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "CR-NhapKho");

            System.Web.HttpContext.Current.Session["Khach_Hang"] = null;
            System.Web.HttpContext.Current.Session["SDT"] = null;
            System.Web.HttpContext.Current.Session["Dia_Chi"] = null;
            System.Web.HttpContext.Current.Session["Thu_Kho"] = null;
            System.Web.HttpContext.Current.Session["Nguoi_Lap"] = null;
            System.Web.HttpContext.Current.Session["Dien_Giai"] = null;
            System.Web.HttpContext.Current.Session["So_CT"] = null;
            System.Web.HttpContext.Current.Session["Ngay_HT"] = null;
            System.Web.HttpContext.Current.Session["Tong_Tien"] = null;
            System.Web.HttpContext.Current.Session["Tien_Chu"] = null;
            System.Web.HttpContext.Current.Session["Data_Source"] = null;

        }
    }
}