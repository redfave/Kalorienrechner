using CaloryLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.Repository
{
    public class CaloryRepository : EntityFrameworkRepository<CaloryContext>
    {
        public CaloryRepository() : this(new CaloryContext())
        {
            
        }
        public CaloryRepository(CaloryContext context) : base(context)
        {
        }
    }
}
