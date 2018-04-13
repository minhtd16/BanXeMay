using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dao;
using Models.EF;
namespace Models.Dao
{
    public class XuatHangDao
    {
        HTHApplicationDbContext db = null;
        public XuatHangDao()
        {
            db = new HTHApplicationDbContext();
        }
        public List<XuatHang> ListAll()
        {
            return db.XuatHangs.OrderBy(x => x.IDXuat).ToList();
        }
        public bool Insert(XuatHang entity)
        {
            db.XuatHangs.Add(entity);
            db.SaveChanges();
            return true;
        }
        public XuatHang GetByID(string idXuat)
        {
            return db.XuatHangs.Find(idXuat);
        }
    }
}
