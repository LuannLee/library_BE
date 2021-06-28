namespace library_BE.ViewModels.Response
{
    public class Response <T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
