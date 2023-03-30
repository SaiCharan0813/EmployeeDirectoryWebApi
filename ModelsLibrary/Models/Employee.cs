using System;
using System.Collections.Generic;

namespace EmployeeDirectoryApp.Models;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PrefferedName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string JobTitleId { get; set; } = null!;

    public string OfficeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public decimal CellNumber { get; set; }

    public string SkypeId { get; set; } = null!;

    public string Image { get; set; } = null!;
}
