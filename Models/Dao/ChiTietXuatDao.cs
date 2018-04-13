using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dao;
using Models.EF;
namespace Models.Dao
{
    public class ChiTietXuatDao
    {
        HTHApplicationDbContext db = null;
        public ChiTietXuatDao()
        {
            db = new HTHApplicationDbContext();
        }
        public bool Insert(ChiTietXuat entity)
        {
            db.ChiTietXuats.Add(entity);
            db.SaveChanges();
            return true;
        }
    }
}
