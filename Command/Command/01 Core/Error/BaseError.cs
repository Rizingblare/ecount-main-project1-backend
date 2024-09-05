using System;

namespace Command
{

    public abstract class BaseError : Exception
    {
        public int Code;
        public string Msg;
    }
}
