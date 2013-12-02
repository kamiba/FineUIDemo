using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类CK_ProductType。
	/// </summary>
	public class CK_ProductType
	{
		public CK_ProductType()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CK_ProductTypeID", "CK_ProductType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CK_ProductTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_ProductType");
			strSql.Append(" where CK_ProductTypeID=@CK_ProductTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4)};
			parameters[0].Value = CK_ProductTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.CK_ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_ProductType(");
			strSql.Append("CK_ProductTypeName)");
			strSql.Append(" values (");
			strSql.Append("@CK_ProductTypeName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeName", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CK_ProductTypeName;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.CK_ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_ProductType set ");
			strSql.Append("CK_ProductTypeName=@CK_ProductTypeName");
			strSql.Append(" where CK_ProductTypeID=@CK_ProductTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductTypeName", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CK_ProductTypeID;
			parameters[1].Value = model.CK_ProductTypeName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_ProductTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_ProductType ");
			strSql.Append(" where CK_ProductTypeID=@CK_ProductTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4)};
			parameters[0].Value = CK_ProductTypeID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_ProductType GetModel(int CK_ProductTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CK_ProductTypeID,CK_ProductTypeName from CK_ProductType ");
			strSql.Append(" where CK_ProductTypeID=@CK_ProductTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4)};
			parameters[0].Value = CK_ProductTypeID;

			TSM.Model.CK_ProductType model=new TSM.Model.CK_ProductType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_ProductTypeID"].ToString()!="")
				{
					model.CK_ProductTypeID=int.Parse(ds.Tables[0].Rows[0]["CK_ProductTypeID"].ToString());
				}
				model.CK_ProductTypeName=ds.Tables[0].Rows[0]["CK_ProductTypeName"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CK_ProductTypeID,CK_ProductTypeName ");
			strSql.Append(" FROM CK_ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" CK_ProductTypeID,CK_ProductTypeName ");
			strSql.Append(" FROM CK_ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "CK_ProductType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

