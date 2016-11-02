using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Models
{
    public enum Status
    {
        [Display(Name = "In Progress")]
        InProgress,
        Verifying,
        Paid,
        [Display(Name = "Not Started")]
        NotStarted,
        Finished,
        [Display(Name = "Bug fixing")]
        BugFixing
    }
}