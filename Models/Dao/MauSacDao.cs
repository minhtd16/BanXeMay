using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class MauSacDao
    {
        HTHApplicationDbContext db = null;
        public MauSacDao()
        {
            db = new HTHApplicationDbContext();
        }

        public MauSac GetByID(int id)
        {
            return db.MauSacs.Find(id);
        }
        public object GetByID(int? id)
        {
            throw new NotImplementedException();
        }
        public List<MauSac> ListAll()
        {
            return db.MauSacs.Where(x => x.Status == true).OrderBy(x => x.ID).ToList();
        }
        public int Insert(MauSac entity)
        {
            entity.Status = true;
            db.MauSacs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(MauSac entity)
        {
            try
            {
                var model = db.MauSacs.Find(entity.ID);
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
        public void Delete_x(MauSac entity)
        {
            db.MauSacs.Remove(entity);
            db.SaveChanges();
        }
        public void Edit(MauSac entity)
        {
            MauSac ms = db.MauSacs.SingleOrDefault(x => x.ID == entity.ID);
            ms.Ten = entity.Ten;
            db.SaveChanges();
        }

    }
}
