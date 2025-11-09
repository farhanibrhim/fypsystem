using Fyp.DataAccess.Data;
using Fyp.DataAccess.Repository.IRepository;
using Fyp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.DataAccess.Repository
{
    public class LecturerRepository : Repository<Pensyarah>, ILecturerRepository
    {
        private ApplicationDbContext _db;

        public LecturerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pensyarah obj)
        {
            _db.Lecturers.Update(obj);
        }
    }
}
