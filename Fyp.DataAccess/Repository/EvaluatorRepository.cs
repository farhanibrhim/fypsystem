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
    public class EvaluatorRepository : Repository<Penilai>, IEvaluatorRepository
    {
        private ApplicationDbContext _db;

        public EvaluatorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Penilai obj)
        {
            _db.Evaluators.Update(obj);
        }
    }
}
