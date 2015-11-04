using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace JcMatrixSwitchConfig
{
    public class inifile
    {
        static string __path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, byte[] retVal, int size, string filePath);

  
        public static void SetPath(string path)
        {
            __path = path;
        }

        public static int Write(string section, string key, string val)
        {
            WritePrivateProfileString(section,key,val,__path);
            return 0;
        }

        public static string Read(string section, string key, string defaultValue)
        {
            StringBuilder temp = new StringBuilder (512) ;
            GetPrivateProfileString(section,key,defaultValue,temp,512,__path);
            return temp.ToString();
        }

        //public static string ReadSectionAllKey(string section)
        //{
        //    StringBuilder temp = new StringBuilder(512);
        //    GetPrivateProfileSection(section, temp, 512, __path);
        //    return temp.ToString();
        //    //string filePath = __path;

        //    //UInt32 MAX_BUFFER = 32767;

        //    //string[] items = new string[0];

        //    //IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));

        //    //UInt32 bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, filePath);

        //    //if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
        //    //{
        //    //    string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);

        //    //    items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
        //    //}

        //    //Marshal.FreeCoTaskMem(pReturnedString);

        //    //return items;
        //}

        /// <summary>  
        /// 获取INI文件中指定节点(Section)中的所有条目的Key列表  
        /// </summary>  
        /// <param name="iniFile">Ini文件</param>  
        /// <param name="section">节点名称</param>  
        /// <returns>如果没有内容,反回string[0]</returns>  
        public static string[] ReadSectionAllKey(string section)
        {
            int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            Byte[] Buffer = new Byte[16384];

            int bytesReturned = GetPrivateProfileString(section, null, null, Buffer, Buffer.GetUpperBound(0),__path);
            List<string> lt = new List<string>();

            if (bytesReturned != 0)
            {                                
                int start = 0;
                for (int i = 0; i < bytesReturned; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        lt.Add(s);
                        start = i + 1;
                    }
                }
            }


            return lt.ToArray();
        }  
    }
}
