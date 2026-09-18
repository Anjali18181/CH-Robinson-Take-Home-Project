// creates WebApplicationBuilder object and any necessary configurations
var builder = WebApplication.CreateBuilder(args);
// builds WebApplication object
var app = builder.Build();


// Opens endpoint to OpenAPI (documentation for API)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// redirects HTTP requests to HTTPS (adds security)
app.UseHttpsRedirection();

var routeHandler = new RoutingLogic();

app.MapGet("/{countryCode}", (string countryCode) =>
{
    // changes input into all uppercase
    var destination = countryCode.ToUpperInvariant();

    // validate country code is in Map
    if (!routeHandler.IsValidCountry(destination))
    {
        return Results.BadRequest(new { error = "Invalid country code." });
    }

    // find shortest route
    var route = routeHandler.BFSRoute(destination);

    return Results.Ok(new
    {
        destination,
        list = route
    });
});

app.Run();