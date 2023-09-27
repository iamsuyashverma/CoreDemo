using AssignmentApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.Services
{
    public interface IDailySummaryService
    {
        public long AddDailySummary(TblDailySummary summary);
        public TblDailySummary GetDailySummary(long employeeId);
        public IEnumerable<PerDaySalary> GetPerDaySalary(long employeeId);
        public void DeleteDailySummary(long Id);
    }
}
