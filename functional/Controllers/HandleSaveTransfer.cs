
using functional;
using LaYumba.Functional;
using static Microsoft.AspNetCore.Http.Results;

public static class Handlers
{
    public static Func<MakeTransfer, IResult> HandleSaveTransfer
    (
        Validator<MakeTransfer> validate,
        Func<MakeTransfer, Exceptional<uint>> save
    )
    => transfer
    => validate(transfer).Map(save).Match
    (
        Invalid: err => BadRequest(err),
        Valid: result => result.Match
        (
            Exception: _ => StatusCode(StatusCodes.Status500InternalServerError),
            Success: _ => Ok()
        )
    );
}