namespace HttpClientTest.Common.Abstract;

public interface IResponse
{
    string? Message { get; set; }
    ResponseType ResponseTypes { get; set; }
}
