using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTHAplication.Areas.Admin.Models;
using Models.Dao;
using Models.EF;
using HTHApplication.Common;
using HTHAplication.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: Admin/NhapHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhapTuNCC()
        {
            var daoID = new CauHinhIDDao();
            var id = daoID.GetValueByID("NH");
            string ma_chung_tu = CommonFunction.GeneratedID("NH", id.Value + 1);
            NhapKhoView model = new NhapKhoView() { chung_tu_nhap = new NhapHang() { IDNhap = ma_chung_tu, CreatedDate = DateTime.Now, LoaiGiaoDichID = 3 } };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreatePNK(string ma, string ngay_nhap, string ma_ncc, string nguoi_lap_phieu, string nguoi_giao, string dien_giai, string tong_tien)
        {
            bool success = true;
            string message = "Kết quả: Tạo phiếu nhập kho thành công!";
            var dao = new NhapHangDao();
            var daoID = new CauHinhIDDao();
            NhapHang obj = new NhapHang();
            obj.IDNhap = ma;
            obj.NgayNhap = DateTime.ParseExact(ngay_nhap, "dd/MM/yyyy", null);
            obj.DoiTac = int.Parse(ma_ncc);
            obj.NguoiLapPhieu = nguoi_lap_phieu;
            obj.NguoiGiaoHang = nguoi_giao;
            obj.DienGiai = dien_giai;
            obj.LoaiGiaoDichID = 3;
            obj.TongTien = decimal.Parse(tong_tien);
            obj.CreatedDate = DateTime.Now;
            obj.CreateBy = Session["UserName"].ToString();
            obj.TrangThai = 1;

            try
            {
                dao.Insert(obj);
                daoID.Update("NH");
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

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateCT_PNK(string ma_pnk, string ma_hang_s, string ma_kho_s, string so_luong_s, string don_gia_s)
        {
            bool success = true;
            string message = "Kết quả: Hoàn thành việc nhập kho!";
            var daoCT = new ChiTietNhapDao();
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
                    ChiTietNhap obj = new ChiTietNhap();
                    obj.NhapID = ma_pnk;
                    obj.MaHH = lst_ma_hang[i].ToString();
                    obj.SoLuong = int.Parse(lst_so_luong[i].ToString());
                    obj.DonGia = decimal.Parse(lst_don_gia[i].ToString());
                    obj.MaKho = int.Parse(lst_ma_kho[i].ToString());
                    obj.CreatedDate = DateTime.Now;
                    obj.CreateBy = Session["UserName"].ToString();
                    obj.TongTien = decimal.Parse(lst_don_gia[i].ToString()) * int.Parse(lst_so_luong[i].ToString());

                    daoCT.Insert(obj);
                    daoHH.NhapHang(lst_ma_hang[i].ToString(), int.Parse(lst_so_luong[i].ToString()), 
                        decimal.Parse(lst_don_gia[i].ToString()), Session["UserName"].ToString());
                    if (daoKho.CheckKho(int.Parse(lst_ma_kho[i].ToString()), lst_ma_hang[i].ToString()))
                    {
                        daoKho.NhapThemHang(int.Parse(lst_ma_kho[i].ToString()), 
                            lst_ma_hang[i].ToString(), int.Parse(lst_so_luong[i].ToString()));
                    }
                    else
                    {
                        KhoHang kho_hang = new KhoHang();
                        kho_hang.MaKho = int.Parse(lst_ma_kho[i].ToString());
                        kho_hang.MaHH = lst_ma_hang[i].ToString();
                        kho_hang.SoLuong = int.Parse(lst_so_luong[i].ToString());
                        daoKho.Insert(kho_hang);
                    }
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

        // POST: /NhapKho/PostExport

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult PostExport(string ma)
        {

            bool success = true;
            string message = "Kết quả: Xuất báo cáo thành công.";

            try
            {
                var daoNH = new NhapHangDao();
                NhapHang obj_PNK = daoNH.GetById(ma);
                List<ChiTietNhap> lst_CT_PNK = obj_PNK.ChiTietNhaps.OrderBy(obj => (obj.ID)).ToList();
                List<DT_NhapKho> lst_DT_NK = new List<DT_NhapKho>();

                for (int i = 0; i < lst_CT_PNK.Count; i++)
                {
                    DT_NhapKho obj_DT_NK = new DT_NhapKho();

                    obj_DT_NK.STT = (i + 1).ToString();
                    obj_DT_NK.Mat_Hang = lst_CT_PNK.ElementAt(i).HangHoa.TenHH.ToString();
                    obj_DT_NK.So_Luong = lst_CT_PNK.ElementAt(i).SoLuong.ToString();
                    obj_DT_NK.DVT = lst_CT_PNK.ElementAt(i).HangHoa.DonViTinh.Ten;
                    obj_DT_NK.Don_Gia = lst_CT_PNK.ElementAt(i).DonGia.ToString();
                    obj_DT_NK.Ma_Kho = lst_CT_PNK.ElementAt(i).MaKho.ToString();
                    obj_DT_NK.Thanh_Tien = (int.Parse(obj_DT_NK.So_Luong) * double.Parse(obj_DT_NK.Don_Gia)).ToString();

                    lst_DT_NK.Add(obj_DT_NK);
                }

                System.Web.HttpContext.Current.Session["Ma_NCC"] = obj_PNK.NhaCungCap.MaNCC;
                System.Web.HttpContext.Current.Session["Ten_NCC"] = obj_PNK.NhaCungCap.CongTy;
                System.Web.HttpContext.Current.Session["Dia_Chi_NCC"] = obj_PNK.NhaCungCap.DiaChi;
                System.Web.HttpContext.Current.Session["Nguoi_Giao"] = obj_PNK.NguoiGiaoHang;
                System.Web.HttpContext.Current.Session["Nguoi_Lap"] = obj_PNK.NguoiLapPhieu;
                System.Web.HttpContext.Current.Session["Dien_Giai"] = obj_PNK.DienGiai;
                System.Web.HttpContext.Current.Session["So_CT"] = obj_PNK.IDNhap;
                System.Web.HttpContext.Current.Session["SDT_NCC"] = obj_PNK.NhaCungCap.DienThoai.ToString();
                System.Web.HttpContext.Current.Session["Ngay_HT"] = obj_PNK.NgayNhap.Value.Day.ToString() + "/" + obj_PNK.NgayNhap.Value.Month.ToString() + "/" + obj_PNK.NgayNhap.Value.Year.ToString();
                System.Web.HttpContext.Current.Session["Tong_Tien"] = String.Format("{0:0,0}", obj_PNK.TongTien.Value);
                System.Web.HttpContext.Current.Session["Tien_Chu"] = CommonFunction.ConvertCurrency(obj_PNK.TongTien.Value);
                System.Web.HttpContext.Current.Session["Data_Source"] = lst_DT_NK;
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
            string ma_ncc = System.Web.HttpContext.Current.Session["Ma_NCC"].ToString();
            string ten_ncc = System.Web.HttpContext.Current.Session["Ten_NCC"].ToString();
            string dia_chi_ncc = System.Web.HttpContext.Current.Session["Dia_Chi_NCC"].ToString();
            string nguoi_giao = System.Web.HttpContext.Current.Session["Nguoi_Giao"].ToString();
            string nguoi_lap = System.Web.HttpContext.Current.Session["Nguoi_Lap"].ToString();
            string dien_giai = System.Web.HttpContext.Current.Session["Dien_Giai"].ToString();
            string so_ct = System.Web.HttpContext.Current.Session["So_CT"].ToString();
            string sdt_ncc = System.Web.HttpContext.Current.Session["SDT_NCC"].ToString();
            string ngay_ht = System.Web.HttpContext.Current.Session["Ngay_HT"].ToString();
            string tong_tien = System.Web.HttpContext.Current.Session["Tong_Tien"].ToString();
            string tien_chu = System.Web.HttpContext.Current.Session["Tien_Chu"].ToString();
            var data_source = System.Web.HttpContext.Current.Session["Data_Source"];

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/") + "/Reports/CR-NhapKho.rpt");

            rd.SetDataSource(data_source);
            rd.SetParameterValue("ma_ncc", ma_ncc);
            rd.SetParameterValue("ten_ncc", ten_ncc);
            rd.SetParameterValue("dia_chi_ncc", dia_chi_ncc);
            rd.SetParameterValue("nguoi_giao", nguoi_giao);
            rd.SetParameterValue("nguoi_lap", nguoi_lap);
            rd.SetParameterValue("dien_giai", dien_giai);           
            rd.SetParameterValue("so_ct", so_ct);           
            rd.SetParameterValue("sdt_ncc", sdt_ncc);
            rd.SetParameterValue("ngay_ht", ngay_ht);
            rd.SetParameterValue("tong_tien", tong_tien);
            rd.SetParameterValue("tien_chu", tien_chu);

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "CR-NhapKho");

            System.Web.HttpContext.Current.Session["Ma_NCC"] = null;
            System.Web.HttpContext.Current.Session["Ten_NCC"] = null;
            System.Web.HttpContext.Current.Session["Dia_Chi"] = null;
            System.Web.HttpContext.Current.Session["Nguoi_Giao"] = null;
            System.Web.HttpContext.Current.Session["Nguoi_Lap"] = null;
            System.Web.HttpContext.Current.Session["Dien_Giai"] = null;            
            System.Web.HttpContext.Current.Session["So_CT"] = null;            
            System.Web.HttpContext.Current.Session["SDT_NCC"] = null;
            System.Web.HttpContext.Current.Session["Ngay_HT"] = null;
            System.Web.HttpContext.Current.Session["Tong_Tien"] = null;
            System.Web.HttpContext.Current.Session["Tien_Chu"] = null;
            System.Web.HttpContext.Current.Session["Data_Source"] = null;            

        }
    }

}