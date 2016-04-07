using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LWMS_Alpha.API
{
    class APIResponseEntity
    {
    }

    class APIRE_PhysicalWarehouse
    {
        String created_user;
        int warehouse_id;
        String district_name;
        long created_time;
        public int physical_warehouse_id;
        int city_id;
        int province_id;
        String city_name;
        String province_name;
        int packbox_warehouse;
        public String warehouse_name;
        String is_physical;
        String contact;
        String warehouse_type;
        String contact_mobile;
        int district_id;
        String address;

        public override string ToString()
        {
            return this.warehouse_name == null ? "" : this.warehouse_name;
        }
    }
}
