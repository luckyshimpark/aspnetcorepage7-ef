using System.ComponentModel.DataAnnotations;

namespace AspNetCore7.ViewModels;


public class EnrollmentDateGroup
{
    [DataType(DataType.Date)]
    public DateTime? EnrollmentDate { get; set; }

    public int StudentCount { get; set; }
}