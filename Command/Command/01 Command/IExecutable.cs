﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface IExecutable
    {
        List<BaseError> Errors { get; }
        void Execute();
    }
}
