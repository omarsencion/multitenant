using System;
using Example.Library.Models;
using XPike.Contracts;

namespace Example.Library.DataStores.MySql.Records
{
    internal class MySqlUserRecord
        : IRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        public decimal Credits { get; set; }
        
        public DateTime Created { get; set; }
        
        public bool Enabled { get; set; }
        
        public int UserTypeId { get; set; }
        
        public DateTime? Expires { get; set; }

        public int UserLevel { get; set; }

        public MySqlContactInfoRecord ContactInfo { get; set; }
    }
}