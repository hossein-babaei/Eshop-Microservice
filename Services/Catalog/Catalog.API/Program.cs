var builder = WebApplication.CreateBuilder(args);

//config carter package
builder.Services.AddCarter(
    new DependencyContextAssemblyCatalog(
        typeof(Program).Assembly,
        typeof(Program).Assembly
    )
);

//config MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();
//map carter endpoint
app.MapCarter();
app.Run();
