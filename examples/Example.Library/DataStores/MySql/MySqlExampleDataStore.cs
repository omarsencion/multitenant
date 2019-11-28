using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Example.Library.DataStores.MySql.Records;
using Example.Library.Models;
using XPike.DataStores;
using XPike.DataStores.Dapper;
using XPike.DataStores.MultiTenant;
using XPike.DataStores.MySql;
using XPike.DataStores.MySql.Pomelo;

namespace Example.Library.DataStores.MySql
{
    public class MySqlExampleDataStore
        : DapperDataStoreBase,
          IMySqlExampleDataStore
    {
        private static readonly IMySqlExampleRecordMapper _mapper = new MySqlExampleRecordMapper();

        protected override string ConnectionString => "ExampleDB";

        public MySqlExampleDataStore(IMySqlDataConnectionProvider provider, IMultiTenantConnectionStringManager connectionStringManager)
            : base(provider, connectionStringManager)
        {
        }

        public Task<User> GetExampleAsync(int id) =>
            WithSqlConnectionAsync(async connection =>
                (await connection.QueryAsync<MySqlUserRecord, MySqlContactInfoRecord, User>(
                    MySqlExampleDataStoreSql.GET_USER_SQL,
                    (u, c) =>
                    {
                        u.ContactInfo = c;
                        return _mapper.Map(u);
                    },
                    new
                    {
                        id
                    }, 
                    splitOn:"ContactId"))
                .SingleOrDefault());

        public Task<int?> CreateExampleAsync(User model) =>
            WithSqlConnectionAsync(async connection =>
                                       (await connection.QueryAsync<int?>(MySqlExampleDataStoreSql.CREATE_USER_SQL, _mapper.Map(model)))
                                       .SingleOrDefault());

        public Task<bool> DeleteExampleAsync(int id) =>
            WithSqlConnectionAsync(async connection => (await connection.QueryAsync<int?>(MySqlExampleDataStoreSql.DELETE_USER_SQL,
                                                                                          new
                                                                                          {
                                                                                              id
                                                                                          }))
                                                       .SingleOrDefault() > 0);

        public Task<bool> UpdateExampleAsync(User model) =>
            WithSqlConnectionAsync(async connection => (await connection.QueryAsync<int?>(MySqlExampleDataStoreSql.UPDATE_USER_SQL, _mapper.Map(model)))
                                                       .SingleOrDefault() > 0);
    }
}