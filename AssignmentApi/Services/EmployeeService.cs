using AssignmentApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private MyDBContext _dbContext;
        public EmployeeService(MyDBContext context) { _dbContext = context; }
        public long AddEmployee(TblEmployee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
            return employee.EmployeeId;        
        }

        public TblEmployee GetEmployee(long employeeId)
        {
            return _dbContext.TblEmployees.Where(e => e.EmployeeId == employeeId).Include("TblDailySummaries").SingleOrDefault();
        }

        public IEnumerable<TblEmployee> GetEmployees()
        {
            return _dbContext.TblEmployees;
        }

        public void DeleteEmployee(long employeeId)
        {
            var employee = _dbContext.TblEmployees.Where(e => e.EmployeeId == employeeId).Include("TblDailySummaries").SingleOrDefault();
            if(employee  != null) {
                _dbContext.TblEmployees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }
    }
}
