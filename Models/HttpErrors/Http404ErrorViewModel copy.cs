namespace TodoApp.Models.HttpErrors
{
    public class Http404ErrorViewModel : IHttpErrorViewModel
    {
        public int StatusCode => 404;
        public string Message { get; private set; }

        public Http404ErrorViewModel(string message = "Resource Not Found")
        {
            Message = message;
        }
    }
}