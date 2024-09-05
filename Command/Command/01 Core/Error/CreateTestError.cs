namespace Command
{
    public class CreateTestError : BaseError
    {
        public CreateTestError(string msg)
        {
            base.Code = 2000;
            base.Msg = msg;
        }
    }
}