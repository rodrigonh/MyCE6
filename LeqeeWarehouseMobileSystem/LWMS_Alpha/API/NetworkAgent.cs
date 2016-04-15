using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading;

namespace LWMS_Alpha.API
{
    public class NetworkAgent
    {
        private static EasyNeter enInstance = null;

        protected static EasyNeter EnInstance
        {
            get { return NetworkAgent.enInstance; }
            set { NetworkAgent.enInstance = value; }
        }

        public static EasyNeter theEN()
        {
            //if (enInstance == null)
            //{
            enInstance = new EasyNeter();
            //}
            return NetworkAgent.enInstance;
        }

    }

    public class RequestState
    {
        // This class stores the State of the request.
        const int BUFFER_SIZE = 1024;
        public StringBuilder requestData;
        public byte[] BufferRead;
        public HttpWebRequest request;
        public HttpWebResponse response;
        public Stream streamResponse;
        public RequestState()
        {
            BufferRead = new byte[BUFFER_SIZE];
            requestData = new StringBuilder("");
            request = null;
            streamResponse = null;
        }
    }

    public class EasyNeter : ICertificatePolicy
    {
        private static readonly string DefaultUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.87 Safari/537.36";
        //"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public HttpWebResponse getHttp(String url, IDictionary<string, string> parameters, int? timeout)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                url = url + "?" + (buffer.ToString());
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.CertificatePolicy = this;
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request.ProtocolVersion = HttpVersion.Version10;
            }
            request.Method = "GET";
            //request.UserAgent = DefaultUserAgent;
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }

            return request.GetResponse() as HttpWebResponse;
        }

        public HttpWebResponse postHttp(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding/*, CookieCollection cookies*/)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.SendChunked = true;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.CertificatePolicy = this;
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request.ProtocolVersion = HttpVersion.Version10;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            /*
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }
            */
            /*
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
             */
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                request.ContentLength = data.Length;
                request.KeepAlive = true;
                //request.ServicePoint.Expect100Continue=false;
                //request.Accept = "*/*";
                //request.AllowAutoRedirect = true;
                request.AllowWriteStreamBuffering = false;



                using (Stream stream = request.GetRequestStream())
                {
                    /*
                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(stream);
                        sw.Write(buffer.ToString());
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                        Console.WriteLine(e1.StackTrace);
                    }
                    finally
                    {
                        sw.Close();
                        sw = null;
                    }
                     */
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }
             HttpWebResponse response= null;
            try
            {
                 response = request.GetResponse() as HttpWebResponse;
                 return response;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
                Console.WriteLine(eee.StackTrace);
                if (response != null)
                {
                    response.Close();
                }
                //throw eee;
                return null;
            }
            finally{
                
            }
        }

        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }

    }
}
