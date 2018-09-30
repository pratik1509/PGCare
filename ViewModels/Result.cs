namespace PGCare.ViewModels
{
    public class Result
    {
        public bool IsSucccess { get; set; } = true;
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object ResultData { get; set; }
    }
}