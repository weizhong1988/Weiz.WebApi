using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Data;
using Newtonsoft.Json;

using Weiz.WebApi.BLL;
using Weiz.WebApi.Common;
using Weiz.WebApi.Model;

namespace Weiz.WebApi.Controllers.Areas.Trading.Controllers
{
    public class CustomerController : ApiBase
    {
        protected static Weiz.WebApi.BLL.Customers bll = new Weiz.WebApi.BLL.Customers();

        private RequestHelper requestHelper = new RequestHelper();

        /// <summary>
        /// 获取客户DataTable列表集合
        /// OK(客户可以通过实体的List集合获取到值)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCustomerDT()
        {
            try
            {
                DataTable dt = bll.GetList("").Tables[0];

                if (dt.Rows.Count <= 0)
                    return Ok(ReturnJsonResult.ToJson(-1, "数据不存在！", dt));

                return Ok(ReturnJsonResult.ToJson(1, "", dt));
            }
            catch (Exception myex)
            {
                throw myex;
            }
        }

        /// <summary>
        /// 获取客户List列表集合
        /// OK(客户可以通过实体的List集合获取到值)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCustomerList()
        {
            try
            {
                List<Weiz.WebApi.Model.Customers> list = bll.GetModelList("");

                if (list.Count <= 0)
                    return Ok(ReturnJsonResult.ToJson(-1, "数据不存在！", list));

                return Ok(ReturnJsonResult.ToJson(1, "", list));

            }
            catch (Exception myex)
            {
                throw myex;
            }
        }


        /// <summary>
        /// 根据用户ID 获取用户对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCustomerById(int id)
        {
            try
            {

                Weiz.WebApi.Model.Customers customer = bll.GetModel(id);

                if (customer != null)
                    return Ok(ReturnJsonResult.ToJson(-1, "数据不存在！", customer));

                return Ok(ReturnJsonResult.ToJson(1, "", customer));

            }
            catch (Exception myex)
            {
                throw myex;
            }
        }

        /// <summary>
        /// 获取客户Var列表集合
        /// OK(客户可以通过实体的List集合获取到值)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCustomerVar()
        {
            List<Weiz.WebApi.Model.Customers> list = bll.GetModelList("");
            var result = from c in list
                         select new
                         {
                             Kid = c.Kid,
                             CustomerName = c.CustomerName,
                             Tel = c.Tel
                         };

            if (result.Count() <= 0)
                return Ok(ReturnJsonResult.ToJson(-1, "数据不存在！", list));

            return Ok(ReturnJsonResult.ToJson(1, "", list));
        }

        #region [POST方式操作：添加、编辑、删除]
        /// <summary>
        /// 添加客户(编辑客户信息跟添加客户一样就不演示了)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddCustomer()
        {
            string name = requestHelper.GetRequsetForm("customerName", "");
            string tel = requestHelper.GetRequsetForm("tel", "");
            if (string.IsNullOrEmpty(name))
                return Ok(ReturnJsonResult.ToJson(-1, "客户名称不能为空！", ""));
            if (string.IsNullOrEmpty(tel))
                return Ok(ReturnJsonResult.ToJson(-1, "联系电话不能为空！", ""));
            Model.Customers model = new Model.Customers();
            model.CustomerName = name;
            model.Tel = tel;
            int i = bll.Add(model);
            if (i > 0)
                return Ok(ReturnJsonResult.ToJson(1, "添加成功！", ""));

            return Ok(ReturnJsonResult.ToJson(-1, "添加失败！", ""));
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteCustomer()
        {
            string kidList = requestHelper.GetRequsetForm("kidList", "");

            if (string.IsNullOrEmpty(kidList))
                return Ok(ReturnJsonResult.ToJson(-1, "请选中要删除的项！", ""));
            bool b = bll.DeleteList(kidList);
            if (b)
                return Ok(ReturnJsonResult.ToJson(1, "删除成功！", ""));
            return Ok(ReturnJsonResult.ToJson(-1, "删除失败！", ""));
        }

        #endregion
    }
}
