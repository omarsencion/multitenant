using Example.Library.Models;
using XPike.Contracts;

namespace Example.Library.DataStores.MySql.Records
{
    internal class MySqlContactInfoRecord
        : IRecord
    {
        public string EmailAddress { get; set; }

        public string PhoneNumber { get;set; }

        public int UserId { get; set; }

        public int ContactId { get; set; }

        public MySqlUserRecord User { get; set; }
    }
}