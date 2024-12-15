using System;
using System.Collections.Generic;

namespace DatabasLab3.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? PersonId { get; set; }

    public int? CourseId { get; set; }

    public int? Grade1 { get; set; }

    public DateOnly? GradeDate { get; set; }

    public int? TeacherId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Person? Teacher { get; set; }
}
