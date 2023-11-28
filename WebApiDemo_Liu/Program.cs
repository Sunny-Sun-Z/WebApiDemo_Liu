var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Routing

// "/shirts"
app.MapGet("/shirts", () =>
{
    return "Reading all the shirts.";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading shirt with id: {id}";
});

app.MapPost("/shirts", ( ) =>{
    return $"Create a shirt";
});

app.MapPut("/shirts/{id}", (int id) =>
{
    return "Update a shirt with id: {id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Delete shirt with id: {id}";
});





app.Run();


