using StudyCase.Application.Dto;
using StudyCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Services
{
    public interface ITaskAssignerService
    {
        List<AssignmentViewModel> AssignTasks(List<Domain.Entities.Task> tasks, List<Developer> developers);
    }
}
