using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类CK_TakeGoods。
	/// </summary>
	public class CK_TakeGoods
	{
		public CK_TakeGoods()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CK_TakeGoodsID", "CK_TakeGoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CK_TakeGoodsID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_TakeGoods");
			strSql.Append(" where CK_TakeGoodsID=@CK_TakeGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_TakeGoodsID", SqlDbType.Int,4)};
			parameters[0].Value = CK_TakeGoodsID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.CK_TakeGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_TakeGoods(");
			strSql.Append("CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_TakeGoodsNo,CK_TakeGoodsAmount,CK_TakeGoodsDate)");
			strSql.Append(" values (");
			strSql.Append("@CK_ProductTypeID,@CK_PeopleID,@CK_ProductID,@CK_TakeGoodsNo,@CK_TakeGoodsAmount,@CK_TakeGoodsDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4),
					new SqlParameter("@CK_TakeGoodsNo", SqlDbType.VarChar,32),
					new SqlParameter("@CK_TakeGoodsAmount", SqlDbType.Int,4),
					new SqlParameter("@CK_TakeGoodsDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CK_ProductTypeID;
			parameters[1].Value = model.CK_PeopleID;
			parameters[2].Value = model.CK_ProductID;
			parameters[3].Value = model.CK_TakeGoodsNo;
			parameters[4].Value = model.CK_TakeGoodsAmount;
			parameters[5].Value = model.CK_TakeGoodsDate;

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
		public void Update(TSM.Model.CK_TakeGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_TakeGoods set ");
			strSql.Append("CK_ProductTypeID=@CK_ProductTypeID,");
			strSql.Append("CK_PeopleID=@CK_PeopleID,");
			strSql.Append("CK_ProductID=@CK_ProductID,");
			strSql.Append("CK_TakeGoodsNo=@CK_TakeGoodsNo,");
			strSql.Append("CK_TakeGoodsAmount=@CK_TakeGoodsAmount,");
			strSql.Append("CK_TakeGoodsDate=@CK_TakeGoodsDate");
			strSql.Append(" where CK_TakeGoodsID=@CK_TakeGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_TakeGoodsID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_PeopleID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4),
					new SqlParameter("@CK_TakeGoodsNo", SqlDbType.VarChar,32),
					new SqlParameter("@CK_TakeGoodsAmount", SqlDbType.Int,4),
					new SqlParameter("@CK_TakeGoodsDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CK_TakeGoodsID;
			parameters[1].Value = model.CK_ProductTypeID;
			parameters[2].Value = model.CK_PeopleID;
			parameters[3].Value = model.CK_ProductID;
			parameters[4].Value = model.CK_TakeGoodsNo;
			parameters[5].Value = model.CK_TakeGoodsAmount;
			parameters[6].Value = model.CK_TakeGoodsDate;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_TakeGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_TakeGoods ");
			strSql.Append(" where CK_TakeGoodsID=@CK_TakeGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_TakeGoodsID", SqlDbType.Int,4)};
			parameters[0].Value = CK_TakeGoodsID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_TakeGoods GetModel(int CK_TakeGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CK_TakeGoodsID,CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_TakeGoodsNo,CK_TakeGoodsAmount,CK_TakeGoodsDate from CK_TakeGoods ");
			strSql.Append(" where CK_TakeGoodsID=@CK_TakeGoodsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_TakeGoodsID", SqlDbType.Int,4)};
			parameters[0].Value = CK_TakeGoodsID;

			TSM.Model.CK_TakeGoods model=new TSM.Model.CK_TakeGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_TakeGoodsID"].ToString()!="")
				{
					model.CK_TakeGoodsID=int.Parse(ds.Tables[0].Rows[0]["CK_TakeGoodsID"].ToString());
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
				model.CK_TakeGoodsNo=ds.Tables[0].Rows[0]["CK_TakeGoodsNo"].ToString();
				if(ds.Tables[0].Rows[0]["CK_TakeGoodsAmount"].ToString()!="")
				{
					model.CK_TakeGoodsAmount=int.Parse(ds.Tables[0].Rows[0]["CK_TakeGoodsAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_TakeGoodsDate"].ToString()!="")
				{
					model.CK_TakeGoodsDate=DateTime.Parse(ds.Tables[0].Rows[0]["CK_TakeGoodsDate"].ToString());
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
			strSql.Append("select CK_TakeGoodsID,CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_TakeGoodsNo,CK_TakeGoodsAmount,CK_TakeGoodsDate ");
			strSql.Append(" FROM CK_TakeGoods ");
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
			strSql.Append(" CK_TakeGoodsID,CK_ProductTypeID,CK_PeopleID,CK_ProductID,CK_TakeGoodsNo,CK_TakeGoodsAmount,CK_TakeGoodsDate ");
			strSql.Append(" FROM CK_TakeGoods ");
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
			parameters[0].Value = "CK_TakeGoods";
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

