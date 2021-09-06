namespace TodoApp.Models.HttpErrors
{
    public interface IHttpErrorViewModel
    {
        int StatusCode { get; }
        string Message { get; }
    }
}