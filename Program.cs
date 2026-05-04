using ChartOfAccountsApi.Domain.Models.DTOs;
using ChartOfAccountsApi.Domain.Ports.InBound;
using ChartOfAccountsApi.Domain.Ports.OutBound;
using ChartOfAccountsApi.Domain.UseCases;
using ChartOfAccountsApi.Service.OutBoundAdapters.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountInBound, AccountUseCase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// Grupo de rotas para organizar o prefixo /api/accounts
var accountRoutes = app.MapGroup("/api/accounts");
// GET: Listar todas as contas (Equivalente ao @GetMapping)
accountRoutes.MapGet("/", async (IAccountInBound useCase) =>
{
    var accounts = await useCase.ListAccounts();
    return Results.Ok(accounts);
});
// POST: Criar uma nova conta (Equivalente ao @PostMapping)
accountRoutes.MapPost("/", async (AccountDto accountDto, IAccountInBound useCase) =>
{
    // Chama a lógica de criação que você implementou no UseCase
    await useCase.AddAccount(accountDto);
    
    // Retorna 201 Created
    return Results.Created($"/api/accounts/{accountDto.CodeAccount}", accountDto);
});
app.Run();
