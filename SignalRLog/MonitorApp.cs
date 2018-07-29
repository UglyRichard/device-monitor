using SignalRLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalRLog
{
    public class MonitorApp
    {
        // store received messages
        public static Task<bool> SaveMessageAsync(string clientId, string message)
        {
            return Task.Run(() =>
            {
                using (var ctx = new LogContext())
                {
                    try
                    {
                        // trying save a new message to database
                        var log = new Log() { ClientId = clientId, Message = message, Created = DateTime.Now };

                        ctx.Logs.Add(log);
                        ctx.SaveChanges();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            });
        }

        // return a number of all messages
        public static int CountMessages()
        {
            int count = 0;
            using (var ctx = new LogContext())
            {
                try
                {
                    count = ctx.Logs.Count();
                }
                catch (Exception)
                {
                    count = 0;
                }       
            }

            return count;
        }

    }
}