using Microsoft.AspNetCore.SignalR;

namespace SıgnalR.API.Hubs
{
    public class CovidHub : Hub
    {
        public async Task GetCovidList()
        {
            await Clients.All.SendAsync("ReceiveCovidList","Serviceden Covid19 verilerini al");
        }
    }
}
