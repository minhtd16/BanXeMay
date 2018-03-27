using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{

    public class KhachHangDao
    {
        HTHApplicationDbContext db = null;
        public KhachHangDao()
        {
            db = new HTHApplicationDbContext();
        }
        //public long Insert(KhachHang entity)
        //{
        //    db.Khoes.Add(entity);
        //    db.SaveChanges();
        //    return entity.ID;
        //}
        public List<KhachHang> ListAll()
        {
            return db.KhachHangs.OrderBy(x => x.ID).ToList();
        }
    }
}
