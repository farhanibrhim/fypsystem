
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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IAcademicProgramRepository AcademicProgram { get; private set; }

        public ILecturerRepository Lecturer { get; private set; }

        public IStudentRepository Student { get; private set; }

        public IEvaluatorRepository Evaluator { get; private set; }

        public ISupervisorRepository Supervisor { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AcademicProgram = new AcademicProgramRepository(_db);
            Lecturer = new LecturerRepository(_db);
            Supervisor = new SupervisorRepository(_db);
            Evaluator = new EvaluatorRepository(_db);
            Student = new StudentRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
