using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
   public class LoaiKhachHangDao
    {
        HTHApplicationDbContext db = null;
        public LoaiKhachHangDao()
        {
            db = new HTHApplicationDbContext();
        }
        public List<LoaiKhachHang> ListAll()
        {
            return db.LoaiKhachHangs.OrderBy(x => x.ID).ToList();
        }
        public LoaiKhachHang GetByID(string id)
        {
            return db.LoaiKhachHangs.Find(id);
        }
        public bool Insert(LoaiKhachHang entity)
        {
            try
            {
                db.LoaiKhachHangs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(LoaiKhachHang entity)
        {
            try
            {
                var model = db.LoaiKhachHangs.Find(entity.ID);
                if (model != null)
                {
                    model.Ten = entity.Ten;               
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
        public bool Delete(LoaiKhachHang entity)
        {
            try
            {
                var model = db.LoaiKhachHangs.Find(entity.ID);
                if (model != null)
                {                 
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
