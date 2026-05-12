using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IDashboardRepository
    {
        dynamic GetStats();
        IEnumerable<dynamic> GetDeptDistribution();
    }

    public class DashboardRepository : IDashboardRepository
    {
        private readonly IDbConnection _db;

        public DashboardRepository(IDbConnection db)
        {
            _db = db;
        }

        public dynamic GetStats()
        {
            return _db.QueryFirstOrDefault("sp_GetDashboardStats", commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<dynamic> GetDeptDistribution()
        {
            return _db.Query("sp_GetDepartmentDistribution", commandType: CommandType.StoredProcedure);
        }
    }
}
