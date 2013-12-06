using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类CK_Payment。
	/// </summary>
	public class CK_Payment
	{
		public CK_Payment()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CK_PaymentID", "CK_Payment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CK_PaymentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_Payment");
			strSql.Append(" where CK_PaymentID=@CK_PaymentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PaymentID", SqlDbType.Int,4)};
			parameters[0].Value = CK_PaymentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.CK_Payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_Payment(");
			strSql.Append("CK_PeopleID,CK_PayDate,CK_PayMoney,CK_PayComment)");
			strSql.Append(" values (");
			strSql.Append("@CK_PeopleID,@CK_PayDate,@CK_PayMoney,@CK_PayComment)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_PayDate", SqlDbType.DateTime),
					new SqlParameter("@CK_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CK_PayComment", SqlDbType.VarChar,100)};
			parameters[0].Value = model.CK_PeopleID;
			parameters[1].Value = model.CK_PayDate;
			parameters[2].Value = model.CK_PayMoney;
			parameters[3].Value = model.CK_PayComment;

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
		public void Update(TSM.Model.CK_Payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_Payment set ");
			strSql.Append("CK_PeopleID=@CK_PeopleID,");
			strSql.Append("CK_PayDate=@CK_PayDate,");
			strSql.Append("CK_PayMoney=@CK_PayMoney,");
			strSql.Append("CK_PayComment=@CK_PayComment");
			strSql.Append(" where CK_PaymentID=@CK_PaymentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PaymentID", SqlDbType.Int,4),
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_PayDate", SqlDbType.DateTime),
					new SqlParameter("@CK_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CK_PayComment", SqlDbType.VarChar,100)};
			parameters[0].Value = model.CK_PaymentID;
			parameters[1].Value = model.CK_PeopleID;
			parameters[2].Value = model.CK_PayDate;
			parameters[3].Value = model.CK_PayMoney;
			parameters[4].Value = model.CK_PayComment;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_PaymentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Payment ");
			strSql.Append(" where CK_PaymentID=@CK_PaymentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PaymentID", SqlDbType.Int,4)};
			parameters[0].Value = CK_PaymentID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_Payment GetModel(int CK_PaymentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CK_PaymentID,CK_PeopleID,CK_PayDate,CK_PayMoney,CK_PayComment from CK_Payment ");
			strSql.Append(" where CK_PaymentID=@CK_PaymentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_PaymentID", SqlDbType.Int,4)};
			parameters[0].Value = CK_PaymentID;

			TSM.Model.CK_Payment model=new TSM.Model.CK_Payment();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_PaymentID"].ToString()!="")
				{
					model.CK_PaymentID=int.Parse(ds.Tables[0].Rows[0]["CK_PaymentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_PeopleID"].ToString()!="")
				{
					model.CK_PeopleID=int.Parse(ds.Tables[0].Rows[0]["CK_PeopleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_PayDate"].ToString()!="")
				{
					model.CK_PayDate=DateTime.Parse(ds.Tables[0].Rows[0]["CK_PayDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_PayMoney"].ToString()!="")
				{
					model.CK_PayMoney=decimal.Parse(ds.Tables[0].Rows[0]["CK_PayMoney"].ToString());
				}
				model.CK_PayComment=ds.Tables[0].Rows[0]["CK_PayComment"].ToString();
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
			strSql.Append("select CK_PaymentID,CK_PeopleID,CK_PayDate,CK_PayMoney,CK_PayComment ");
			strSql.Append(" FROM CK_Payment ");
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
			strSql.Append(" CK_PaymentID,CK_PeopleID,CK_PayDate,CK_PayMoney,CK_PayComment ");
			strSql.Append(" FROM CK_Payment ");
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
			parameters[0].Value = "CK_Payment";
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

