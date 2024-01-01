using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyCase.Application.Repositories.DeveloperRepository;
using StudyCase.Application.Repositories.TaskRepository;
using StudyCase.Application.Services;
using StudyCase.Persistence.Contexts;
using StudyCase.Persistence.Repositories.DeveloperRepository;
using StudyCase.Persistence.Repositories.TaskRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<StudyCaseDbContext>(x =>
            {
                x.UseInMemoryDatabase("StudyCaseDB");
            });

            services.AddScoped<IDeveloperReadRepository, DeveloperReadRepository>();
            services.AddScoped<IDeveloperWriteRepository, DeveloperWriteRepository>();
            services.AddScoped<ITaskReadRepository, TaskReadRepository>();
            services.AddScoped<ITaskWriteRepository, TaskWriteRepository>();
        }
    }
}
