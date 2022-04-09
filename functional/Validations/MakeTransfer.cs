namespace functional;

public record MakeTransfer
(
    Guid DebitedAccountId,
    string? Beneficiary,
    string? Iban,
    string? Bic,
    DateTime Date,
    decimal Amount,
    string? Reference,
    DateTime Timestamp = default
)
: Command(Timestamp)
{
    internal static MakeTransfer Dummy
        => new MakeTransfer(default, default, default, default, default, default,
                            default, default);
}
