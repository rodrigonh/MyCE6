using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

namespace LWMS_Alpha.API
{
    class APIWorker
    {
        public static Dictionary<string, API.APIRE_PhysicalWarehouse> getFacilityList()
        {
            try
            {
                List<API.APIRE_PhysicalWarehouse> ori_list = APIWorkerImpl.appIndex();
                Dictionary<string, API.APIRE_PhysicalWarehouse> list = new Dictionary<string, API.APIRE_PhysicalWarehouse>();
                foreach(API.APIRE_PhysicalWarehouse item in ori_list){
                    list.Add(item.warehouse_name, item);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
                //return new Dictionary<string, string>();
            }
        }

        public static String doLogin(int facility_code, String username, String password, String mid, out String info)
        {
            String errCode;
            String token = API.APIWorkerImpl.appLogin(facility_code, username, password, mid, out errCode);
            info = errCode;
            return token;
        }

        public static Boolean doLogout()
        {
            return API.APIWorkerImpl.appLogout();
        }
    }
}
