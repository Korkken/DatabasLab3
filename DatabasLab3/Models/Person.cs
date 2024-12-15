using System;
using System.Collections.Generic;

namespace DatabasLab3.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Ssn { get; set; }

    public string? Assignment { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Class> ClassesNavigation { get; set; } = new List<Class>();
}
