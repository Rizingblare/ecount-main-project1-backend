namespace Command
{
    public class CommandResultWithBody<T> : BaseResponse
    {
        public T Body { get; set; }
    }
}
