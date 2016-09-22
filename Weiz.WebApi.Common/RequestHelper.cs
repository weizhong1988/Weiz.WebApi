using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Weiz.WebApi.Common
{
    /// <summary>
    /// Request请求帮助类
    /// </summary>
    public class RequestHelper
    {
        /// <summary>
        /// Post提交
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string GetRequsetForm(string key, string defaultVal)
        {
            if (System.Web.HttpContext.Current.Request.Form[key] == null)
                return defaultVal;
            return System.Web.HttpContext.Current.Request.Form[key].ToString();
        }

        /// <summary>
        /// Get提交
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public string GetRequsetQueryString(string key, string defaultVal)
        {
            if (System.Web.HttpContext.Current.Request.QueryString[key] == null)
                return defaultVal;
            return System.Web.HttpContext.Current.Request.QueryString[key].ToString();
        }
    }
}
