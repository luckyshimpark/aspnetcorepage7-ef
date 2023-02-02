VS CODE 기준

# ASP.NET Core EntityFrameworkCore 설치
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

#  aspnet-codegenerator 스캐폴딩 도구 설치
dotnet tool install --global dotnet-aspnet-codegenerator

# 도구를 활용한 스캐폴딩 실행하기 (SQLite)
dotnet aspnet-codegenerator razorpage -m Student -dc AspNetCore7.Data.SchoolContext -udl -outDir Pages\Students --referenceScriptLibraries -sqlite  
dotnet aspnet-codegenerator razorpage -m Instructor -dc AspNetCore7.Data.SchoolContext -udl -outDir Pages\Instructors --referenceScriptLibraries -sqlite  
dotnet aspnet-codegenerator razorpage -m Department -dc AspNetCore7.Data.SchoolContext -udl -outDir Pages\Departments --referenceScriptLibraries -sqlite  
dotnet aspnet-codegenerator razorpage -m Course -dc AspNetCore7.Data.SchoolContext -udl -outDir Pages\Courses --referenceScriptLibraries -sqlite  


# EF CLI를 설치
dotnet tool install --global dotnet-ef

# db 파일 삭제
dotnet ef database drop --force


# 초기 마이그레이션 만들기
dotnet ef migrations add InitialCreate
dotnet ef database update

# 특정 테이블 필드의 추가,수정,삭제 경우
dotnet ef migrations add ColumnFirstName
dotnet ef database update


## 참고사이트

https://learn.microsoft.com/ko-kr/aspnet/core/data/ef-rp/migrations?view=aspnetcore-7.0&tabs=visual-studio