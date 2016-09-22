using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weiz.WebApi.Common
{

    /// <summary>
    /// 定义统计返回json格式数据
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public int success { get; set; }

        /// <summary>
        /// 如果不成功，返回的错误信息
        /// </summary>
        public string errmsg { get; set; }

        public ErrorModel()
        {

        }

        public ErrorModel(int _code, int _success, string _msg)
        {
            this.errcode = _code;
            this.success = _success;
            this.errmsg = _msg;
        }
    }
}
