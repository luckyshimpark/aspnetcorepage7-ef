using System.ComponentModel.DataAnnotations;

namespace AspNetCore7.Models;

/// 교수 연구실
public class OfficeAssignment
{
    // [Key] 특성은 속성 이름이 classname ID 또는 ID가 아닌 다른 것일 때 
    // PK(기본 키)로 속성을 식별하는 데 사용됩니다.
    // 교수 아이디
    [Key]
    public int InstructorID { get; set; }
    [StringLength(50)]
    [Display(Name = "교수실위치")]
    public string Location { get; set; }

    // 교수. Navigation Property
    public Instructor Instructor { get; set; }
}