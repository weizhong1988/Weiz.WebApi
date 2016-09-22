using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weiz.WebApi.Controllers
{

    public class ReturnJsonResult
    {
        public static ApiResultModel<T> ToJson<T>(int code, string msg, T data)
        {
            ApiResultModel<T> jsonResult = new ApiResultModel<T>();
            jsonResult.code = code;
            jsonResult.msg = msg;
            jsonResult.data = data;
            jsonResult.success = 1;
            return jsonResult;
        }
    }

    /// <summary>
    /// 定义统计返回json格式数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResultModel<T>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public int success { get; set; }

        /// <summary>
        /// 如果不成功，返回的错误信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public T data { get; set; }
    }

  
}
