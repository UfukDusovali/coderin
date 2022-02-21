using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coderin.UI
{
    public class Functions
    {
        public static string UrlDuzenle(string gelen)
        {
            string url = gelen.ToLower().Trim().Replace(" ", "-").Replace("ğ", "g").Replace("ı", "i").Replace("ü", "u").Replace("ş", "s").Replace("ç", "c").Replace("ö", "o").Replace("'", "-").Replace("?", "").Replace(";", "").Replace("*", "").Replace("+", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("\\", "").Replace("<", "").Replace(">", "").Replace("^", "").Replace("&", "").Replace("%", "").Replace("=", "").Replace("$", "").Replace("€", "").Replace("æ", "").Replace("ß", "").Replace(",", "").Replace(".", "").Replace(";", "").Replace("@", "").Replace("½", "").Replace("!", "").Replace("|", "").Replace("_", "").Replace("#","");
            return url;
        }
    }
}