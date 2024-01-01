using StudyCase.UI.Models.Entities;

namespace StudyCase.UI.Models
{
    public class AssignmentViewModel
    {
        public Developer Developer { get; set; }
        public List<Entities.Task> Tasks { get; set; }
    }
}
