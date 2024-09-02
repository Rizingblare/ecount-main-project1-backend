using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class CookieHandler
    {
        public static string GetOrSetComCode(HttpRequestBase request, HttpResponseBase response)
        {
            HttpCookie comCodeCookie = request.Cookies["comCode"];
            if (comCodeCookie == null)
            {
                string newComCode = GenerateNewComCode();
                comCodeCookie = new HttpCookie("comCode", newComCode)
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true,
                    Secure = true
                };
                response.Cookies.Add(comCodeCookie);
            }
            return comCodeCookie.Value;
        }

        private static string GenerateNewComCode()
        {
            return "80000";
        }
    }
}