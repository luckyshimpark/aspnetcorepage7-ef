

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore7.Models;

///학생
public class Student
{
    public int ID { get; set; }
    [Required]
    [StringLength(50)]
    [Display(Name = "이름")]
    public string LastName { get; set; }
    [Required]
    [Display(Name = "성")]
    [Column("FirstName")]
    public string FirstMidName { get; set; }

    //서버의 CultureInfo를 기본으로 하는 기본 형식에 따라 표시
    [DataType(DataType.Date)]
    //ApplyFormatInEditMode 설정은 서식 지정이 편집 UI에도 적용되어야 함을 지정.
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "등록일자")]
    public DateTime EnrollmentDate { get; set; }

    [Display(Name = "학생이름")]
    public string FullName{
        get{
            return $"{LastName}, {FirstMidName}";
        }
    }

    public ICollection<Enrollment> Enrollments { get; set; }
}