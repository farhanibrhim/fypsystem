using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAcademicProgramRepository AcademicProgram { get; }

        ILecturerRepository Lecturer { get; }

        IStudentRepository Student { get; }

        IEvaluatorRepository Evaluator { get; }

        ISupervisorRepository Supervisor { get; }

        void Save();
    }
}
