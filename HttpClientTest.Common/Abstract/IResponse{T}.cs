namespace HttpClientTest.Common.Abstract;

public interface IResponse<T> : IResponse
{
    T? Data { get; set; }
}
