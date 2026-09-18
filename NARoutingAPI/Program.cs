// creates WebApplicationBuilder object and any necessary configurations
var builder = WebApplication.CreateBuilder(args);
// builds WebApplication object
var app = builder.Build();


// Opens endpoint to OpenAPI (documentation for API)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


// temporarily redirects HTTP requests to HTTPS (adds security)
app.UseHttpsRedirection();


// define functionality for GET request w/ country code endpoint
app.MapGet("/{countryCode}", (string countryCode) =>
{
    // normalize input (trim whitespace and uppercase)
    var destination = countryCode.Trim().ToUpperInvariant();

    // validate input: return 400 Bad Request response if country code not in Graph (of North American countries)
    if (!TransitLogic.IsValidCountry(destination))
    {
        return Results.BadRequest(new { error = $"Invalid country code: {destination}" });
    }

    // input is valid -> find shortest route to destination from USA
    var route = TransitLogic.BFS(destination);

    // return destination and shortest route
    return Results.Ok(new
    {
        destination,
        list = route
    });
});

app.Run();