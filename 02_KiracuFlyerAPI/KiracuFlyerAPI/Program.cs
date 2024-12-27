using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Repository;
using Microsoft.EntityFrameworkCore;
using KiracuFlyerAPI.Auth;
using KiracuFlyerAPI.Service.Interface;
using KiracuFlyerAPI.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // 接続文字列は appsettings.json から取得する
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)); // SQL Server を使う場合

        // リポジトリとサービスを注入
        builder.Services.AddScoped<JwtTokenGenerator>();
        // リポジトリの登録
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserStatusRepository, UserStatusRepository>();
        builder.Services.AddScoped<IStatusRepository, StatusRepository>();
        builder.Services.AddScoped<IUserIconRepository, UserIconRepository>();
        builder.Services.AddScoped<IChannelIconMasterRepository, ChannelIconMasterRepository>();

        // サービスの登録
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserStatusService, UserStatusService>();
        builder.Services.AddScoped<IStatusService, StatusService>();
        builder.Services.AddScoped<IUserIconService, UserIconService>();
        builder.Services.AddScoped<IChannelIconMasterService, ChannelIconMasterService>();
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}