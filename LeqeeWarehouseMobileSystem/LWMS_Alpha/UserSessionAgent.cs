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

        public static Boolean login(String username, String password, out String info)
        {
            String session_token = null;
            info = "";

            //TODO: ask with api
            session_token = "hahaha";

            if (session_token != null)
            {
                UserSessionAgent.username = username;
                UserSessionAgent.token = session_token;
                return true;
            }
            else
            {
                UserSessionAgent.username = null;
                UserSessionAgent.token = null;
                return false;
            }
        }

        public static void logout()
        {
            UserSessionAgent.username = null;
            UserSessionAgent.token = null;
        }
    }
}
