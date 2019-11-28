using XPike.DataStores.Dapper;

namespace Example.Library.DataStores.MySql
{
    public interface IMySqlExampleDataStore
        : IDapperDataStore,
          IExampleDataStore
    {
    }
}