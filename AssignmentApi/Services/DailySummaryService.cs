using AssignmentApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AssignmentApi.Services
{
    public class DailySummaryService : IDailySummaryService
    {
        private MyDBContext _dbContext;
        public DailySummaryService(MyDBContext context) { _dbContext = context; }
        public long AddDailySummary(TblDailySummary summary)
        {
            _dbContext.Add(summary);
            _dbContext.SaveChanges();
            return summary.Id;
        }

        public TblDailySummary GetDailySummary(long employeeId)
        {
            return _dbContext.TblDailySummaries.Where(a => a.EmployeeId == employeeId ).Include("Employee").SingleOrDefault();
        }

        public IEnumerable<PerDaySalary> GetPerDaySalary(long employeeId)
        {
            var result = _dbContext.Database.SqlQueryRaw<string>("Exec sp_PerDaySalary @EmployeeID", new SqlParameter("@EmployeeID", employeeId));
            var data = result.ToList<string>();
            if(data.Count > 0)
            {
                return JsonConvert.DeserializeObject<IEnumerable<PerDaySalary>>(data[0]);
            }
            else
            {
                return null;
            }
            
        }

        public void DeleteDailySummary(long Id)
        {
            var dailySummary = _dbContext.TblDailySummaries.Where(e => e.EmployeeId == Id).SingleOrDefault();
            if (dailySummary != null)
            {
                _dbContext.TblDailySummaries.Remove(dailySummary);
                _dbContext.SaveChanges();
            }
        }
    }
}
