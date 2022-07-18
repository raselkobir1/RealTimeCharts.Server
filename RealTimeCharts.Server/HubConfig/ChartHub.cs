using Microsoft.AspNetCore.SignalR;
using RealTimeCharts.Server.Models;

namespace RealTimeCharts.Server.HubConfig
{
    public class ChartHub : Hub
    {
        //public async Task BroadcastChartData(List<ChartModel> data) =>
        //await Clients.All.SendAsync("broadcastchartdata", data); // This BroadcastChartData method will receive the message from the client and then broadcast that same message to all the clients that listen

        public async Task BroadcastChartData(List<ChartModel> data, string connectionId) =>
        await Clients.Client(connectionId).SendAsync("broadcastchartdata", data);

        public string GetConnectionId()
        {
            return Context.ConnectionId;    
        }
    }
}





/*
 public async Task BroadcastToConnection(string data, string connectionId)    
    => await Clients.Client(connectionId).SendAsync("broadcasttoclient", data);

public async Task BroadcastToUser(string data, string userId)     
    => await Clients.User(userId).SendAsync("broadcasttouser", data);
 
Remember that when we are sending messages to a user, they will be sent to all connections associated with that user and not just any particular connection. However, sending messages to individual users requires our application to authenticate users and set the NameIdentifier claim in ClaimsPrincipal. Only then can the connections be mapped to specific users.
 */