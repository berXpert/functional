using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace functional{
public delegate Validation<T> Validator<T>(T t);

public static class Validation{

public static Validator<MakeTransfer> DateNotPast(Func<DateTime> clock)
=> cmd
=> cmd.Date.Date < clock().Date
    ? Errors.TransferDateIsPast
    : Valid(cmd);
}
}
