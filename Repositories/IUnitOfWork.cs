using System;

namespace HRMS.API.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IMasterRepository Masters { get; }
        IAttendanceRepository Attendance { get; }
        IPayrollRepository Payroll { get; }
        IOnboardingRepository Onboarding { get; }
        IDashboardRepository Dashboard { get; }
        IAuthRepository Auth { get; }
        IDocumentRepository Documents { get; }
    }
}
