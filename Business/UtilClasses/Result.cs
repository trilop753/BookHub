namespace Business.UtilClasses
{
    public class Result
    {
        public string Error { get; set; } = "";

        public bool IsSuccess()
        {
            return Error == "";
        }
    }
}
