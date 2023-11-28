using BinanceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RestSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection;
using BinanceApi.Service;
using Microsoft.EntityFrameworkCore;

namespace BinanceApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly BinanceService _binanceService;
        public HomeController(BinanceService binanceService)
        {
            _binanceService = binanceService;
            
        }

        public async Task<IActionResult> GetAndSaveKlines()
        {
            using var _context = new BinanceDbContext();

            await _binanceService.GetAndSaveKlinesAsync();
           
            var getList = await _context.Klines.ToListAsync();

            return View(getList);

        }



     
            //private readonly IHttpClientFactory _httpClientFactory;
            //private readonly string _baseUrl = "https://api.binance.com/api/v3/";
            //public HomeController(IHttpClientFactory httpClientFactory)
            //{
            //    _httpClientFactory = httpClientFactory;
            //}

            //public async Task<IActionResult> Index()
            //{
            //    var client = _httpClientFactory.CreateClient();
            //    string uri = "https://api.binance.com/api/v3/exchangeInfo";
            //    var requestMessage = new HttpRequestMessage()
            //    {
            //        Method = HttpMethod.Get,
            //        RequestUri = new Uri(uri),
            //        Headers = { { HeaderNames.Accept, "application/json" } }
            //    };

            //    var responseMessage = await client.SendAsync(requestMessage);
            //    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();


            //    var response = System.Text.Json.JsonSerializer.Deserialize<RootObject>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //        string coinSymbol = "";

            //        foreach (var item in response.Symbols)
            //        {

            //        coinSymbol = item.BaseAsset.ToString();
            //        var symbol = $"{coinSymbol}USDT";
            //        var interval = "2h"; // 1 saatlik candlestick verileri
            //        var limit = "2";
            //        var apiKey = "NOQH6S7gjxR1xda3q1XlUz7SYpZIjIaeDyt9UXrbQBBrNpP81gY2dXhcWI6P3QQR";
            //        var apiSecret = "zCeFEgRwC3kV0QNU68M80fnIoOGzxhdjQAYIP8jJdlYX4rUqPyO2htItnjv1G9UW";
            //        var candlestickData = GetCandlestickData(symbol, interval, limit,apiKey, apiSecret);

            //        var jsonSerializerSettings = new JsonSerializerSettings
            //        {
            //            FloatParseHandling = FloatParseHandling.Decimal
            //        };


            //        //veriyi jsona çevir.
            //        var jsonString = string.Join("", candlestickData);
            //        var dataObjects = JsonConvert.DeserializeObject<List<List<object>>>(jsonString, jsonSerializerSettings);

            //        // İlk ve son elemanları al
            //        var firstElement = dataObjects.First();
            //        var lastElement = dataObjects.Last();


            //        //4. index (kapanış fiyatı) üzerinden yüzdesel fiyat değişimi 

            //        decimal initialPrice = Convert.ToDecimal(firstElement[4]);
            //        decimal currentPrice = Convert.ToDecimal(lastElement[4]);

            //        // 5. index üzerinden işlemleri gerçekleştir(Volume)
            //        decimal initialVolume = Convert.ToDecimal(firstElement[5]);
            //        decimal currentVolume = Convert.ToDecimal(lastElement[5]);

            //        //coinin'nin fiyatsal değişimi hesaplanıyor(%)

            //        decimal priceChange=((currentPrice - initialPrice) /initialPrice)/100;

            //        //coinin'nin yüzdesel  hacim değişimi hesaplanıyor(%)
            //        decimal percentageChange = ((currentVolume - initialVolume) / initialVolume) / 100;



            //        ViewBag.percentageChange = percentageChange;
            //        ViewBag.priceChange = priceChange;

            //    }

            //    return View();
            //}



            //static List<string> GetCandlestickData(string symbol, string interval,string limit,string apiKey,string apiSecret)
            //{
            //    var client = new RestClient("https://api.binance.com");

            //    var request = new RestRequest("/api/v3/klines");
            //    request.AddQueryParameter("symbol", symbol);
            //    request.AddQueryParameter("interval", interval);
            //    request.AddQueryParameter("limit", limit);

            //    request.AddHeader("X-MBX-APIKEY", apiKey);

            //    // İmza oluşturmak ve güvenlik kontrolleri yapmak için ek adımlar gerekli
            //    // ...

            //    var response = client.Get(request);

            //    List<string> result = ConvertResponseToList(response.Content);

            //    return result;
            //}
            //static List<string> ConvertResponseToList(string content)
            //{
            //    // Satır satır bölen bir metod kullanabilirsiniz
            //    List<string> lines = new List<string>(content.Split("\n"));

            //    return lines;
            //}

        }
}