namespace ChartOfAccountsApi.Domain.Models.DTOs;

public record AccountDto(
    int Id,
    string CodeAccount,
    string Name,
    string IdSit,
    DateTime DhAtu,
    string CdUsuAtu);
