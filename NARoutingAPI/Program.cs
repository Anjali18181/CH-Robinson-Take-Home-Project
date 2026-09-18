// creates WebApplicationBuilder object and any necessary configurations
var builder = WebApplication.CreateBuilder(args);
// builds WebApplication object
var app = builder.Build();


// Opens endpoint to OpenAPI (documentation for API)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// redirects HTTP requests to HTTPS (adds securityd)
app.UseHttpsRedirection();


app.Run();