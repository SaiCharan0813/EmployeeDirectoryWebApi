using System;
using System.Collections.Generic;

namespace EmployeeDirectoryApp.Models;

public partial class JobTitle
{
    public int JobTitleId { get; set; }

    public string JobTitleName { get; set; } = null!;
}
