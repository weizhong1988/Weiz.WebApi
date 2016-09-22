using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using Weiz.WebApi.DBUtility;

namespace Weiz.WebApi.DAL
{
    /// <summary>
    /// 数据访问类:Customers
    /// </summary>
    public partial class Customers
    {
        public Customers()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Kid", "Customers");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Kid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Customers");
            strSql.Append(" where Kid=@Kid");
            SqlParameter[] parameters = {
					new SqlParameter("@Kid", SqlDbType.Int,4)
};
            parameters[0].Value = Kid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Weiz.WebApi.Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Customers(");
            strSql.Append("CustomerName,Tel)");
            strSql.Append(" values (");
            strSql.Append("@CustomerName,@Tel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,20)};
            parameters[0].Value = model.CustomerName;
            parameters[1].Value = model.Tel;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Weiz.WebApi.Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Customers set ");
            strSql.Append("CustomerName=@CustomerName,");
            strSql.Append("Tel=@Tel");
            strSql.Append(" where Kid=@Kid");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Kid", SqlDbType.Int,4)};
            parameters[0].Value = model.CustomerName;
            parameters[1].Value = model.Tel;
            parameters[2].Value = model.Kid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Kid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Customers ");
            strSql.Append(" where Kid=@Kid");
            SqlParameter[] parameters = {
					new SqlParameter("@Kid", SqlDbType.Int,4)
};
            parameters[0].Value = Kid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Kidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Customers ");
            strSql.Append(" where Kid in (" + Kidlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Weiz.WebApi.Model.Customers GetModel(int Kid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Kid,CustomerName,Tel from Customers ");
            strSql.Append(" where Kid=@Kid");
            SqlParameter[] parameters = {
					new SqlParameter("@Kid", SqlDbType.Int,4)
};
            parameters[0].Value = Kid;

            Weiz.WebApi.Model.Customers model = new Weiz.WebApi.Model.Customers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Kid"] != null && ds.Tables[0].Rows[0]["Kid"].ToString() != "")
                {
                    model.Kid = int.Parse(ds.Tables[0].Rows[0]["Kid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerName"] != null && ds.Tables[0].Rows[0]["CustomerName"].ToString() != "")
                {
                    model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null && ds.Tables[0].Rows[0]["Tel"].ToString() != "")
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Kid,CustomerName,Tel ");
            strSql.Append(" FROM Customers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Kid,CustomerName,Tel ");
            strSql.Append(" FROM Customers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Customers";
            parameters[1].Value = "Kid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

