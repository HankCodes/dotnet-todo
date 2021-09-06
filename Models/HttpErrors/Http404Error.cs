namespace TodoApp.Models.HttpErrors
{
    public class Http404Error : System.Exception, IHttpError
    {
        public int StatusCode => 404;
        public Http404Error(string message = "Not Found")
        : base(message)
        {
        }
    }
}