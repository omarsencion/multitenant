using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace XPike.DataStores.MultiTenant
{
    /// <summary>
    /// "XPike": {
    ///     "DataStores": {
    ///         "MultiTenant": {
    ///             "ConnectionConfig": {
    ///                 "ExampleDB": {
    ///                     "DEFAULT": "user=id;password=pw;server=127.0.0.1;database=master",
    ///                     "Tenant1": "user=id2;password=wp;server=127.0.0.2;database=master"
    ///                 }
    ///             }
    ///         }
    ///     }
    /// }
    /// </summary>
    [Serializable]
    [DataContract]
    public class ConnectionConfig
    {
        /// <summary>
        /// NOTE: ConnectionString == Databases[DatabaseName][TenantId] ?? Databases[DatabaseName]["DEFAULT"]
        /// </summary>
        [DataMember]
        public Dictionary<string, Dictionary<string, string>> Databases { get; set; }
    }
}