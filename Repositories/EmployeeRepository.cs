using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<dynamic> GetEmployees();
        void UpsertEmployee(dynamic emp);
        void DeleteEmployee(int id);
        void ArchiveEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;

        public EmployeeRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetEmployees()
        {
            return _db.Query("sp_GetEmployees", commandType: CommandType.StoredProcedure);
        }

        public void UpsertEmployee(dynamic emp)
        {
            var p = new DynamicParameters();
            p.Add("@Id", emp.Id);
            p.Add("@EmployeeCode", emp.EmployeeCode);
            p.Add("@FirstName", emp.FirstName);
            p.Add("@LastName", emp.LastName);
            p.Add("@Email", emp.Email);
            p.Add("@DeptId", emp.DeptId);
            p.Add("@DesigId", emp.DesigId);
            p.Add("@DateOfJoining", emp.DateOfJoining);
            p.Add("@IsActive", emp.IsActive);

            _db.Execute("sp_UpsertEmployee", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteEmployee(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            _db.Execute("sp_DeleteEmployee", p, commandType: CommandType.StoredProcedure);
        }

        public void ArchiveEmployee(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            _db.Execute("sp_ArchiveEmployee", p, commandType: CommandType.StoredProcedure);
        }
    }
}
