using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;


namespace LWMS_Alpha.API
{
    class APIWorkerImpl
    {
        private static String api_root_url = "http://www.leqeewechat.com:8080/wms/";

        public static String commonTest()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("sid", (UserSessionAgent.token==null?"":UserSessionAgent.token));
            HttpWebResponse response = NetworkAgent.theEN().postHttp("http://www.leqeewechat.com:8080/wms/appIndex", parameters, 30000, null, Encoding.UTF8);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            return content;
        }

        private static String callApi(String api_sub_url, Dictionary<string, string> parameters,out HttpWebResponse response)
        {
            parameters.Add("sid", (UserSessionAgent.token == null ? "" : UserSessionAgent.token));
            //HttpWebResponse 
            response = NetworkAgent.theEN().postHttp(APIWorkerImpl.api_root_url+api_sub_url, parameters, 30000, null, Encoding.UTF8);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            return content;
        }

        private static JObject processJSON(String json,out String errCode)
        {
            JObject o = JObject.Parse(json);
            //Console.WriteLine(o["result"]);
            //Console.WriteLine(o["result"].Value<String>());
            //Console.WriteLine("EQUAL? " + o["result"].Value<String>().Equals("success"));
            if (o["result"].Value<String>().Equals("success"))
            {
                //Console.WriteLine("process JSON as "+o);
                errCode = "0000";
                return o;
            }
            else
            {
                //Console.WriteLine("process JSON errorCode");
                errCode=o["errorCode"].ToString();
                //Console.WriteLine("process JSON errorCode = " + errCode);
                return null;
            }
        }

        public static List<API.APIRE_PhysicalWarehouse> appIndex()
        {
            try
            {
                string tagUrl = "appIndex";

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                //parameters.Add("str1", "apple");
                //parameters.Add("str2", "pear");

                HttpWebResponse response = null;

                String json = APIWorkerImpl.callApi(tagUrl, parameters, out response);

                String errCode = "0000";
                JObject obj=APIWorkerImpl.processJSON(json,out errCode);
                if (obj!=null)
                {
                    JArray array = (JArray)obj["pwarehouseList"];
                    

                    List<API.APIRE_PhysicalWarehouse> list = new List<APIRE_PhysicalWarehouse>();
                    for (int i = 0; i < array.Count; i++)
                    {
                        API.APIRE_PhysicalWarehouse pw = new API.APIRE_PhysicalWarehouse();
                        pw.warehouse_name = array[i]["warehouse_name"].Value<String>() ;
                        pw.physical_warehouse_id = (array[i]["physical_warehouse_id"].Value<int>());
                        list.Add(pw);
                    }
                    
                    return list;
                }
                else
                {
                    throw new Exception(errCode);
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static String appLogin(int facility_code, String username, String password, String mid, out String errCode)
        {
            try
            {
                String url = "appLogin";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("username", username);
                parameters.Add("password", password);
                //parameters.Add("sid", "");
                parameters.Add("hardwareCode", mid);
                parameters.Add("physical_warehouse_id", ("" + facility_code));

                HttpWebResponse response = null;
                String json = APIWorkerImpl.callApi(url, parameters, out response);
                //Console.WriteLine(json);
                errCode = "0000";
                JObject obj = APIWorkerImpl.processJSON(json, out errCode);
                if (obj != null)
                {
                    String token = obj["sid"].Value<String>();
                    if (token != null)
                    {
                        return token;
                    }
                    else
                    {
                        throw new Exception("Empty Token Error");
                    }
                }
                else
                {
                    throw new Exception("JSON Response Parse Error");
                }

            }
            catch (Exception e)
            {
                errCode = e.Message;
                return null;
            }
        }

        public static Boolean appLogout()
        {
            try
            {
                String url = "appLogout";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpWebResponse response = null;
                String json = APIWorkerImpl.callApi(url, parameters, out response);
                String errCode = "0000";
                JObject obj = APIWorkerImpl.processJSON(json, out errCode);
                return (obj!=null);
            }
            catch (Exception e)
            {
                Console.WriteLine("TO Logout for " + UserSessionAgent.token);
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
