using System.Data;

namespace HRMS.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _db;
        
        public IEmployeeRepository Employees { get; private set; }
        public IMasterRepository Masters { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }
        public IPayrollRepository Payroll { get; private set; }
        public IOnboardingRepository Onboarding { get; private set; }
        public IDashboardRepository Dashboard { get; private set; }
        public IAuthRepository Auth { get; private set; }
        public IDocumentRepository Documents { get; private set; }

        public UnitOfWork(IDbConnection db)
        {
            _db = db;
            
            // Initialize repositories with the shared connection
            Employees = new EmployeeRepository(_db);
            Masters = new MasterRepository(_db);
            Attendance = new AttendanceRepository(_db);
            Payroll = new PayrollRepository(_db);
            Onboarding = new OnboardingRepository(_db);
            Dashboard = new DashboardRepository(_db);
            Auth = new AuthRepository(_db);
            Documents = new DocumentRepository(_db);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
