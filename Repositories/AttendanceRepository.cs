using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<dynamic> GetDailyAttendance(DateTime date);
        void UpsertAttendance(dynamic att);
    }

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IDbConnection _db;

        public AttendanceRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetDailyAttendance(DateTime date)
        {
            var p = new DynamicParameters();
            p.Add("@AttendanceDate", date.Date);
            return _db.Query("sp_GetDailyAttendance", p, commandType: CommandType.StoredProcedure);
        }

        public void UpsertAttendance(dynamic att)
        {
            var p = new DynamicParameters();
            p.Add("@EmployeeId", att.EmployeeId);
            p.Add("@LogDate", att.LogDate.Date);
            p.Add("@CheckIn", att.CheckIn);
            p.Add("@CheckOut", att.CheckOut);
            p.Add("@Status", att.Status);
            
            _db.Execute("sp_UpsertAttendance", p, commandType: CommandType.StoredProcedure);
        }
    }
}
