using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flurl.Http;
using System.Threading.Tasks;
using RestSharp;

namespace ChatAI.cs
{
    internal class getWebInfo
    {
        public static string text;
        public static string GetinfoAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                string respince=GetText(url);
                return getWebInfo.text;
            }
            return getWebInfo.text;
        }
        static string GetText(string url)
        {
            var client = new RestClient("https://v1.hitokoto.cn/?c=f&encode=text");
            var request = new RestRequest("", Method.Get);
            getWebInfo.text = request.ToString();
            return request.ToString();
        }
    }
}
