using System.Threading.Tasks;
using System;
using Microsoft.AspNet.SignalR;
using SignalRLog;

namespace SignalRLog
{

    public class LogHub : Hub
    {
        public async Task Send(string clientId, string message)
        {
            // save message to database
            bool wasStored = MonitorApp.SaveMessage(clientId, message);

            // check if was stored and inform client
            if (wasStored)
            {
                // Return result to caller
                await Clients.Caller.addNewMessageToPage(clientId, "Server Received: " + message);
            }
            else
            {
                // Return result to caller
                await Clients.Caller.addNewMessageToPage(clientId, "Message was not stored: " + message);
            }
            
        }

    }
}