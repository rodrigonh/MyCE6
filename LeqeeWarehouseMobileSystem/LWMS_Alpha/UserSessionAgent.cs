using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LWMS_Alpha
{
    class UserSessionAgent
    {
        public static String username;
        public static String token;
        public static int facility_code;

        public static String machineCode()
        {
           //return  libGetAdaptersInfo.myMac();
            return MachineID.getMachineID();
        }

        public static Boolean login(int facility_code,String username, String password, out String info)
        {
            String session_token = null;
            info = "";

            String mid = MachineID.getMachineID();

            //TODO: ask with api
            //Console.WriteLine("facility_code=" + facility_code + " username=" + username + " password=" + password+" mid="+mid);

            session_token = API.APIWorker.doLogin(facility_code, username, password, mid, out info);

            //Console.WriteLine("session_token=" + session_token);

            if (session_token != null)
            {
                UserSessionAgent.username = username;
                UserSessionAgent.facility_code = facility_code;
                UserSessionAgent.token = session_token;
                return true;
            }
            else
            {
                UserSessionAgent.username = null;
                UserSessionAgent.facility_code = 0;
                UserSessionAgent.token = null;
                return false;
            }
        }

        public static Boolean logout()
        {
            Boolean outed=API.APIWorker.doLogout();

            UserSessionAgent.username = null;
            UserSessionAgent.token = null;

            return outed;
        }
    }
}
