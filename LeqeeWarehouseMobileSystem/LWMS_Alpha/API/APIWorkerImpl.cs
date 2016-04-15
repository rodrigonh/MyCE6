using System;
using System.Linq;
using System.Collections;
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
        //private static String api_root_url = "http://172.16.1.141:8080/wms/";
        private static String api_root_url = "http://www.leqeewechat.com:8080/wms/";
        //private static String api_root_url = "http://www.leqeewechat.com/device/";

        public static String commonTest()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("sid", (UserSessionAgent.token==null?"":UserSessionAgent.token));
            int k = new Random().Next();
            HttpWebResponse response = NetworkAgent.theEN().postHttp("http://www.leqeewechat.com:8080/wms/appIndex", parameters, 30000, "Sinri Variable UA-"+k, Encoding.UTF8);
            //HttpWebResponse response = NetworkAgent.theEN().getHttp(url, parameters, 30000);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            return content;
        }

        private static String callApi(String api_sub_url, Dictionary<string, string> parameters)
        {
            parameters.Add("sid", (UserSessionAgent.token == null ? "" : UserSessionAgent.token));

            string url = (APIWorkerImpl.api_root_url + api_sub_url);// +".php";

            Console.WriteLine("CALL_API: " + url);
            foreach (String key in parameters.Keys)
            {
                Console.WriteLine("param| " + key + " : " + parameters[key]);
            }

            HttpWebResponse  response = NetworkAgent.theEN().postHttp(url, parameters, 10*1000, null, Encoding.Default);
            //response = NetworkAgent.theEN().getHttp(url, parameters, 30000);
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String content = sr.ReadToEnd();
            
            Console.WriteLine(content);
            response.Close();
            return content;
        }

        private static JObject processJSON(String json,out String errCode)
        {
            JObject o = JObject.Parse(json);
            Console.WriteLine(o);
            Console.WriteLine(o["success"]);
            Console.WriteLine(o["success"].Value<Boolean>());
            //if (o["result"].Value<String>().Equals("success"))
            if (o["success"].Value<Boolean>())
            {
                Console.WriteLine("success confirmed");
                errCode = "0000";
                return o;
            }
            else
            {
                Console.WriteLine("failed confirmed");
                JToken token = null;
                if (o.TryGetValue("errorCode", out token))
                {
                    errCode = token.Value<String>(); 
                }
                else
                {
                    if (o.TryGetValue("error", out token))
                    {
                        errCode = token.Value<String>(); 
                    }
                    else
                    {
                        errCode = "Unknown Error";
                    }
                }
                return null;
            }
        }

        public static List<API.APIRE_PhysicalWarehouse> appIndex()
        {
            try
            {
                string tagUrl = "appIndex";

                Dictionary<string, string> parameters = new Dictionary<string, string>();

                HttpWebResponse response = null;

                String json = APIWorkerImpl.callApi(tagUrl, parameters);

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
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
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
                String json = APIWorkerImpl.callApi(url, parameters);
                Console.WriteLine(json);
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
                String json = APIWorkerImpl.callApi(url, parameters);
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


        public static API.APIRE_Package checkPalletSn(String matuo)
        {
            try
            {
                String url = "shippment/checkPalletSn";
                //url = "checkPalletSn";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("pallet_sn", matuo);

                HttpWebResponse response = null;
                //HttpWebResponse 
                String json = APIWorkerImpl.callApi(url, parameters);
                
                String errCode = "0000";
                JObject obj = APIWorkerImpl.processJSON(json,out errCode);

                if (obj != null)
                {
                    ArrayList list = new ArrayList();

                    API.APIRE_Package apk = new APIRE_Package();   
          
                    JArray array = (JArray)obj["ship"];

                    apk.num = (obj["num"].Value<int>());
                    Console.WriteLine(obj["num"].Value<int>());
                    for (int i = 0; i < array.Count; i++)
                    {
                        APIRE_Ship s = new APIRE_Ship();
                        s.tracking_number = array[i].Value<String>("tracking_number");
                        
                        s.shipping_name = array[i].Value<String>("shipping_name");

                        apk.list.Add(s);
                    }
                    return apk;

                }
                else
                {
                    throw new Exception("该托盘条码不存在!");
                }


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }
    }

}
