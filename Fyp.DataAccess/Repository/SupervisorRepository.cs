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
    public class SupervisorRepository : Repository<Penyelia>, ISupervisorRepository
    {
        private ApplicationDbContext _db;

        public SupervisorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Penyelia obj)
        {
            _db.Supervisors.Update(obj);
        }
    }
}
