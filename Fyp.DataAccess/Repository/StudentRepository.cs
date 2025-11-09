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
    public class StudentRepository : Repository<Murid>, IStudentRepository
    {
        private ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Murid obj)
        {
            _db.Students.Update(obj);
        }
    }
}
