﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommand <TRequest, TResult> : IExecutable
    where TRequest : BaseRequest
    where TResult : BaseResponse
    { }
}
