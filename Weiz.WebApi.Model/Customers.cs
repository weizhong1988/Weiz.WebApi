using System;
namespace Weiz.WebApi.Model
{
	/// <summary>
	/// Customers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customers
	{
		public Customers()
		{}
		#region Model
		private int _kid;
		private string _customername;
		private string _tel;
		/// <summary>
		/// 
		/// </summary>
		public int Kid
		{
			set{ _kid=value;}
			get{return _kid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		#endregion Model
	}
}

