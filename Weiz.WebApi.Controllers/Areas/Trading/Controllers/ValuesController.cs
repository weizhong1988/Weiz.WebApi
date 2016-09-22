using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Weiz.WebApi.Controllers.Areas.Trading.Controllers
{
    /// <summary>
    /// 值接口
    /// </summary>
    public class ValuesController : ApiBase
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns>获取值</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 根据id获取值
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
