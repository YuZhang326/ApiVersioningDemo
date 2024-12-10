using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    // If no version is specified, the default version is used
    options.AssumeDefaultVersionWhenUnspecified = true;
    // The default API version is 1.0
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    // Report the supported API versions in the response header
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        // Read the version from the query string parameter
        // new QueryStringApiVersionReader("api-version"),
        // Read the version from the media type
        // new MediaTypeApiVersionReader("ver"),
        // Read the version from the request header
        new HeaderApiVersionReader("x-version")
    );
});

builder.Services.AddVersionedApiExplorer(options =>
{
    // API version format, such as v1, v2
    options.GroupNameFormat = "'v'VVV";
    // Replace the version in the URL
    options.SubstituteApiVersionInUrl = true;
});

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
