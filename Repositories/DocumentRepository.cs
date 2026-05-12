using System.Collections.Generic;
using System.Data;
using Dapper;

namespace HRMS.API.Repositories
{
    public interface IDocumentRepository
    {
        IEnumerable<dynamic> GetDocumentsByEmployee(int employeeId);
        int SaveDocument(dynamic doc);
        void DeleteDocument(int id);
    }

    public class DocumentRepository : IDocumentRepository
    {
        private readonly IDbConnection _db;

        public DocumentRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetDocumentsByEmployee(int employeeId)
        {
            var p = new DynamicParameters();
            p.Add("@EmployeeId", employeeId);
            return _db.Query("sp_GetEmployeeDocuments", p, commandType: CommandType.StoredProcedure);
        }

        public int SaveDocument(dynamic doc)
        {
            var p = new DynamicParameters();
            p.Add("@EmployeeId", doc.EmployeeId);
            p.Add("@DocumentType", doc.DocumentType);
            p.Add("@FileName", doc.FileName);
            p.Add("@FilePath", doc.FilePath);

            return _db.ExecuteScalar<int>("sp_SaveEmployeeDocument", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteDocument(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id);
            _db.Execute("sp_DeleteEmployeeDocument", p, commandType: CommandType.StoredProcedure);
        }
    }
}
