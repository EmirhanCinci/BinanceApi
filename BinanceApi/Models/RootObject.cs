namespace BinanceApi.Models
{
    public class RateLimit
    {
        public string RateLimitType { get; set; }
        public string Interval { get; set; }
        public int IntervalNum { get; set; }
        public int Limit { get; set; }
    }

    public class Filter
    {
        

    }

    public class Symbol
    {
        public string Symbols { get; set; }
        public string Status { get; set; }
        public string BaseAsset { get; set; }
        public List<Filter> Filters { get; set; }
    }

    public class RootObject
    {
        public string Timezone { get; set; }
        public long ServerTime { get; set; }
        public List<RateLimit> RateLimits { get; set; }
        public List<Symbol> Symbols { get; set; }
       
    }
}
