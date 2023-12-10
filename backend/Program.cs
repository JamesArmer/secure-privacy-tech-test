using backend.Encryption;
using backend.Repository;
using backend.Services;

var AllowLocalhostOrigins = "_AllowLocalhostOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("Database"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowLocalhostOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<KmsHelper>();
builder.Services.AddSingleton<EncryptionService>();

builder.Services.AddSingleton<BinaryStringService>();


builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(AllowLocalhostOrigins);
} else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

