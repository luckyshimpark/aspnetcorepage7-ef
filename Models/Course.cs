
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore7.Models;

/// 강좌(학과목)
/// 강좌와 교수는 다대다 관계
public class Course
{
    // PK 를 자동증가 X, 직접 입력함.
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "순번")]
    public int CourseID { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "강좌(학과목)명")]
    public string Title { get; set; }
    [Range(0, 5)]
    public int Credits { get; set; }

    [Display(Name = "학과코드")]
    public int DepartmentID { get; set; }

    //수강과목은 1개의 학과에 할당됨. Navigation Property    
    [Display(Name = "학과명")]
    public Department Department { get; set; }   

    //등록 = 수강과목+학생. Navigation Property
    public ICollection<Enrollment> Enrollments { get; set; }

    //교수(수강과목에 여러 교수 배정됨). Navigation Property
    //다:다 관계
     [Display(Name = "교수")]
    public ICollection<Instructor> Instructors { get; set; }
}