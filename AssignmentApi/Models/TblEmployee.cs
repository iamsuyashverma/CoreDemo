using System;
using System.Collections.Generic;

namespace AssignmentApi.Models;

public partial class TblEmployee
{
    public long EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public decimal? MonthlySalary { get; set; }

    public decimal? SalaryForDay { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? IsDelete { get; set; }

    public virtual ICollection<TblDailySummary> TblDailySummaries { get; set; } = new List<TblDailySummary>();
}
