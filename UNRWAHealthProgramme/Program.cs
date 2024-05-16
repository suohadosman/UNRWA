using IUNRWA_DTOs.DoctorDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_Repository.Repository.BaseRepository;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.AreaPlaceService;
using IUNRWA_Service.AreaService;
using IUNRWA_Service.AuthenticationService;
using IUNRWA_Service.ChildCardService;
using IUNRWA_Service.DoctorService;
using IUNRWA_Service.FamilyCardService;
using IUNRWA_Service.FollowUpLabTestService;
using IUNRWA_Service.HealthCenterService;
using IUNRWA_Service.IllnessService;
using IUNRWA_Service.LabTestService;
using IUNRWA_Service.LateComplicationService;
using IUNRWA_Service.LateComplicationSevice;
using IUNRWA_Service.MedicineService;
using IUNRWA_Service.NationalityService;
using IUNRWA_Service.NCDService;
using IUNRWA_Service.PersonService;
using IUNRWA_Service.PreviewLabTestService;
using IUNRWA_Service.PreviewMedicineService;
using IUNRWA_Service.PreviewService;
using IUNRWA_Service.RelationshipService;
using IUNRWA_Service.ReservationService;
using IUNRWA_Service.StudyLevelService;
using IUNRWA_Service.TeamService;
using IUNRWA_Service.TheMeasurementService;
using IUNRWA_Service.TheServiceService;
using IUNRWA_Service.TimeSloteService;
using IUNRWA_ShareKernal.Enum.LabTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using UNRWAHealthProgramme.Configurations;

var builder = WebApplication.CreateBuilder(args);
var HostingEnvironment = builder.Environment;

// Add services to the container'
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString(HostingEnvironment.IsProduction() ? "server" : "rama");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.ConfigureIdentity();

#region Repository
builder.Services.TryAddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.TryAddScoped<IUserRepository, UserRepository>();

#endregion

#region Services Scope
builder.Services.TryAddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.TryAddScoped<ITeamService, TeamService>();
builder.Services.TryAddScoped<IAreaService, AreaService>();
builder.Services.TryAddScoped<IAreaPlaceService, AreaPlaceService>();
builder.Services.TryAddScoped<INationalityService, NationalityService>();
builder.Services.TryAddScoped<IRelationshipService, RelationshipService>();
builder.Services.TryAddScoped<IStudyLevelService, StudyLevelService>();
builder.Services.TryAddScoped<IPersonService, PersonService>();
builder.Services.TryAddScoped<IFamilyCardService, FamilyCardService>();
builder.Services.TryAddScoped<IHealthCenterService, HealthCenterService>();
builder.Services.TryAddScoped<IChildCardService, ChildCardService>();
builder.Services.TryAddScoped<INCDService,NCDService>();
builder.Services.TryAddScoped<ITheServiceService, TheServiceService>();
builder.Services.TryAddScoped<IDoctorService, DoctorService>();
builder.Services.TryAddScoped<IReservationService, ReservationService>();
builder.Services.TryAddScoped<ITimeSloteServices, TimeSloteService>();
builder.Services.TryAddScoped<IDoctorService, DoctorService>();
builder.Services.TryAddScoped<IMedicineService, MedicineService>();
builder.Services.TryAddScoped<ILabTestService, LabTestService>();
builder.Services.TryAddScoped<ITimeSloteServices, TimeSloteService>();
builder.Services.TryAddScoped<IPreviewService, PreviewService>();
builder.Services.TryAddScoped<IPreviewMedicineService, PreviewMedicineService>();
builder.Services.TryAddScoped<ITheMeasurementService, TheMeasurementService>();
builder.Services.TryAddScoped<IIllnessService, IllnessService>();
builder.Services.TryAddScoped<IPreviewLabTestService, PreviewLabTestService>();
builder.Services.TryAddScoped<IFollowUpLabTestService, FollowUpLabTestService>();
builder.Services.TryAddScoped<ILateComplicationService, LateComplicationService>();


builder.Services.AddControllers();
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
   
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Identity Configuration
//By this on every HTTP Request, the user’s credentials will be added on a Cookie or URL.
//This will associate a give user with the HTTP request he or she makes to the application.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
