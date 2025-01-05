using System;
using System.Collections.Generic;

namespace DatabasLab3.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? Description { get; set; }
    public string? Activity {  get; set; }
}
