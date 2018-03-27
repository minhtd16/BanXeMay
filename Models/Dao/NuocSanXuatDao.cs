using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
   public class NuocSanXuatDao
    {
       HTHApplicationDbContext db = null;
       public NuocSanXuatDao()
       {
           db = new HTHApplicationDbContext();
       }
       public List<NuocSanXuat> ListALl()
       {
           return db.NuocSanXuats.ToList();
       }
    }
}
