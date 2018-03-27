using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class RoleDao
    {
        HTHApplicationDbContext db = null;
        public RoleDao()
        {
            db = new HTHApplicationDbContext();
        }
        public IEnumerable<Role> GetAll()
        {
            
            return db.Roles.OrderBy(x => x.ID).ToList();
        }

        public int Insert(Role entity)
        {
            try
            {
                db.Roles.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }

        }

        public int Update(Role entity)
        {
            Role et = db.Roles.SingleOrDefault(x => x.ID == entity.ID);
            et.Name = entity.Name;
            try
            {
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public int Delete(string ID)
        {
            try
            {
                var entity = db.Roles.Find(ID);
                db.Roles.Remove(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }

        }
    }
}
