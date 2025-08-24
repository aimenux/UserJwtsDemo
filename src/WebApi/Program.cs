using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Constants.Policies.AdminOnly, policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy(Constants.Policies.SuperUserOnly, policy =>
        policy.RequireRole("Admin").RequireRole("Manager"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app
    .MapGet("/user", (HttpContext context) =>
    {
        var user = User.Create(context);
        return Results.Ok(user);
    })
    .RequireAuthorization();

app
    .MapGet("/admin-user", (HttpContext context) =>
    {
        var adminUser = User.Create(context);
        return Results.Ok(adminUser);
    })
    .RequireAuthorization(Constants.Policies.AdminOnly);

app
    .MapGet("/super-user", (HttpContext context) =>
    {
        var superUser = User.Create(context);
        return Results.Ok(superUser);
    })
    .RequireAuthorization(Constants.Policies.SuperUserOnly);

await app.RunAsync();
