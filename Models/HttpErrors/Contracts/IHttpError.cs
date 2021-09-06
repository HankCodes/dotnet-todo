namespace TodoApp.Models.HttpErrors
{
    public interface IHttpError
    {
        int StatusCode { get; }
        string Message { get; }
    }
}