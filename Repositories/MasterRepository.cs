using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IMasterRepository
    {
        IEnumerable<dynamic> GetDepartments();
        IEnumerable<dynamic> GetDesignations();
    }

    public class MasterRepository : IMasterRepository
    {
        private readonly IDbConnection _db;

        public MasterRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetDepartments()
        {
            return _db.Query("sp_GetDepartments", commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<dynamic> GetDesignations()
        {
            return _db.Query("sp_GetDesignations", commandType: CommandType.StoredProcedure);
        }
    }
}
