using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Repositories.TaskRepository
{
    public interface ITaskWriteRepository : IWriteRepository<Domain.Entities.Task>
    {
    }
}
