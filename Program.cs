using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore7.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SchoolContextSQLite") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));

//EF 마이그레이션 오류에 대한 유용한 오류 정보를 제공합니다.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        //데이터 모델이 변경될 때 데이터베이스를 삭제하고 다시 작성합니다.
        var context = services.GetRequiredService<SchoolContext>();

        //EnsureCreated는 마이그레이션 기록 테이블을 만들지 않으므로 마이그레이션과 함께 사용할 수 없습니다.
        //데이터베이스를 삭제하고 자주 다시 생성하는 테스트 또는 신속한 프로토타입 만들기를 위해 디자인되었습니다.
        //context.Database.EnsureCreated();

        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
