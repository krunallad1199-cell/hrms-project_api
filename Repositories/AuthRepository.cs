using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IAuthRepository
    {
        dynamic ValidateUser(string username, string passwordHash);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnection _db;

        public AuthRepository(IDbConnection db)
        {
            _db = db;
        }

        public dynamic ValidateUser(string username, string passwordHash)
        {
            var p = new DynamicParameters();
            p.Add("@Username", username);
            p.Add("@PasswordHash", passwordHash);
            
            return _db.QueryFirstOrDefault("sp_ValidateUser", p, commandType: CommandType.StoredProcedure);
        }
    }
}
