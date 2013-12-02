using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类CK_People。
	/// </summary>
	public class CK_People
	{
		public CK_People()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CK_PeopleID", "CK_People"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CK_PeopleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_People");
			strSql.Append(" where CK_PeopleID=@CK_PeopleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4)};
			parameters[0].Value = CK_PeopleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.CK_People model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_People(");
			strSql.Append("CK_PeopleName,CK_PhoneNo,CK_Comment)");
			strSql.Append(" values (");
			strSql.Append("@CK_PeopleName,@CK_PhoneNo,@CK_Comment)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PeopleName", SqlDbType.VarChar,32),
					new SqlParameter("@CK_PhoneNo", SqlDbType.VarChar,32),
					new SqlParameter("@CK_Comment", SqlDbType.VarChar,100)};
			parameters[0].Value = model.CK_PeopleName;
			parameters[1].Value = model.CK_PhoneNo;
			parameters[2].Value = model.CK_Comment;

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
		public void Update(TSM.Model.CK_People model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_People set ");
			strSql.Append("CK_PeopleName=@CK_PeopleName,");
			strSql.Append("CK_PhoneNo=@CK_PhoneNo,");
			strSql.Append("CK_Comment=@CK_Comment");
			strSql.Append(" where CK_PeopleID=@CK_PeopleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_PeopleName", SqlDbType.VarChar,32),
					new SqlParameter("@CK_PhoneNo", SqlDbType.VarChar,32),
					new SqlParameter("@CK_Comment", SqlDbType.VarChar,100)};
			parameters[0].Value = model.CK_PeopleID;
			parameters[1].Value = model.CK_PeopleName;
			parameters[2].Value = model.CK_PhoneNo;
			parameters[3].Value = model.CK_Comment;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_PeopleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_People ");
			strSql.Append(" where CK_PeopleID=@CK_PeopleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4)};
			parameters[0].Value = CK_PeopleID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_People GetModel(int CK_PeopleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CK_PeopleID,CK_PeopleName,CK_PhoneNo,CK_Comment from CK_People ");
			strSql.Append(" where CK_PeopleID=@CK_PeopleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4)};
			parameters[0].Value = CK_PeopleID;

			TSM.Model.CK_People model=new TSM.Model.CK_People();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_PeopleID"].ToString()!="")
				{
					model.CK_PeopleID=int.Parse(ds.Tables[0].Rows[0]["CK_PeopleID"].ToString());
				}
				model.CK_PeopleName=ds.Tables[0].Rows[0]["CK_PeopleName"].ToString();
				model.CK_PhoneNo=ds.Tables[0].Rows[0]["CK_PhoneNo"].ToString();
				model.CK_Comment=ds.Tables[0].Rows[0]["CK_Comment"].ToString();
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
			strSql.Append("select CK_PeopleID,CK_PeopleName,CK_PhoneNo,CK_Comment ");
			strSql.Append(" FROM CK_People ");
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
			strSql.Append(" CK_PeopleID,CK_PeopleName,CK_PhoneNo,CK_Comment ");
			strSql.Append(" FROM CK_People ");
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
			parameters[0].Value = "CK_People";
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

