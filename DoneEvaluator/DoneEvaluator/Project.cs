﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoneEvaluator
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
