using Microsoft.AspNetCore.SignalR;
using SıgnalR.API.Context;
using SıgnalR.API.Hubs;
using SıgnalR.API.Models;

namespace SıgnalR.API.Service
{
    public class CovidService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHubContext<CovidHub> _hubContext;

        public CovidService(AppDbContext appDbContext, IHubContext<CovidHub> hubContext)
        {
            _appDbContext = appDbContext;
            _hubContext = hubContext;
        }

        public IQueryable<Covid> GetList()
        {
            return _appDbContext.Covids.AsQueryable();
        }

        public async Task SaveCovid(Covid covid)
        {
            await _appDbContext.Covids.AddAsync(covid);
            await _appDbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveList", "data");
        }
    }
}
