using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Repositories.TaskRepository
{
    public interface ITaskReadRepository : IReadRepository<Domain.Entities.Task>
    {
    }
}
