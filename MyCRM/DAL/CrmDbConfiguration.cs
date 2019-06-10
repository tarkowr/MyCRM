using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;

namespace MyCRM.DAL
{
    public class CrmDbConfiguration : DbConfiguration
    {
        public CrmDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new CrmInterceptorLogging());
        }
    }
}