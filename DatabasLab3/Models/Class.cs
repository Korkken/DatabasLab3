using System;
using System.Collections.Generic;

namespace DatabasLab3.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? TeacherId { get; set; }

    public virtual Person? Teacher { get; set; }

    public virtual ICollection<Person> Students { get; set; } = new List<Person>();
}
