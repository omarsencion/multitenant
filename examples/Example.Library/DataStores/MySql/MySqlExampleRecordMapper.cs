using Example.Library.DataStores.MySql.Records;
using Example.Library.Models;
using XPike.Contracts;

namespace Example.Library.DataStores.MySql
{
    internal class MySqlExampleRecordMapper
        : IMySqlExampleRecordMapper
    {
        public User Map(MySqlUserRecord input) =>
            input == null
                ? null
                : new User
                  {
                      ContactInfo = Map(input.ContactInfo),
                      UserType = ((IMap<int, UserType>)this).Map(input.UserTypeId),
                      Created = input.Created,
                      Credits = input.Credits,
                      Enabled = input.Enabled,
                      Expires = input.Expires,
                      Name = input.Name,
                      UserLevel = input.UserLevel,
                      Id = input.Id
                  };

        public MySqlUserRecord Map(User input) =>
            input == null
                ? null
                : new MySqlUserRecord
                  {
                      ContactInfo = Map(input.ContactInfo),
                      Credits = input.Credits,
                      Id = input.Id,
                      Enabled = input.Enabled,
                      Name = input.Name,
                      Expires = input.Expires,
                      Created = input.Created,
                      UserLevel = input.UserLevel,
                      UserTypeId = ((IMap<UserType, int>) this).Map(input.UserType)
                  };

        public ContactInfo Map(MySqlContactInfoRecord input) =>
            input == null
                ? null
                : new ContactInfo
                  {
                      User = Map(input.User),
                      UserId = input.UserId,
                      ContactId = input.ContactId,
                      EmailAddress = input.EmailAddress,
                      PhoneNumber = input.PhoneNumber
                  };

        public MySqlContactInfoRecord Map(ContactInfo input) =>
            input == null
                ? null
                : new MySqlContactInfoRecord
                  {
                      User = Map(input.User),
                      EmailAddress = input.EmailAddress,
                      UserId = input.UserId,
                      ContactId = input.ContactId,
                      PhoneNumber = input.PhoneNumber
                  };

        int IMap<UserType, int>.Map(UserType input) =>
            (int) input;

        UserType IMap<int, UserType>.Map(int input) =>
            (UserType) input;
    }
}