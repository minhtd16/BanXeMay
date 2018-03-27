using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{

    public class KhoDao
    {
        HTHApplicationDbContext db = null;
        public KhoDao()
        {
            db = new HTHApplicationDbContext();
        }
        public long Insert(Kho entity)
        {
            db.Khoes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public List<Kho> ListAll()
        {
            return db.Khoes.OrderBy(x => x.ID).ToList();
        }
    }
}
