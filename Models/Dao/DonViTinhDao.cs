using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
   public class DonViTinhDao
    {
       HTHApplicationDbContext db = null;
       public DonViTinhDao()
       {
           db = new HTHApplicationDbContext();
       }
       public List<DonViTinh> ListAll()
       {
           return db.DonViTinhs.ToList();
       }
    }
}
