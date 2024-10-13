using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class ApiGatewayTests
{
    private readonly HttpClient _client;

    public ApiGatewayTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("https://localhost:5000"); // API Gateway URL
    }

    // Test pour vérifier le routage vers le service Customers
    [Theory]
    [InlineData("GET", "/customers/info", 5001)]
    [InlineData("POST", "/customers/create", 5001)]
    [InlineData("PUT", "/customers/update", 5001)]
    [InlineData("DELETE", "/customers/delete", 5001)]
    public async Task Test_Customers_Routes(string method, string url, int downstreamPort)
    {
        var request = new HttpRequestMessage(new HttpMethod(method), url);
        var response = await _client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains($"localhost:{downstreamPort}", response.RequestMessage.RequestUri.ToString());
    }

    // Test pour vérifier le routage vers le service Orders
    [Theory]
    [InlineData("GET", "/orders/info", 5002)]
    [InlineData("POST", "/orders/create", 5002)]
    [InlineData("PUT", "/orders/update", 5002)]
    [InlineData("DELETE", "/orders/delete", 5002)]
    public async Task Test_Orders_Routes(string method, string url, int downstreamPort)
    {
        var request = new HttpRequestMessage(new HttpMethod(method), url);
        var response = await _client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains($"localhost:{downstreamPort}", response.RequestMessage.RequestUri.ToString());
    }

    // Test pour vérifier le routage vers le service Products
    [Theory]
    [InlineData("GET", "/products/info", 5003)]
    [InlineData("POST", "/products/create", 5003)]
    [InlineData("PUT", "/products/update", 5003)]
    [InlineData("DELETE", "/products/delete", 5003)]
    public async Task Test_Products_Routes(string method, string url, int downstreamPort)
    {
        var request = new HttpRequestMessage(new HttpMethod(method), url);
        var response = await _client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains($"localhost:{downstreamPort}", response.RequestMessage.RequestUri.ToString());
    }
}
