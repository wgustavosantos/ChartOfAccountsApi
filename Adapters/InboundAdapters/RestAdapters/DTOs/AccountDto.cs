namespace ChartOfAccountsApi.Adapters.InboundAdapters.RestAdapters.DTOs;

public record AccountDto(
    int Id,
    string CodeAccount,
    string Name,
    string IdSit,
    DateTime DhAtu,
    string CdUsuAtu);
