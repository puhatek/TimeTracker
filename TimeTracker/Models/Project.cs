namespace TimeTracker.Models
{
    public class Project
    {
        public string name { get; set; }
        public ProjectType projectType { get; set; }
        public ClientRep clientRep { get; set; }
    }
}