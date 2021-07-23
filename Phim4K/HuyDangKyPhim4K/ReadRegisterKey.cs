using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HuyDangKyFirefox
{
    public static class ReadRegisterKey
    {
        private const string ROOT_FOLDER_PATH = "SOFTWARE\\Phim4K";

        private static string ReadRegistry(RegistryView x_objRegistryView, string x_strNode, string x_strRegPath)
        {
            string strResult = string.Empty;
            if (string.IsNullOrWhiteSpace(x_strNode) || string.IsNullOrWhiteSpace(x_strRegPath))
            {
                return strResult;
            }
            //Read from registry
            try
            {
                RegistryKey objRegKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, x_objRegistryView);
                objRegKey = objRegKey.OpenSubKey(x_strRegPath, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.ReadKey);
                if (objRegKey != null)
                {
                    strResult = (string)objRegKey.GetValue(x_strNode);
                    objRegKey.Close();
                }
            }
            catch
            {
                strResult = string.Empty;
            }
            return strResult;
        }


        public static bool AddRegisterByKey(string x_strKey, string x_strValue)
        {
            try
            {
                RegistryKey key;
                key = Registry.LocalMachine.CreateSubKey(ROOT_FOLDER_PATH);
                key.SetValue(x_strKey, x_strValue);
                key.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
