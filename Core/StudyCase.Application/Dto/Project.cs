using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudyCase.Application.Dto
{

    //[XmlRoot(ElementName = "developer")]
    //public class Developer
    //{

    //    [XmlElement(ElementName = "dev_name")]
    //    public string DevName { get; set; }

    //    [XmlElement(ElementName = "capacity_per_hour")]
    //    public int CapacityPerHour { get; set; }
    //}

    //[XmlRoot(ElementName = "developers")]
    //public class Developers
    //{

    //    [XmlElement(ElementName = "developer")]
    //    public List<Developer> Developer { get; set; }
    //}

    [XmlRoot(ElementName = "task")]
    public class Task
    {

        //[XmlElement(ElementName = "task_id")]
        //public int TaskId { get; set; }

        [XmlElement(ElementName = "task_name")]
        public string name { get; set; }

        [XmlElement(ElementName = "task_duration")]
        public int duration { get; set; }

        [XmlElement(ElementName = "task_difficulty")]
        public int difficulty { get; set; }
        public string TaskId { get; set; }
        //[XmlElement(ElementName = "task_assigned_to")]
        //public string TaskAssignedTo { get; set; }
    }

    [XmlRoot(ElementName = "tasks")]
    public class Tasks
    {

        [XmlElement(ElementName = "task")]
        public List<Task> tasks { get; set; }
        public string UrlId { get; set; }
    }

    [XmlRoot(ElementName = "project")]
    public class Project
    {

        //[XmlElement(ElementName = "developers")]
        //public Developers Developers { get; set; }

        [XmlElement(ElementName = "tasks")]
        public Tasks Tasks { get; set; }
    }
}
