using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxRunning
{
    public static class ReadRegisterKey
    {
        private const string ROOT_FOLDER_PATH = "SOFTWARE\\FirefoxRunning";
        /// <summary>
        /// Get value from registry - Node:"RootFolder"
        /// </summary>
        public static string ReadRegisterByKey(string x_strKey)
        {
            string strRegPath = ROOT_FOLDER_PATH;
            string strResult = ReadRegistry(RegistryView.Registry64, x_strKey, strRegPath);
            if (string.IsNullOrEmpty(strResult) == true)
            {
                strResult = ReadRegistry(RegistryView.Registry32, x_strKey, strRegPath);
            }
            return strResult;
        }

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

        public static bool CheckValidKey(string x_strAppName, List<HardDrive> hardDrives)
        {
            try
            {
                string strKey = ReadRegisterByKey(x_strAppName);

                if (string.IsNullOrEmpty(strKey))
                {
                    return false;
                }
                else
                {
                    strKey = CryptorEngine.Decrypt(strKey);

                    string strSerialNo = strKey.Substring(0, strKey.Length - 8);

                    if (hardDrives.FirstOrDefault(x => x.SerialNo == strSerialNo) == null)
                    {
                        return false;
                    }

                    DateTime dt;
                    if (DateTime.TryParseExact(strKey.Replace(strSerialNo, ""), "ddMMyyyy", CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out dt) == false)
                    {
                        return false;
                    }

                    if (dt < DateTime.Now)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
