using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Data;
using Invoice.Mode;
namespace Invoice
{
    class Tools
    {
 
        static private IntPtr instance;
        //要加载方法的委托
        delegate void Test();
        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetProcAddress(
            IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        #region 生成日志
        public static void WriteLog(string ml, string ls_str)
        {
            string ls_file = Environment.CurrentDirectory + "\\log\\";
            if (!Directory.Exists(ls_file))
            {
                Directory.CreateDirectory(ls_file);
            }
            ls_file = ls_file +  DateTime.Now.ToString("yyyyMMdd")  + ".log";
            using (StreamWriter sw = new StreamWriter(ls_file, true))
            {
                sw.Write(DateTime.Now.ToString());
                sw.WriteLine(ml);
                sw.WriteLine(ls_str);
                sw.Flush();
            }
        }
        #endregion



        //获取方法指针
        public static Delegate GetAddress(string functionname, Type t)
        {

            int addr = GetProcAddress(instance, functionname);
            if (addr == 0)
                return null;
            else
                return Marshal.GetDelegateForFunctionPointer(new IntPtr(addr), t);
        }

        //加载DLL
        public static void LoadLib(string dllPath)
        {
            instance = LoadLibrary(dllPath);
            if (instance.ToInt32() == 0)
            {
                throw new Exception("请配置引擎DLL的路径!");
            }
        }

        /// <summary>
        /// 卸载DLL
        /// </summary>
        public static void FreeLib()
        {
            FreeLibrary(instance);
        }


       

        public static byte[] AesEncrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return resultArray;
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
                ///<summary>
        ///采用https协议访问网络
        ///</summary>
        ///<param name="URL">url地址</param>
        ///<param name="strPostdata">发送的数据</param>
        ///<returns></returns>
        public static string OpenReadWithHttps(string URL, string strPostdata)
        {
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "post";
            request.ContentType = "text/html;charset=UTF-8";
            byte[] buffer = encoding.GetBytes(strPostdata);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))
              {
                   return reader.ReadToEnd();
              }
        }

        public static string GetHttpResponse(string url)
        {
            Tools.WriteLog("url=", url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "text/html;charset=UTF-8";
     
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                     returnStr += bytes[i].ToString("X2");
                 }
             }
            return returnStr;
	    }

        public static string callService(string url,string method, string appid, string appkey, string version, string code, string dwbm,string message)
        {
            string format = "JSON";
            string app_id = appid;
            string sj = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string ver = version;
            string encryption = "0";
            string message_id = Guid.NewGuid().ToString("N").ToUpper();
            //string message = "{\"message\":{\"place_code\":\"\"}}";
            byte[] mt = Encoding.UTF8.GetBytes(message);
            message = Convert.ToBase64String(mt);
            string region_code = code;
            string agency_code = dwbm;
            string para = appkey + agency_code + app_id + sj + encryption + format + message + message_id + method + region_code + version + appkey;
            byte[] by = Encoding.UTF8.GetBytes(para);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(by);
            string security = Tools.byteToHexStr(output).ToUpper();// BitConverter.ToString(output).Replace("-", "").ToUpper();

            string paras = "app_id=" + app_id + "&security=" + security + "&agency_code=" + agency_code + "&datetime=" + sj + "&encryption=" + encryption + "&format=JSON" + "&method=" + method + "&message=" + message + "&message_id=" + message_id + "&region_code=" + region_code + "&version="+version;
            string result = Tools.GetHttpResponse(url + "?" + paras);
            return  Encoding.UTF8.GetString(Convert.FromBase64String(result));
        }




        public static dynamic FromJson(string jsonStr)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });

            dynamic glossaryEntry = jss.Deserialize(jsonStr, typeof(object)) as dynamic;
            return glossaryEntry;
        }

        /// <summary>
        /// 讲list集合转换成datatable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static System.Data.DataTable ListToDataTable(IList list)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取类型
                    Type colType = pi.PropertyType;
                    //当类型为Nullable<>时
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    result.Columns.Add(pi.Name, colType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }


        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        //Dictionary转DataTable
        public static DataTable DicToTable(Dictionary<string, string> dicDep)
        {
            DataTable dt = new DataTable();
            foreach (var colName in dicDep.Keys)
            {
                dt.Columns.Add(colName, typeof(string));
            }
            DataRow dr = dt.NewRow();
            foreach (KeyValuePair<string, string> item in dicDep)
            {
                dr[item.Key] = item.Value;
            }
            dt.Rows.Add(dr);
            return dt;
        }

    }
}
