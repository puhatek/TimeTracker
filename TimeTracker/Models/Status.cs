using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Models
{
    public enum Status
    {
        [Display(Name = "Not Started")]
        NotStarted,
        [Display(Name = "In Progress")]
        InProgress,
        Verifying,
        Paid,
        [Display(Name = "Bug fixing")]
        BugFixing   
    }

}