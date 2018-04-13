using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class ChiTietNhapDao
    {
        HTHApplicationDbContext db = null;
        public ChiTietNhapDao()
        {
            db = new HTHApplicationDbContext();
        }
        public bool Insert(ChiTietNhap entity)
        {
            db.ChiTietNhaps.Add(entity);
            db.SaveChanges();
            return true;
        }
    }
}
