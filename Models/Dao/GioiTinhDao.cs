using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
   public  class GioiTinhDao
    {
        HTHApplicationDbContext db = null;
        public GioiTinhDao()
        {
            db = new HTHApplicationDbContext();
        }

        public List<GioiTinh> ListAll()
        {
            return db.GioiTinhs.OrderBy(x => x.iD).ToList();
        }
     
        public GioiTinh GetByID(int id)
        {
            return db.GioiTinhs.Find(id);
        }
        public bool Insert(GioiTinh entity)
        {
            try
            {
                db.GioiTinhs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(GioiTinh entity)
        {
            try
            {
                var model = db.GioiTinhs.Find(entity.iD);
                if (model != null)
                {
                    model.tenGT = entity.tenGT;               
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
        public bool Delete(GioiTinh entity)
        {
            try
            {
                var model = db.GioiTinhs.Find(entity.iD);
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
