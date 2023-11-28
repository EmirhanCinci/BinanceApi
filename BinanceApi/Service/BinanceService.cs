using BinanceApi.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace BinanceApi.Service
{
    public class BinanceService
    {
        private readonly BinanceDbContext _dbContext;
        private readonly IHubContext<HubService> _hubService;
        private Timer _timer;
        public BinanceService(BinanceDbContext dbContext, IHubContext<HubService> hubService)
        {
            _dbContext = dbContext;
            _hubService = hubService;
        }

        public async Task GetAndSaveKlinesAsync()
        {

            string endpoint = "https://api.binance.com/api/v3/klines";
            string symbol = "BTCUSDT";
            string interval = "1s"; //bir barın süresi
            int limit = 1;   
            var klineData = await GetKlinesAsync(endpoint, symbol, interval, limit);

            //sembol ekleniyor
            foreach (var kline in klineData)
            {
                kline.Symbol = symbol;
                
            }


          DateTime now = DateTime.UtcNow;

            // Sadece tarih, saat ve dakika bilgilerini içeren bir DateTime örneği oluştur
            DateTime currentDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            long currentTimestamp = (long)currentDateTime.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;

            // KlineData koleksiyonunda bu tarih ve saatte bir öğe var mı kontrol et
            if (!_dbContext.Klines.Any(x => x.OpenTime == currentTimestamp))
            {
                _dbContext.Klines.AddRange(klineData);
                await _dbContext.SaveChangesAsync();
            }


        }


        public async Task<List<Kline>> GetKlinesAsync(string endpoint, string symbol, string interval, int limit)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{endpoint}?symbol={symbol}&interval={interval}&limit={limit}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var klineData = JsonConvert.DeserializeObject<List<List<object>>>(content);


                    var klines = new List<Kline>();
                    foreach (var data in klineData)
                    {
                        var kline = new Kline
                        {

                            OpenTime = Convert.ToInt64(data[0]),
                            Open = Convert.ToString(data[1]),
                            Close = Convert.ToString(data[4]),
                            Volume = Convert.ToString(data[5]),

                        };

                        klines.Add(kline);
                    }

                    return klines;

                }
                else
                {
                    // Hata işlemleri burada yapılabilir.
                    return null;
                }
            }
        }
      


    }
}
