using Dapper;
using static ConnectionHelper;

public static class ConnectionStringExt
{
    public static Func<object, IEnumerable<T>> Retrieve<T>
    (
        this ConnectionString connStr,
        SqlTemplate sql
    )
    => param
    => Connect(connStr, conn => conn.Query<T>(sql, param));

}