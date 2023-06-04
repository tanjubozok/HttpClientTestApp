namespace HttpClientTest.Common.ResponseObjects;

public class Response : IResponse
{
    public Response(ResponseType responseType)
    {
        this.ResponseTypes = responseType;
    }

    public Response(ResponseType responseType, string message)
    {
        this.ResponseTypes = responseType;
        this.Message = message;
    }

    public string? Message { get; set; }
    public ResponseType ResponseTypes { get; set; }
}
