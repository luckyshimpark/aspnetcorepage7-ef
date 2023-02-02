

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore7.Models;


/// 교수
/// 교수와 강좌는 다대다 관계
public class Instructor
{
    //교수아이디
    public int ID { get; set; }

    [Required]
    [Display(Name = "이름")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [Column("FirstName")]
    [Display(Name = "성")]
    [StringLength(50)]
    public string FirstMidName { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "고용일자")]
    public DateTime HireDate { get; set; }

    [Display(Name = "교수이름")]
    public string FullName
    {
        get { return FirstMidName + LastName; }
    }

    // 강좌(학과목).  Navigation Property
    // 다:다 관계
    [Display(Name = "강좌(학과목)명")]
    public ICollection<Course> Courses { get; set; }

    // 사무실. Navigation Property
    [Display(Name = "교수사무실위치")]
    public OfficeAssignment OfficeAssignment { get; set; }
}