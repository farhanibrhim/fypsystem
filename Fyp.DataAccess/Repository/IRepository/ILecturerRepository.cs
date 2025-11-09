using Fyp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.DataAccess.Repository.IRepository
{
    public interface ILecturerRepository : IRepository<Pensyarah>
    {
        void Update(Pensyarah obj);
    }
}
