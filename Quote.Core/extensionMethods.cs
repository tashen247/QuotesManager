using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Quote.CoreServices
{
    public static class extensionMethods
    {
        public static string ToString(this string s)
        {
            var words = s.Split(' ');
            ArrayList newW = new ArrayList();
            string newResult = "";
            foreach (var w in words)
            {//words
               newW.Add(w.First().ToString().ToUpper() + w.Substring(1).Last().ToString().ToUpper());              
              
            }

            foreach(var item in newW)
            {
                newResult = newResult + item;
            }

            return newResult;
        }
    }
}
