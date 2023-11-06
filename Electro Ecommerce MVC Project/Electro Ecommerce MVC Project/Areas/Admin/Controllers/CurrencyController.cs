using Electro_Ecommerce_MVC_Project.Contracts;
using Electro_Ecommerce_MVC_Project.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.Controllers;

[Route("admin/api")]
[Area("admin")]


public class CurrencyController : Controller
{
    private IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<CurrencyController> _logger;

    public CurrencyController(
        IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<CurrencyController> logger)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        _logger.LogWarning("===========Request to endpoint started");

        var httpClient = _httpClientFactory.CreateClient();
        var apiBase = _configuration.GetSection("CurrencyApiBase").Value;
        var apiKey = _configuration.GetSection("CurrencyApiKey").Value;

        var uriBuilder = new UrlBuilder(apiBase);
        var endpoint = uriBuilder
            .AddQuery("access_key", apiKey)
            .Build();

        var currencyResult = await httpClient.GetFromJsonAsync<CurrencyResult>(endpoint);

        _logger.LogWarning("============Request to endpoint completed");

        return View(currencyResult);
    }
}




//private IHttpClientFactory _httpClientFactory;

//public CurrencyController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}
//[HttpGet("list")]
//public async Task<IActionResult> List()
//{
//    var httpClient = _httpClientFactory.CreateClient();
//    var httpresponce = await httpClient.GetAsync("http://data.fixer.io/api/latest?access_key=dfedf3710b60b0b63d54c5cfe4ab959e");
//    var hattpresponceContent = await httpresponce.Content.ReadAsStringAsync();
//    return Content(hattpresponceContent);
//}