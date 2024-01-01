using StudyCase.Application.Repositories.DeveloperRepository;
using StudyCase.Domain.Entities;
using StudyCase.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Persistence.Repositories.DeveloperRepository
{
    public class DeveloperWriteRepository : WriteRepository<Developer>, IDeveloperWriteRepository
    {
        public DeveloperWriteRepository(StudyCaseDbContext context) : base(context)
        {
        }
    }
}
