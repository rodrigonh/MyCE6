using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LWMS_Alpha
{
    class MachineID
    {
        private static readonly String filename = "LWMS_MID.key";

        public static String getMachineID()
        {
            if (!MachineID.checkMIDFileExists())
            {
                MachineID.createMIDFile();
            }
            String mid= MachineID.readMIDFile();
            if (mid == null)
            {
                mid = "";
            }
            return mid;
        }

        private static Boolean checkMIDFileExists()
        {
            FileInfo file = new FileInfo(MachineID.filename);
            return file.Exists;
        }

        private static Boolean createMIDFile()
        {
            try
            {
                String key = Guid.NewGuid().ToString();
                StreamWriter sw = File.AppendText(MachineID.filename);
                sw.Write(key);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static String readMIDFile()
        {
            try
            {
                StreamReader sr = new StreamReader(MachineID.filename, Encoding.UTF8);
                String key = sr.ReadToEnd();
                sr.Close();
                return key;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
