namespace HR_Management_WebAPI.Helpers
{
    public class CustomResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}