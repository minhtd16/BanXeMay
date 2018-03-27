using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Models.EF;
namespace Models.Dao
{
    public class HangHoaDao
    {
        HTHApplicationDbContext db = null;
        public HangHoaDao()
        {
            db = new HTHApplicationDbContext();
        }
        public IEnumerable<HangHoa> ListAllPaging(string masp, int page = 1, int pageSize = 10)
        {
            IOrderedQueryable<HangHoa> model = db.HangHoas;
            if (!string.IsNullOrEmpty(masp))
            {
                model = model.Where(x => x.Status == true && (x.MaHH.Contains(masp) || x.TenHH.Contains(masp))).OrderByDescending(x => x.CreatedDate);
            }
            else
            {
                model = model.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate);
            }
            return model.ToPagedList(page, pageSize);
        }
        public HangHoa GetByID(string id)
        {
            return db.HangHoas.Find(id);
        }
        public bool Insert(HangHoa entity)
        {
            try
            {
                db.HangHoas.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(HangHoa entity)
        {
            try
            {
                var model = db.HangHoas.Find(entity.MaHH);
                if (model != null)
                {
                    model.TenHH = entity.TenHH;
                    model.DVT = entity.DVT;
                    model.GiaBanLe = entity.GiaBanLe;
                    model.GiaBanSi = entity.GiaBanSi;
                    model.GiaNhapVe = entity.GiaNhapVe;
                    model.HanBaoDong = entity.HanBaoDong;
                    model.LoaiMH = entity.LoaiMH;
                    model.MauID = entity.MauID;
                    model.ModifiedBy = entity.ModifiedBy;
                    model.NuocSXID = entity.NuocSXID;
                    model.SoLuong = entity.SoLuong;
                    model.ThongTin = entity.ThongTin;
                    model.ThueSuat = entity.ThueSuat;
                    model.TinhTonKho = entity.TinhTonKho;
                    model.TonToiDa = entity.TonToiDa;
                    model.TonToiThieu = entity.TonToiThieu;
                    model.ModifiedDate = DateTime.Now;
                    if (entity.Anh == null)
                    {
                        model.Anh = "/Data/images/no-image.jpg";
                    }
                    else
                    {
                        model.Anh = entity.Anh;
                    }                    
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(HangHoa entity)
        {
            try
            {
                var model = db.HangHoas.Find(entity.MaHH);
                if (model != null)
                {
                    model.Status = false;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
