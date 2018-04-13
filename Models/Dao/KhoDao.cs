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
        public Kho GetByID(int id)
        {
            return db.Khoes.Find(id);
        }
        public object GetByID(int? id)
        {
            throw new NotImplementedException();
        }
        public List<Kho> ListAll()
        {
            return db.Khoes.Where(x => x.Status == true).OrderByDescending(x => x.ID).ToList();
        }
        public long Insert(Kho entity)
        {
            entity.Status = true;
            db.Khoes.Add(entity);
            db.SaveChanges();
            return entity.ID;           
        }      
        public bool Update(Kho entity)
        {
            try
            {
                var model = db.Khoes.Find(entity.ID);
                if (model != null)
                {
                    //model.DonHangID = entity.DonHangID;
                    model.Ten = entity.Ten;
                    model.DiaChi = entity.DiaChi;
                    model.QuanLyKho = entity.QuanLyKho;
                    model.SLToiDa = entity.SLToiDa;
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
        public bool Delete(Kho entity)
        {
            try
            {
                var model = db.Khoes.Find(entity.ID);
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
        //public bool Delete(Kho entity)
        //{
        //    try
        //    {
        //        var model = db.Khoes.Find(entity.ID);
        //        if (model != null)
        //        {
        //            db.Khoes.Remove(entity);
        //            db.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
