using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public string ApiId { get; set; }
        public int DeveloperID { get; set; }
    }
}
