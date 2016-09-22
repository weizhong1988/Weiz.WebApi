using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weiz.WebApi.Controllers
{

    /// <summary>
    /// 定义统计返回json格式数据
    /// </summary>
    public class ErrorModel
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

        public ErrorModel()
        {

        }

        public ErrorModel(int _code, int _success, string _msg)
        {
            this.code = _code;
            this.success = _success;
            this.msg = _msg;
        }
    }
}
