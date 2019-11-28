using System.Collections.Generic;

namespace XPike.DataStores.MultiTenant
{
    /// <summary>
    /// "XPike": {
    ///     "DataStores": {
    ///         "MultiTenant": {
    ///             "ConnectionSettings": {
    ///                 "ExampleDB": {
    ///                     "DEFAULT": "user=id;password=pw;server=127.0.0.1;database=master",
    ///                     "Tenant1": "user=id2;password=wp;server=127.0.0.2;database=master"
    ///                 }
    ///             }
    ///         }
    ///     }
    /// }
    /// </summary>
    public class ConnectionSettings
    {
        /// <summary>
        /// NOTE: ConnectionString == Databases[DatabaseName][TenantId] ?? Databases[DatabaseName]["DEFAULT"]
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> Databases { get; set; }
    }
}