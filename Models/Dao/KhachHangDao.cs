using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.Dao
{
    public  class KhachHangDao
    {
        HTHApplicationDbContext db = null;
        public KhachHangDao()
        {
            db = new HTHApplicationDbContext();
        }
        public IEnumerable<KhachHang> ListAllPaging(string tenkh, int page = 1, int pageSize = 20)
        {
            IOrderedQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(tenkh))
            {
                model = model.Where(x => x.Status == true && (x.TenKH.Contains(tenkh) || x.SDT.Contains(tenkh) || x.DiaChi.Contains(tenkh))).OrderByDescending(x => x.ID);
            }
            else
            {
                model = model.Where(x => x.Status == true).OrderByDescending(x => x.ID);
            }
            return model.ToPagedList(page, pageSize);
        }
        public List<KhachHang> ListAll()
        {
            return db.KhachHangs.OrderByDescending(x => x.ID).ToList();                
        }
        public KhachHang GetByID(int id)
        {
            return db.KhachHangs.Find(id);
        }
        public bool Insert(KhachHang entity)
        {
            try
            {
                db.KhachHangs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(KhachHang entity)
        {
            try
            {
                var model = db.KhachHangs.Find(entity.ID);
                if (model != null)
                {
                    model.TenKH = entity.TenKH;
                    model.GioiTinh = entity.GioiTinh;
                    model.DiaChi = entity.DiaChi;
                    model.SDT = entity.SDT;
                    model.NgaySinh = entity.NgaySinh;
                    model.LoaiKH = entity.LoaiKH;

                    model.ModifiedDate = entity.ModifiedDate;
                    model.ModifiedBy = entity.ModifiedBy;
                    model.Status = entity.Status;                 
                  
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
        public bool Delete(KhachHang entity)
        {
            try
            {
                var model = db.KhachHangs.Find(entity.ID);
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
