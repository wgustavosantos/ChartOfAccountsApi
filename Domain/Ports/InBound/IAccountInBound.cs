using ChartOfAccountsApi.Adapters.InboundAdapters.RestAdapters.DTOs;
using ChartOfAccountsApi.Domain.Models;

namespace ChartOfAccountsApi.Domain.Ports.InBound;
/*O que o domínio oferece para a API*/
public interface IAccountInBound
{
    Task<IEnumerable<AccountDto>> ListAccounts();
    Task AddAccount(Account account);
}