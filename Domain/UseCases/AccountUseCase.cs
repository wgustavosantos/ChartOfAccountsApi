using ChartOfAccountsApi.Domain.Models;
using ChartOfAccountsApi.Domain.Models.DTOs;
using ChartOfAccountsApi.Domain.Ports.InBound;
using ChartOfAccountsApi.Domain.Ports.OutBound;

namespace ChartOfAccountsApi.Domain.UseCases;

public class AccountUseCase : IAccountInBound
{
    private readonly IAccountRepository _accountRepository;

    public AccountUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<IEnumerable<AccountDto>> ListAccounts()
    {
        var accounts = await _accountRepository.GetAll();

        var accountDtos = accounts.Select(account =>
        {
            return new AccountDto(account.Id, account.CodeAccount, account.Name, account.IdSit, account.DhAtu,
                account.CdUsuAtu);
        });
        return accountDtos ;
    }
    
    public async Task AddAccount(AccountDto account)
    {
        var newAccount = new Account
        {
            Name = account.Name,
            CodeAccount = account.CodeAccount,
            IdSit = account.IdSit,
            DhAtu = DateTime.Now,
            CdUsuAtu = account.CdUsuAtu
        };
        
        await _accountRepository.Add(newAccount);
    }
}