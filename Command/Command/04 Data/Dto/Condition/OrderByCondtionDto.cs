﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class OrderByConditionDto
    {
        public string FieldName { get; set; }
        public string SortDirection { get; set; } = "ASC";
    }
}
