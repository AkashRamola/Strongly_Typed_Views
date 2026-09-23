using System;
using System.Collections.Generic;

namespace Strongly_Typed_Views.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public double Salary { get; set; }
}
