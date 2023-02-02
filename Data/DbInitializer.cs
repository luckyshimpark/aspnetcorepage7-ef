using AspNetCore7.Models;

namespace AspNetCore7.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        // Look for any students.
        if (context.Students.Any())
        {
            return;   // DB has been seeded
        }

        //학생 명단
        var alexander = new Student
        {
            FirstMidName = "Carson",
            LastName = "Alexander",
            EnrollmentDate = DateTime.Parse("2016-09-01")
        };

        var alonso = new Student
        {
            FirstMidName = "Meredith",
            LastName = "Alonso",
            EnrollmentDate = DateTime.Parse("2018-09-01")
        };

        var anand = new Student
        {
            FirstMidName = "Arturo",
            LastName = "Anand",
            EnrollmentDate = DateTime.Parse("2019-09-01")
        };

        var barzdukas = new Student
        {
            FirstMidName = "Gytis",
            LastName = "Barzdukas",
            EnrollmentDate = DateTime.Parse("2018-09-01")
        };

        var li = new Student
        {
            FirstMidName = "Yan",
            LastName = "Li",
            EnrollmentDate = DateTime.Parse("2018-09-01")
        };

        var justice = new Student
        {
            FirstMidName = "Peggy",
            LastName = "Justice",
            EnrollmentDate = DateTime.Parse("2017-09-01")
        };

        var norman = new Student
        {
            FirstMidName = "Laura",
            LastName = "Norman",
            EnrollmentDate = DateTime.Parse("2019-09-01")
        };

        var olivetto = new Student
        {
            FirstMidName = "Nino",
            LastName = "Olivetto",
            EnrollmentDate = DateTime.Parse("2011-09-01")
        };

        var students = new Student[]
        {
            alexander,
            alonso,
            anand,
            barzdukas,
            li,
            justice,
            norman,
            olivetto
        };

        context.AddRange(students);

        //교수 명단
        var abercrombie = new Instructor
        {
            FirstMidName = "Kim",
            LastName = "Abercrombie",
            HireDate = DateTime.Parse("1995-03-11")
        };

        var fakhouri = new Instructor
        {
            FirstMidName = "Fadi",
            LastName = "Fakhouri",
            HireDate = DateTime.Parse("2002-07-06")
        };

        var harui = new Instructor
        {
            FirstMidName = "Roger",
            LastName = "Harui",
            HireDate = DateTime.Parse("1998-07-01")
        };

        var kapoor = new Instructor
        {
            FirstMidName = "Candace",
            LastName = "Kapoor",
            HireDate = DateTime.Parse("2001-01-15")
        };

        var zheng = new Instructor
        {
            FirstMidName = "Roger",
            LastName = "Zheng",
            HireDate = DateTime.Parse("2004-02-12")
        };

        var instructors = new Instructor[]
        {
            abercrombie,
            fakhouri,
            harui,
            kapoor,
            zheng
        };

        context.AddRange(instructors);

        // 교수실 (with 교수 정보)
        var officeAssignments = new OfficeAssignment[]
        {
            new OfficeAssignment {
                Instructor = fakhouri, //교수정보
                Location = "Smith 17" }, //교수실 위치
            new OfficeAssignment {
                Instructor = harui,
                Location = "Gowan 27" },
            new OfficeAssignment {
                Instructor = kapoor,
                Location = "Thompson 304" }
        };

        context.AddRange(officeAssignments);

        //학과 명단
        var english = new Department
        {
            Name = "English", //영문학과
            Budget = 350000, //예산
            StartDate = DateTime.Parse("2007-09-01"),
            Administrator = abercrombie //교수
        };

        var mathematics = new Department
        {
            Name = "Mathematics", //수학과
            Budget = 100000,
            StartDate = DateTime.Parse("2007-09-01"),
            Administrator = fakhouri
        };

        var engineering = new Department
        {
            Name = "Engineering", //공학과
            Budget = 350000,
            StartDate = DateTime.Parse("2007-09-01"),
            Administrator = harui
        };

        var economics = new Department
        {
            Name = "Economics", //경제학과
            Budget = 100000,
            StartDate = DateTime.Parse("2007-09-01"),
            Administrator = kapoor
        };

        var departments = new Department[]
        {
            english,
            mathematics,
            engineering,
            economics
        };

        context.AddRange(departments);

        //강좌(학과목)
        var chemistry = new Course
        {
            CourseID = 1050,
            Title = "Chemistry", //화학
            Credits = 3,
            Department = engineering, //공학과

            //강좌(학과목)에 여러 교수 배정
            Instructors = new List<Instructor> { kapoor, harui }
        };

        var microeconomics = new Course
        {
            CourseID = 4022,
            Title = "Microeconomics",//미시경제학
            Credits = 3,
            Department = economics, //경제학과
            Instructors = new List<Instructor> { zheng }
        };

        var macroeconmics = new Course
        {
            CourseID = 4041,
            Title = "Macroeconomics", //거시경제학
            Credits = 3,
            Department = economics, //경제학과
            Instructors = new List<Instructor> { zheng }
        };

        var calculus = new Course
        {
            CourseID = 1045,
            Title = "Calculus", //미적분학
            Credits = 4,
            Department = mathematics, //수학과
            Instructors = new List<Instructor> { fakhouri }
        };

        var trigonometry = new Course
        {
            CourseID = 3141,
            Title = "Trigonometry", //삼각법
            Credits = 4,
            Department = mathematics, //수학과
            Instructors = new List<Instructor> { harui }
        };

        var composition = new Course
        {
            CourseID = 2021,
            Title = "Composition", //영어작문
            Credits = 3,
            Department = english, //영문학과
            Instructors = new List<Instructor> { abercrombie }
        };

        var literature = new Course
        {
            CourseID = 2042,
            Title = "Literature", //영어문학
            Credits = 4,
            Department = english, //영문학과
            Instructors = new List<Instructor> { abercrombie }
        };

        var courses = new Course[]
        {
            chemistry,
            microeconomics,
            macroeconmics,
            calculus,
            trigonometry,
            composition,
            literature
        };

        context.AddRange(courses);

        // 학생별 수강과목 및 학점
        var enrollments = new Enrollment[]
        {
            new Enrollment {
                Student = alexander, //학생
                Course = chemistry,//강좌(학과목)
                Grade = Grade.A //A학점
            },
            new Enrollment {
                Student = alexander,
                Course = microeconomics,
                Grade = Grade.C
            },
            new Enrollment {
                Student = alexander,
                Course = macroeconmics,
                Grade = Grade.B
            },
            new Enrollment {
                Student = alonso,
                Course = calculus,
                Grade = Grade.B
            },
            new Enrollment {
                Student = alonso,
                Course = trigonometry,
                Grade = Grade.B
            },
            new Enrollment {
                Student = alonso,
                Course = composition,
                Grade = Grade.B
            },
            new Enrollment {
                Student = anand,
                Course = chemistry
            },
            new Enrollment {
                Student = anand,
                Course = microeconomics,
                Grade = Grade.B
            },
            new Enrollment {
                Student = barzdukas,
                Course = chemistry,
                Grade = Grade.B
            },
            new Enrollment {
                Student = li,
                Course = composition,
                Grade = Grade.B
            },
            new Enrollment {
                Student = justice,
                Course = literature,
                Grade = Grade.B
            }
        };

        context.AddRange(enrollments);
        context.SaveChanges();
        
    }
}