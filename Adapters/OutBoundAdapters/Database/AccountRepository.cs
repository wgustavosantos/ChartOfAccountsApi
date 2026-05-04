using ChartOfAccountsApi.Domain.Models;
using ChartOfAccountsApi.Domain.Ports.OutBound;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChartOfAccountsApi.Service.OutBoundAdapters.Database;

public class AccountRepository : IAccountRepository
{
    // Puxa a string de conexão do seu appsettings.json
    private readonly string? _connectionString;

    public AccountRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task<IEnumerable<Account>> GetAll()
    {
        var sqlConnection = new SqlConnection(_connectionString);
        return await sqlConnection.QueryAsync<Account>("select * from Account");
    }

    public async Task Add(Account account)
    {
        var sqlConnection = new SqlConnection(_connectionString);
        const string sql = @"INSERT INTO Account (CodeAccount, Name, IdSit, DhAtu, CdUsuAtu) 
                             VALUES (@CodeAccount, @Name, @IdSit, @DhAtu, @CdUsuAtu)";
        
        await sqlConnection.ExecuteAsync(sql, account);
    }
}