using System;
using System.Linq;
using System.Collections;
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

    class APIRE_Package {

        public int num;

        public string way;

        public List<APIRE_Ship> list;
    
    }

    class APIRE_Ship {

        public int shipping_id;
        public string tracking_number;
        public int shipment_id;
        public string shipping_name;
        public string order_id;
    }
}
