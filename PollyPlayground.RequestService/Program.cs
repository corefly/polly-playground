using PollyPlayground.RequestService.Policies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient("Test").AddPolicyHandler(
    request => request.Method == HttpMethod.Get ? new ClientPolicy().ImmediateHttpRetry : new ClientPolicy().ImmediateHttpRetry);

builder.Services.AddSingleton<ClientPolicy>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapControllers();

app.Run();