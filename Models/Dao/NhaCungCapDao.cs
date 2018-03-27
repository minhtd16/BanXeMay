using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class NhaCungCapDao
    {
        HTHApplicationDbContext db = null;
        public NhaCungCapDao()
        {
            db = new HTHApplicationDbContext();
        }
        public List<NhaCungCap> GetAll()
        {
            return db.NhaCungCaps.OrderBy(x => x.MaNCC).ToList();
             
        }
    }
}
