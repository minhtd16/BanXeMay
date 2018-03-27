using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class LoaiMatHangDao
    {
        HTHApplicationDbContext db = null;
        public LoaiMatHangDao()
        {
            db = new HTHApplicationDbContext();
        }
        public List<LoaiMatHang> ListAll()
        {
            return db.LoaiMatHangs.ToList();
        }
        public bool Insert(LoaiMatHang entity)
        {
            try
            {
                db.LoaiMatHangs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Update(LoaiMatHang entity)
        {
            try
            {
                LoaiMatHang hh = db.LoaiMatHangs.Find(entity.ID);
                hh.Ten = entity.Ten;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(LoaiMatHang entity)
        {
            try
            {                
                db.LoaiMatHangs.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public LoaiMatHang GetByID(string id)
        {
            return db.LoaiMatHangs.Find(id);
        }
    }
}
