using Example.Library.DataStores.MySql.Records;
using Example.Library.Models;
using XPike.Contracts;

namespace Example.Library.DataStores.MySql
{
    internal interface IMySqlExampleRecordMapper
        : IMapRecord<MySqlUserRecord, User>,
          IMapModel<User, MySqlUserRecord>,
          IMapRecord<MySqlContactInfoRecord, ContactInfo>,
          IMapModel<ContactInfo, MySqlContactInfoRecord>,
          IMap<int, UserType>,
          IMap<UserType, int>
    {
    }
}