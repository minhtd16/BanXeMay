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

        //public List<NhapHang> ListAll()
        //{
        //    return db.NhapHangs.Á(x => x.CreatedDate).ToList();
        //}
    }
}
