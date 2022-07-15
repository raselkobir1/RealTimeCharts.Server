using Microsoft.AspNetCore.SignalR;
using RealTimeCharts.Server.Models;

namespace RealTimeCharts.Server.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) =>
       await Clients.All.SendAsync("broadcastchartdata", data); // This BroadcastChartData method will receive the message from the client and then broadcast that same message to all the clients that listen
    }
}
