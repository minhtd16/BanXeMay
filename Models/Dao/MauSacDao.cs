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
        public List<MauSac> ListAll()
        {
            return db.MauSacs.OrderBy(x => x.ID).ToList();
        }
        public int Insert(MauSac entity)
        {
            db.MauSacs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public void Delete(MauSac entity)
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
