using functional;
using static functional.Validation;
using static LaYumba.Functional.F;

public static class Configure
{
 static Func<MakeTransfer, IResult> ConfigureSaveTransferHandler(IConfiguration config)
     {
         ConnectionString connectionString = config.GetSection("ConnectionString").Value;

         SqlTemplate insertTransferSql = "Insert into transfer ...";

         var save = connectionString.TryExecute(insertTransferSql);
         //var save = Exceptional(Unit());
         var validate = DateNotPast(()=>DateTime.UtcNow);

         return Handlers.HandleSaveTransfer(validate, save);
     }
}