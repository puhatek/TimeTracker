namespace TimeTracker.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public ProjectType projectType { get; set; }
        public ClientRep clientRep { get; set; }
    }
}