namespace RestAPITesterWebApp.Services;

public class HttpGetTestingService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<HttpGetTestingService> _logger;

    public HttpGetTestingService(IHttpClientFactory httpClientFactory, ILogger<HttpGetTestingService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<(bool, string)> TestHealthCheck(string endpoint)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());
            
            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            var errorMessage = ex.Message;

            _logger.LogError("Error with message {Message} has been thrown", errorMessage);

            return (false, errorMessage);
        }
    }
}
