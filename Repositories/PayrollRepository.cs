using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IPayrollRepository
    {
        IEnumerable<dynamic> GetAllPayslips(int month, int year);
        IEnumerable<dynamic> GetPayslipsByEmployee(int employeeId);
        void UpsertEmployeeSalary(dynamic req);
    }

    public class PayrollRepository : IPayrollRepository
    {
        private readonly IDbConnection _db;

        public PayrollRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetAllPayslips(int month, int year)
        {
            var p = new DynamicParameters();
            p.Add("@Month", month);
            p.Add("@Year", year);
            return _db.Query("sp_GetAllPayslips", p, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<dynamic> GetPayslipsByEmployee(int employeeId)
        {
            var p = new DynamicParameters();
            p.Add("@EmployeeId", employeeId);
            return _db.Query("sp_GetPayslipsByEmployee", p, commandType: CommandType.StoredProcedure);
        }

        public void UpsertEmployeeSalary(dynamic req)
        {
            var p = new DynamicParameters();
            p.Add("@EmployeeId", req.EmployeeId);
            p.Add("@ComponentId", req.ComponentId);
            p.Add("@Amount", req.Amount);
            
            _db.Execute("sp_UpsertEmployeeSalary", p, commandType: CommandType.StoredProcedure);
        }
    }
}
