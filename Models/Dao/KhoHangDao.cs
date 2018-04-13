using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using Models.Dao;
namespace Models.Dao
{
    public class KhoHangDao
    {
        HTHApplicationDbContext db = null;
        public KhoHangDao()
        {
            db = new HTHApplicationDbContext();
        }
        public long Insert(KhoHang entity)
        {
            db.KhoHangs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool NhapThemHang(int makho, string mahh, int soluong)
        {
            KhoHang model = db.KhoHangs.Where(x => x.MaKho == makho && x.MaHH == mahh).SingleOrDefault();
            if (model != null)
            {
                model.SoLuong += soluong;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool BanHang(int makho, string mahh, int soluong)
        {
            KhoHang model = db.KhoHangs.Where(x => x.MaKho == makho && x.MaHH == mahh).SingleOrDefault();
            if (model != null)
            {
                model.SoLuong -= soluong;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool CheckKho(int makho, string mahh)
        {
            KhoHang model = db.KhoHangs.Where(x => x.MaKho == makho && x.MaHH == mahh).SingleOrDefault();
            if (model != null)
            {
                if (model.SoLuong <= 0)
                {
                    db.KhoHangs.Remove(model);
                    db.SaveChanges();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public List<KhoHang> GetByMaHH(string mahh)
        {
            return db.KhoHangs.Where(x => x.MaHH == mahh).OrderBy(x => x.MaKho).ToList();
        }
        public List<KhoHang> ListAll()
        {
            return db.KhoHangs.OrderBy(x => x.ID).ToList();
        }

        public string GetQuantity(int makho, string mahh)
        {
            KhoHang obj = db.KhoHangs.Where(x => x.MaKho == makho && x.MaHH == mahh).SingleOrDefault();
            if (obj != null)
                return obj.SoLuong.ToString();
            else
                return "0";
        }

    }
}
