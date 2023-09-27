namespace AssignmentApi.Models
{
    public class PerDaySalary
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int MonthlySalary { get; set; }
        public int SalaryForDay { get; set; }
        public List<DailySummary>? dailySummary { get; set; }

        public class DailySummary
        {
            public string? WorkingDate { get; set; }
            public int TodayWorkingHrs { get; set; }
            public double perDaySalary { get; set; }
        }
    }
}
