using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类CK_SendGoods。
	/// </summary>
	public class CK_SendGoods
	{
		public CK_SendGoods()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CK_SendGoodsID", "CK_SendGoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CK_SendGoodsID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_SendGoods");
			strSql.Append(" where CK_SendGoodsID=@CK_SendGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_SendGoodsID", SqlDbType.Int,4)};
			parameters[0].Value = CK_SendGoodsID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.CK_SendGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_SendGoods(");
			strSql.Append("CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_SendGoodsNo,CK_SendGoodsAmount,CK_SendGoodsDate)");
			strSql.Append(" values (");
			strSql.Append("@CK_ProductTypeID,@CK_PeopleID,@CK_ProductID,@CK_SendGoodsNo,@CK_SendGoodsAmount,@CK_SendGoodsDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4),
					new SqlParameter("@CK_SendGoodsNo", SqlDbType.VarChar,32),
					new SqlParameter("@CK_SendGoodsAmount", SqlDbType.Int,4),
					new SqlParameter("@CK_SendGoodsDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CK_ProductTypeID;
			parameters[1].Value = model.CK_PeopleID;
			parameters[2].Value = model.CK_ProductID;
			parameters[3].Value = model.CK_SendGoodsNo;
			parameters[4].Value = model.CK_SendGoodsAmount;
			parameters[5].Value = model.CK_SendGoodsDate;

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
		public void Update(TSM.Model.CK_SendGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_SendGoods set ");
			strSql.Append("CK_ProductTypeID=@CK_ProductTypeID,");
			strSql.Append("CK_PeopleID=@CK_PeopleID,");
			strSql.Append("CK_ProductID=@CK_ProductID,");
			strSql.Append("CK_SendGoodsNo=@CK_SendGoodsNo,");
			strSql.Append("CK_SendGoodsAmount=@CK_SendGoodsAmount,");
			strSql.Append("CK_SendGoodsDate=@CK_SendGoodsDate");
			strSql.Append(" where CK_SendGoodsID=@CK_SendGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_SendGoodsID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4),
					new SqlParameter("@CK_SendGoodsNo", SqlDbType.VarChar,32),
					new SqlParameter("@CK_SendGoodsAmount", SqlDbType.Int,4),
					new SqlParameter("@CK_SendGoodsDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CK_SendGoodsID;
			parameters[1].Value = model.CK_ProductTypeID;
			parameters[2].Value = model.CK_PeopleID;
			parameters[3].Value = model.CK_ProductID;
			parameters[4].Value = model.CK_SendGoodsNo;
			parameters[5].Value = model.CK_SendGoodsAmount;
			parameters[6].Value = model.CK_SendGoodsDate;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_SendGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_SendGoods ");
			strSql.Append(" where CK_SendGoodsID=@CK_SendGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_SendGoodsID", SqlDbType.Int,4)};
			parameters[0].Value = CK_SendGoodsID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_SendGoods GetModel(int CK_SendGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CK_SendGoodsID,CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_SendGoodsNo,CK_SendGoodsAmount,CK_SendGoodsDate from CK_SendGoods ");
			strSql.Append(" where CK_SendGoodsID=@CK_SendGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_SendGoodsID", SqlDbType.Int,4)};
			parameters[0].Value = CK_SendGoodsID;

			TSM.Model.CK_SendGoods model=new TSM.Model.CK_SendGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_SendGoodsID"].ToString()!="")
				{
					model.CK_SendGoodsID=int.Parse(ds.Tables[0].Rows[0]["CK_SendGoodsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_ProductTypeID"].ToString()!="")
				{
					model.CK_ProductTypeID=int.Parse(ds.Tables[0].Rows[0]["CK_ProductTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_PeopleID"].ToString()!="")
				{
					model.CK_PeopleID=int.Parse(ds.Tables[0].Rows[0]["CK_PeopleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_ProductID"].ToString()!="")
				{
					model.CK_ProductID=int.Parse(ds.Tables[0].Rows[0]["CK_ProductID"].ToString());
				}
				model.CK_SendGoodsNo=ds.Tables[0].Rows[0]["CK_SendGoodsNo"].ToString();
				if(ds.Tables[0].Rows[0]["CK_SendGoodsAmount"].ToString()!="")
				{
					model.CK_SendGoodsAmount=int.Parse(ds.Tables[0].Rows[0]["CK_SendGoodsAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_SendGoodsDate"].ToString()!="")
				{
					model.CK_SendGoodsDate=DateTime.Parse(ds.Tables[0].Rows[0]["CK_SendGoodsDate"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CK_SendGoodsID,CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_SendGoodsNo,CK_SendGoodsAmount,CK_SendGoodsDate ");
			strSql.Append(" FROM CK_SendGoods ");
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
			strSql.Append(" CK_SendGoodsID,CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_SendGoodsNo,CK_SendGoodsAmount,CK_SendGoodsDate ");
			strSql.Append(" FROM CK_SendGoods ");
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
			parameters[0].Value = "CK_SendGoods";
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

