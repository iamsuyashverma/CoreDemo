using System;
using System.Collections.Generic;

namespace AssignmentApi.Models;

public partial class TblDailySummary
{
    public long Id { get; set; }

    public long? EmployeeId { get; set; }

    public DateTime? WorkingDate { get; set; }

    public double? TodayWorkingHrs { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? IsDelete { get; set; }

    public virtual TblEmployee? Employee { get; set; }
}
