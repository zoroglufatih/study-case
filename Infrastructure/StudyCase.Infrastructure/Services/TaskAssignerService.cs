using StudyCase.Application.Dto;
using StudyCase.Application.Services;
using StudyCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Infrastructure.Services
{
    public class TaskAssignerService : ITaskAssignerService
    {
        public List<AssignmentViewModel> AssignTasks(List<Domain.Entities.Task> tasks, List<Developer> developers)
        {
            SortTasksByDifficulty(tasks); // Zorluk seviyesine göre görevleri sırala
            var developerPlan = new List<AssignmentViewModel>();

            foreach (var task in tasks)
            {
                Developer bestDeveloper = GetBestDeveloperForTask(task, developers);
                if (bestDeveloper != null)
                {
                    if (developerPlan.Where(x => x.Developer.Id == bestDeveloper.Id).ToList().Count < 1)
                    {
                        var devTasks = new AssignmentViewModel()
                        {
                            Developer = bestDeveloper,
                            Tasks = new List<Domain.Entities.Task>()
                        };
                        developerPlan.Add(devTasks);
                    }

                    var dev = developerPlan.Where(x => x.Developer.Id == bestDeveloper.Id).First();
                    dev.Tasks.Add(task);
                    bestDeveloper.TotalWorkDone += Convert.ToDouble(task.Difficulty * task.Duration) / Convert.ToDouble(bestDeveloper.Difficulty);
                }
            }

            // Developer Planını ekrana yazdır
            foreach (var developer in developerPlan)
            {
                foreach (var item in developer.Tasks)
                {
                    Console.WriteLine($"{developer.Developer.Name} {developer.Developer.Id} {developer.Developer.TotalWorkDone} -> {item.Id + "" + item.Name}");
                }
            }

            return developerPlan;
        }

        private void SortTasksByDifficulty(List<Domain.Entities.Task> tasks)
        {
            tasks = tasks.OrderBy(t => t.Difficulty * t.Duration).ToList();
        }

        private Developer GetBestDeveloperForTask(Domain.Entities.Task task, List<Developer> developers)
        {
            Developer bestDeveloper = null;
            double minWorkDone = double.MaxValue;

            foreach (var developer in developers.OrderBy(x => x.Difficulty))
            {
                // Geliştiricinin daha önce yaptığı işlerin toplamı ne kadar azsa, o kadar uygun olabilir.
                if (developer.TotalWorkDone < minWorkDone)
                {
                    bestDeveloper = developer;
                    minWorkDone = developer.TotalWorkDone;
                }
            }

            return bestDeveloper;
        }
    }
}
