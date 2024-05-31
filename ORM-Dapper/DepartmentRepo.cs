using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly IDbConnection _conn;

        public DepartmentRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments");
        }
        public void InsertDepartments(string depName)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@depName)", new {depName});
        }
    }
}
