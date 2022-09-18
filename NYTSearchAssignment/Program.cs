using NYTimesSearch.Core.Managers;
using NYTimesSearch.Core.Repository;
using NYTimesSearch.Core.Repository.Implementation;
using NYTimesSearch.Core.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddTransient<ISearchServiceManager, SearchServiceManager>();
builder.Services.AddTransient<ISearchServiceRepository, SearchServiceRepository>();
builder.Services.AddTransient<IExternalServicesProvider, ExternalServicesProvider>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
