using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class NhapHangDao
    {
        HTHApplicationDbContext db = null;
        public NhapHangDao()
        {
            db = new HTHApplicationDbContext();
        }

        public List<NhapHang> ListAll()
        {
            return db.NhapHangs.OrderBy(x => x.IDNhap).ToList();
        }
        public bool Insert(NhapHang entity)
        {
            db.NhapHangs.Add(entity);
            db.SaveChanges();
            return true;
        }
        public NhapHang GetById(string idNhap)
        {
            return db.NhapHangs.Find(idNhap);
        }
    }
}
