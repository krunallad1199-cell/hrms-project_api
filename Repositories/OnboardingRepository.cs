using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IOnboardingRepository
    {
        dynamic GetOnboardingRequest(Guid token);
        IEnumerable<dynamic> GetPendingRequests();
        void SubmitOnboarding(dynamic req);
    }

    public class OnboardingRepository : IOnboardingRepository
    {
        private readonly IDbConnection _db;

        public OnboardingRepository(IDbConnection db)
        {
            _db = db;
        }

        public dynamic GetOnboardingRequest(Guid token)
        {
            var p = new DynamicParameters();
            p.Add("@Token", token);
            return _db.QueryFirstOrDefault("sp_GetOnboardingRequest", p, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<dynamic> GetPendingRequests()
        {
            return _db.Query("sp_GetPendingOnboardingRequests", commandType: CommandType.StoredProcedure);
        }

        public void SubmitOnboarding(dynamic req)
        {
            var p = new DynamicParameters();
            p.Add("@Token", req.Token);
            p.Add("@PersonalDetails", req.PersonalDetails);
            
            _db.Execute("sp_SubmitOnboarding", p, commandType: CommandType.StoredProcedure);
        }
    }
}
