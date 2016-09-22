using System;
using System.Data;
using System.Collections.Generic;

namespace Weiz.WebApi.BLL
{
	/// <summary>
	/// Customers
	/// </summary>
	public partial class Customers
	{
        private readonly Weiz.WebApi.DAL.Customers dal = new Weiz.WebApi.DAL.Customers();
		public Customers()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Kid)
		{
			return dal.Exists(Kid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Weiz.WebApi.Model.Customers model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Weiz.WebApi.Model.Customers model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Kid)
		{
			
			return dal.Delete(Kid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Kidlist )
		{
			return dal.DeleteList(Kidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Weiz.WebApi.Model.Customers GetModel(int Kid)
		{
			
			return dal.GetModel(Kid);
		}



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Weiz.WebApi.Model.Customers> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Weiz.WebApi.Model.Customers> DataTableToList(DataTable dt)
		{
			List<Weiz.WebApi.Model.Customers> modelList = new List<Weiz.WebApi.Model.Customers>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Weiz.WebApi.Model.Customers model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Weiz.WebApi.Model.Customers();
					if(dt.Rows[n]["Kid"]!=null && dt.Rows[n]["Kid"].ToString()!="")
					{
						model.Kid=int.Parse(dt.Rows[n]["Kid"].ToString());
					}
					if(dt.Rows[n]["CustomerName"]!=null && dt.Rows[n]["CustomerName"].ToString()!="")
					{
					model.CustomerName=dt.Rows[n]["CustomerName"].ToString();
					}
					if(dt.Rows[n]["Tel"]!=null && dt.Rows[n]["Tel"].ToString()!="")
					{
					model.Tel=dt.Rows[n]["Tel"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
		#endregion  Method
    }
}

