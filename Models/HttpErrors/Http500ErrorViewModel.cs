namespace TodoApp.Models.HttpErrors
{
    public class Http500ErrorViewModel : IHttpErrorViewModel
    {
        public int StatusCode => 500;
        public string Message => "Internal Server Error";
    }
}