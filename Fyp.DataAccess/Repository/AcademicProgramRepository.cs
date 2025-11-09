using Fyp.DataAccess.Data;
using Fyp.DataAccess.Repository.IRepository;
using Fyp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.DataAccess.Repository
{
    public class AcademicProgramRepository : Repository<AcademicProgram>, IAcademicProgramRepository
    {
        private ApplicationDbContext _db;

        public AcademicProgramRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AcademicProgram obj)
        {
            _db.AcademicPrograms.Update(obj);
        }
    }
}
