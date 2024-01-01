using StudyCase.Application.Repositories;
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
    public class DeveloperReadRepository : ReadRepository<Developer>, IDeveloperReadRepository
    {
        public DeveloperReadRepository(StudyCaseDbContext context) : base(context)
        {
        }
    }
}
