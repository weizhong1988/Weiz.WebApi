using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using Weiz.WebApi.Common;

namespace Weiz.WebApi.Controllers
{
    /// <summary>
    /// API自定义错误过滤器属性
    /// </summary>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 统一对调用异常信息进行处理，返回自定义的异常信息
        /// </summary>
        /// <param name="context">HTTP上下文对象</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            //自定义异常的处理
            Exception ex = context.Exception;
            if (ex != null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    //封装处理异常信息，返回指定JSON对象
                    Content = new StringContent(JsonHelper.ToJson(new ErrorModel(500, 0, ex.Message)), Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Exception"
                });

            }

            //记录关键的异常信息
            //Debug.WriteLine(context.Exception);

            //常规异常的处理
            string msg = string.IsNullOrEmpty(context.Exception.Message) ? "接口出现了错误，请重试或者联系管理员" : context.Exception.Message;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(msg, Encoding.UTF8, "application/json"),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}
