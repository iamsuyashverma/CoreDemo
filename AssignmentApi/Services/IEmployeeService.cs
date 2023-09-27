using AssignmentApi.Models;

namespace AssignmentApi.Services
{
    public interface IEmployeeService
    {
        public long AddEmployee(TblEmployee employee);
        public TblEmployee GetEmployee(long employeeId);
        public IEnumerable<TblEmployee> GetEmployees();
        public void DeleteEmployee(long employeeId);
    }
}
