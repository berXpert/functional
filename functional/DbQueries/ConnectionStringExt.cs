using Dapper;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using static ConnectionHelper;
using Unit = System.ValueTuple;


public static class ConnectionStringExt
{
    public static Func<object, IEnumerable<T>> Retrieve<T>
    (
        this ConnectionString connStr,
        SqlTemplate sql
    )
    => param
    => Connect(connStr, conn => conn.Query<T>(sql, param));

    public static Func<SqlTemplate, object, IEnumerable<T>>
      Query<T>(this ConnectionString connString)
         => (sql, param)
         => Connect(connString, conn => conn.Query<T>(sql, param));

    public static void Execute(this ConnectionString connString
       , SqlTemplate sql, object param)
       => Connect(connString, conn => conn.Execute(sql, param));


    public static Func<     SqlTemplate
                           , object
                           , Exceptional<Unit>>
         TryExecute( this ConnectionString conn)
          => (sql, t) =>
         {
             try { conn.Execute(sql, t); }
             catch (Exception ex) { return ex; }
             return Unit();
         };
}