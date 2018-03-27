using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class CauHinhIDDao
    {
        HTHApplicationDbContext db = null;
        public CauHinhIDDao()
        {
            db = new HTHApplicationDbContext();
        }
        public CauHinhID GetValueByID(string ID)
        {
            return db.CauHinhIDs.Find(ID);
        }
        public bool Update(string id)
        {
            try
            {
                var qa = db.CauHinhIDs.Find(id);
                qa.Value += 1; 
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
