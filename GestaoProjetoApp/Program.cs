using GestaoProjeto.Infra.Data.Extensions;
using GestaoProjeto.Infra.DataDapper.Extensions;
using GestaoProjetoApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddDapperConfig(builder.Configuration);

var app = builder.Build();

app.UseAuthorization();
app.UseSwaggerDoc();
app.MapControllers();

app.Run();
