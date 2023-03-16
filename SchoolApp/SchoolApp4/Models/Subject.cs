﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp4.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
