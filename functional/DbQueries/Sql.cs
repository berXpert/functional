using LaYumba.Functional;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

public static class Sql
{
    public static Func<ConnectionString
                           , SqlTemplate
                           , object
                           , Exceptional<Unit>>
         TryExecute => (conn, sql, t) =>
         {
             try { conn.Execute(sql, t); }
             catch (Exception ex) { return ex; }
             return Unit();
         };
}