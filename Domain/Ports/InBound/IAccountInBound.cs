using ChartOfAccountsApi.Domain.Models.DTOs;

namespace ChartOfAccountsApi.Domain.Ports.InBound;
/*O que o domínio oferece para a API*/
public interface IAccountInBound
{
    Task<IEnumerable<AccountDto>> ListAccounts();
    Task AddAccount(AccountDto account);
}