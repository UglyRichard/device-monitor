using System.Threading.Tasks;
using System;
using Microsoft.AspNet.SignalR;
using SignalRLog;

namespace SignalRLog
{

    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // save message to database
            bool wasStored = MonitorApp.SaveMessage(name, message);

            // check if was correctly stored and inform client
            if (wasStored)
            {
                // Return result to caller
                Clients.Caller.addNewMessageToPage(name, "Server Received: " + message);
            }
            else
            {
                // Return result to caller
                Clients.Caller.addNewMessageToPage(name, "Message was not stored: " + message);
            }
            
        }

    }
}