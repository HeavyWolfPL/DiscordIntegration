using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordIntegration_Plugin.Integration
{
    public class TimeFormat
    {
        // This code is from @Sinsa's ScpAdminReports
        public static string TimeFormatter(int duration)
        {
            if (duration < 60)
            {
                return ($"{duration}s");
            }
            else if (duration < 7200)
            {
                int newtime = (duration + 59) / 60;
                return ($"{newtime}min");
            }
            else if (duration < 129600)
            {
                int newtime = (duration + 3599) / 3600;
                string newtimestring;
                if (newtime.ToString().Length > 2)
                {
                    newtimestring = newtime.ToString().Substring(0, 3);
                }
                else
                {
                    newtimestring = newtime.ToString();
                }
                return ($"{newtimestring}h");
            }
            else if (duration < 2678400)
            {
                int newtime = duration / 86400;
                string newtimestring;
                if (newtime.ToString().Length > 2)
                {
                    newtimestring = newtime.ToString().Substring(0, 3);
                }
                else
                {
                    newtimestring = newtime.ToString();
                }
                return ($"{newtimestring}d");
            }
            else if (duration < 31622400)
            {
                int newtime = duration / 2592000;
                string newtimestring;
                if (newtime.ToString().Length > 2)
                {
                    newtimestring = newtime.ToString().Substring(0, 3);
                }
                else
                {
                    newtimestring = newtime.ToString();
                }

                return ($"{newtimestring}month(s)");
            }
            int newduration = duration / 31536000;
            string newdurationstring;
            if (newduration.ToString().Length > 2)
            {
                newdurationstring = newduration.ToString().Substring(0, 3);
            }
            else
            {
                newdurationstring = newduration.ToString();
            }

            return ($"{newdurationstring}y");
        }
    }
}

