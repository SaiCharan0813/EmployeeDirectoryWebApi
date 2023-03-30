using System;
using System.Collections.Generic;

namespace EmployeeDirectoryApp.testDir;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PrefferedName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string Office { get; set; } = null!;

    public string Department { get; set; } = null!;

    public decimal PhoneNumber { get; set; }

    public string SkypeId { get; set; } = null!;

    public string Image { get; set; } = null!;
}
