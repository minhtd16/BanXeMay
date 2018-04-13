using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
  public  class KhachHangGiaoDichDao
    {
        HTHApplicationDbContext db = null;
        public KhachHangGiaoDichDao()
        {
            db = new HTHApplicationDbContext();
        }
        public List<KhachHangGiaoDich> ListAll()
        {
            return db.KhachHangGiaoDiches.OrderBy(x => x.ID).ToList();
        }
        public KhachHangGiaoDich GetByID(int id)
        {
            return db.KhachHangGiaoDiches.Find(id);
        }
        public bool Insert(KhachHangGiaoDich entity)
        {
            try
            {
                db.KhachHangGiaoDiches.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(KhachHangGiaoDich entity)
        {
            try
            {
                var model = db.KhachHangGiaoDiches.Find(entity.ID);
                if (model != null)
                {
                    model.DonHangID = entity.DonHangID;
                    model.KhachHangID = entity.KhachHangID;
                    model.NgayGiaoDich = entity.NgayGiaoDich;
                    model.TongTien = entity.TongTien;
                    model.SoLuong = entity.SoLuong;
                    model.TrangThai = entity.TrangThai;

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
        public bool Delete(KhachHangGiaoDich entity)
        {
            try
            {
                var model = db.KhachHangGiaoDiches.Find(entity.ID);
                if (model != null)
                {
                    db.KhachHangGiaoDiches.Remove(entity);
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
