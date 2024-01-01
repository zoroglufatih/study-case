using Microsoft.Extensions.DependencyInjection;
using StudyCase.Application.Services;
using StudyCase.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            

            services.AddSingleton<IHttpRequestService, HttpRequestService>();
            services.AddSingleton<IParserService, ParserService>();
            services.AddSingleton<ITaskAssignerService, TaskAssignerService>();
        }
    }
}
