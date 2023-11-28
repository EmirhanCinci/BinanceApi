using Microsoft.AspNetCore.SignalR;

namespace BinanceApi.Service
{
    public class HubService:Hub
    {
        private readonly BinanceService _binanceService;

        public HubService(BinanceService binanceService)
        {
            _binanceService = binanceService;
        }

        public async Task GetList()
        {
            await Clients.All.SendAsync("GetKlinesAsync");
        }

    }
}
