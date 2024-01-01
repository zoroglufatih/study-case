using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    public class DeveloperViewwModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public int RecentScore { get; set; }

        public List<TaskViewModel> AssignedTasks { get; set; } = new List<TaskViewModel>();


    }
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
    }
    public class TaskAssigner
    {
        private const int WeeklyHour = 45;
        private List<DeveloperViewwModel> developers;
        private List<TaskViewModel> tasks;

        public TaskAssigner(List<DeveloperViewwModel> developers, List<TaskViewModel> tasks)
        {
            this.developers = developers;
            this.tasks = tasks;
        }

        public Dictionary<string, List<string>> AssignTasks(bool resumable = true)
        {
            SortTasks();
            var developerPlan = new Dictionary<string, List<string>>();
            int week = 0;

            while (tasks.Count > 0)
            {
                foreach (var developer in developers)
                {
                    CalculateRecentScore(week, developer);
                }

                foreach (var task in tasks.ToList())
                {
                    var taskScore = CalculateTaskScore(task);

                    foreach (var developer in developers)
                    {
                        if (developer.RecentScore > 0 && developer.RecentScore >= taskScore)
                        {
                            if (!developerPlan.ContainsKey(developer.Name))
                            {
                                developerPlan[developer.Name] = new List<string>();
                            }

                            developerPlan[developer.Name].Add(task.Name);
                            developer.RecentScore -= taskScore;
                            tasks.Remove(task);
                            break;
                        }
                    }
                }

                if (!resumable)
                {
                    foreach (var developer in developers)
                    {
                        CalculateRecentScore(0, developer);
                    }
                }

                week++;
            }

            return developerPlan;
        }

        private void SortTasks()
        {
            tasks = tasks.OrderByDescending(t => t.Difficulty * t.Duration).ToList();
        }

        private void CalculateRecentScore(int week, DeveloperViewwModel developer)
        {
            if (week == 0)
            {
                developer.RecentScore = WeeklyHour * developer.Difficulty;
            }
            else
            {
                developer.RecentScore += WeeklyHour * developer.Difficulty;
            }
        }

        private int CalculateTaskScore(TaskViewModel task)
        {
            return task.Difficulty * task.Duration;
        }
    }


    
}
