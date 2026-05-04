using ChartOfAccountsApi.Domain.Models;

namespace ChartOfAccountsApi.Domain.Ports.OutBound;
/*O que a camada de domínio manda para o banco de dados*/
public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAll();
    Task Add(Account account);
}