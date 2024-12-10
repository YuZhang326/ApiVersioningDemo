using System.Net;
using System.Net.Http.Json;
using ApiVersioningApp;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace ApiVersioningTest;

public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ShouldReturnWeatherForecasts_WithApiVersion1()
    {
        // Arrange
        var requestUrl = "/api/v1/WeatherForecast";

        // Act
        var response = await _client.GetAsync(requestUrl);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        forecasts.Should().NotBeNull();
        forecasts.Should().HaveCount(5);
        forecasts.Should().OnlyContain(f => f.Summary == "ApiVersion V1.0");
    }

    [Fact]
    public async Task Get_ShouldReturnWeatherForecastV2_0()
    {
        // Arrange
        var requestUrl = "/api/v2.0/WeatherForecast";

        // Act
        var response = await _client.GetAsync(requestUrl);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        forecasts.Should().NotBeNull();
        forecasts.Should().HaveCount(5);
        forecasts.Should().OnlyContain(f => f.Summary == "ApiVersion V2.0");
    }

    [Fact]
    public async Task GetV21_ShouldReturnWeatherForecastV2_1()
    {
        // Arrange
        var requestUrl = "/api/v2.1/WeatherForecast";

        // Act
        var response = await _client.GetAsync(requestUrl);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        forecasts.Should().NotBeNull();
        forecasts.Should().HaveCount(5);
        forecasts.Should().OnlyContain(f => f.Summary == "ApiVersion V2.1");
    }
}
