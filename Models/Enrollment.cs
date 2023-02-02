
using System.ComponentModel.DataAnnotations;

namespace AspNetCore7.Models;

public enum Grade
{
    A, B, C, D, F
}

/// 학생수강(학점포함)
public class Enrollment
{
    public int EnrollmentID { get; set; }

    //강좌(학과목) 아이디
    public int CourseID { get; set; }

    //학생 아이디
    public int StudentID { get; set; }

    //null 이면, 표기문구를 "No grade" 로 표시
    [DisplayFormat(NullDisplayText = "No grade")]
    [Display(Name = "학점")]
    public Grade? Grade { get; set; }

    //강좌(학과목) Navigation Property
    public Course Course { get; set; }

    //학생 Navigation Property
    public Student Student { get; set; }
}