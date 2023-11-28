using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Binance.Net;
namespace AddData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Binance API anahtarlarınızı buraya ekleyin
            string apiKey = "YOUR_API_KEY";
            string apiSecret = "YOUR_API_SECRET";

            // BinanceClient'ı oluşturun
            var client = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials(apiKey, apiSecret),
            });

            // exchangeInfo endpoint'ini kullanarak mevcut tüm işlem çiftlerini alın
            var exchangeInfo = await client.Spot.System.GetExchangeInfoAsync();
            var symbols = exchangeInfo.Data.Symbols.Select(s => s.Name).ToList();

            // Veritabanına bağlanın
            using (var dbContext = new YourDbContext()) // YourDbContext, Entity Framework ile oluşturduğunuz bağlam sınıfını temsil eder
            {
                // Her bir işlem çifti için veri çekin ve veritabanına kaydedin
                foreach (var symbol in symbols)
                {
                    var candles = await client.Spot.Market.GetKlinesAsync(symbol, KlineInterval.OneHour);

                    foreach (var candle in candles.Data)
                    {
                        var dbRecord = new CandleRecord
                        {
                            Symbol = symbol,
                            OpenTime = DateTimeOffset.FromUnixTimeMilliseconds(candle.OpenTime).UtcDateTime,
                            Open = candle.Open,
                            High = candle.High,
                            Low = candle.Low,
                            Close = candle.Close,
                            Volume = candle.Volume
                        };

                        // Veritabanına kaydet
                        dbContext.Candles.Add(dbRecord);
                    }
                }

                // Değişiklikleri kaydet
                await dbContext.SaveChangesAsync();
            }
        }
    }

    // Entity Framework ile kullanılacak model sınıfı
 

    // Entity Framework DbContext sınıfı
    public class YourDbContext : DbContext
    {
        public DbSet<CandleRecord> Candles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantı dizesini buraya ekleyin
            optionsBuilder.UseSqlServer("YOUR_CONNECTION_STRING");
        }
    }
}
    }
}