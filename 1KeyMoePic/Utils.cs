using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

/// <summary>
/// Code By muyunyan
/// 2016/10/9 Git Ver 1.0
/// </summary>
namespace _1KeyMoePic
{
    /// <summary>
    /// 综合方法类
    /// </summary>
    class Utils
    {
        /// <summary>
        /// 从URL地址下载文件到本地磁盘
        /// </summary>
        /// <param name="ToLocalPath">本地磁盘地址</param>
        /// <param name="Url">URL网址</param>
        /// <returns></returns>
        public static long SaveFileFromUrl(string FileName, string Url)
        {
            long Value = 0;

            WebResponse response = null;
            Stream stream = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                response = request.GetResponse();
                stream = response.GetResponseStream();

                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    SaveBinaryFile(response, FileName);

                    Value = response.ContentLength;

                }

            }
            catch (Exception err)
            {
                Value = 0;
                string aa = err.ToString();
            }
            return Value;
        }
        /// <summary>
        /// Save a binary file to disk.
        /// </summary>
        /// <param name="response">The response used to save the file</param>
        // 将二进制文件保存到磁盘
        private static bool SaveBinaryFile(WebResponse response, string FileName)
        {
            bool Value = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                Stream outStream = System.IO.File.Create(FileName);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch
            {
                Value = false;
            }
            return Value;
        }

        /// <summary>
        /// 用正则获取烧酒图库的图片id
        /// </summary>
        /// <param name="jsonresv">烧酒图库的json数据</param>
        /// <returns></returns>
        public static string loadJsonPicid(string jsonresv)
        {
            Regex reg = new Regex(@"\w{16,32}");
            string picid = reg.Match(jsonresv).Value;
            return picid;
        }

        ///读取烧酒萌图的IMGJson
        public static string loadImgJson()
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://api.syouzyo.org/?rand&%E9%A2%84%E8%AE%BE=%E5%AE%BD%E5%B1%8F");
            request.Method = "GET";
            request.Referer = "http://syouzyo.org/";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responsestream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responsestream, System.Text.Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        /// <summary>
        /// 拼接微博id到url
        /// </summary>
        /// <param name="imgID">微博图片id</param>
        /// <returns></returns>
        public static string createWeiboImgUrl(string imgID)
        {
            string urlres = "";
            string weiboUrlBase = "http://ww2.sinaimg.cn/large/";
            urlres = weiboUrlBase + imgID;
            return urlres;
        }

        /// <summary>
        /// 建立图片文件夹，分为JPG和BMP
        /// </summary>
        /// <param name="picDir">文件夹地址</param>
        public static void createPicDic(string picDir)
        {
            if (!Directory.Exists(picDir))
            {
                Directory.CreateDirectory(picDir);
                Directory.CreateDirectory(picDir + "\\JPG");
                Directory.CreateDirectory(picDir + "\\BMP");
            }
        }


        /// <summary>  
        /// 设置背景图片  
        /// </summary>  
        /// <param name="picture">图片路径</param>  
        /// <param name="picDir">1KeyMoe图片文件夹</param>  
        public static void SetDestPicture(string picDir,string picture)
        {
            if (File.Exists(picture))
            {
                if (Path.GetExtension(picture).ToLower() != "bmp")
                {
                    // 其它格式文件先转换为bmp再设置  
                    string tempFile = picDir + "\\BMP\\1kwp" + random6nums() + ".bmp";
                    Image image = Image.FromFile(picture);
                    image.Save(tempFile, System.Drawing.Imaging.ImageFormat.Bmp);
                    picture = tempFile;
                    setBMPAsDesktop(picture);
                }
                else
                {
                    setBMPAsDesktop(picture);
                }

            }
        }

        /// <summary>
        /// 获取6位随机数
        /// </summary>
        /// <returns>6位随机数（字符串）</returns>
        public static string random6nums()
        {
            string res = "";
            var random = new Random((int)DateTime.Now.Ticks);
            string textArray = "1234567890SODA";//XXD
            for (int i = 0; i < 6; i++)
            {
                res += textArray.Substring(random.Next() % textArray.Length, 1);
            }
            return res;
        }

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
            int uAction,
            int uParam,
            string lpvParam,
            int fuWinIni
        );

        /// <summary>  
        /// 设置BMP格式的背景图片  
        /// </summary>  
        /// <param name="bmp">图片路径</param>  
        public static void setBMPAsDesktop(string bmp)
        {
            SystemParametersInfo(20, 0, bmp, 0x2);
        }
    }
}
