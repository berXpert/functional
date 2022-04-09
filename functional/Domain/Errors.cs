using LaYumba.Functional;

public static class Errors{

    public static Error TransferDateIsPast
        => new TransferDateIsPastError();

}

public sealed record TransferDateIsPastError()
    : Error("Transfer date cannot be in the past");