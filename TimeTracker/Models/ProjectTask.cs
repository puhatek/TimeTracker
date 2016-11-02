using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models
{
    public class ProjectTask
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string projectName { get; set; }
        public string clientRep { get; set; }
        public string status { get; set; } 
        public int leadTime { get; set; }
    }
}