using StudyCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Dto
{
    public class AssignmentViewModel
    {
        public Developer Developer { get; set; }
        public List<Domain.Entities.Task> Tasks { get; set; }
    }
}
