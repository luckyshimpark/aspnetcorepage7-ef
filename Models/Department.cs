using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore7.Models;


/// 학과
public class Department{
    public int DepartmentID { get; set; }

    [Display(Name = "학과명")]
    public string Name { get; set; }

    [DataType(DataType.Currency)]
    //데이터베이스에서 SQL Server money 형식을 사용하여 정의(통화용)
    [Display(Name = "학과비용")]
    [Column(TypeName = "money")]
    public decimal Budget { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", 
        ApplyFormatInEditMode = true)]
    [Display(Name = "개강일")]
    public DateTime StartDate { get; set; }

    // 학과는 교수가 없을 수도 있다. 
    // nullable 이 아니면 교수 삭제 시 학과가 자동 삭제되는 이슈!!
    public int? InstructorID { get; set; }

    // 교수, foreign key로 지정, Navigation Property
    // 학과에 1명의 교수가 배정 또는 없을 수 있음
    [Display(Name = "교수")]
    public Instructor Administrator { get; set; }

    // 강좌(학과목), Navigation Property
    // 학과는 여러 강좌(학과목)에 배정됨 
    public ICollection<Course> Courses { get; set; }
}