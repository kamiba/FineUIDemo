using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CK_TakeGoods
	/// </summary>
	public partial class CK_TakeGoods
	{
		public CK_TakeGoods()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("TakeGoodsID", "CK_TakeGoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TakeGoodsID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_TakeGoods");
			strSql.Append(" where TakeGoodsID=@TakeGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TakeGoodsID", DbType.Int32,4)};
			parameters[0].Value = TakeGoodsID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_TakeGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_TakeGoods(");
			strSql.Append("TakeGoodsID,TakeNO,CK_TypeID,ProductID,PeopleID,Date,Amount)");
			strSql.Append(" values (");
			strSql.Append("@TakeGoodsID,@TakeNO,@CK_TypeID,@ProductID,@PeopleID,@Date,@Amount)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TakeGoodsID", DbType.Int32,4),
					new SQLiteParameter("@TakeNO", DbType.String,2147483647),
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@ProductID", DbType.Int32,4),
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Amount", DbType.Decimal,8)};
			parameters[0].Value = model.TakeGoodsID;
			parameters[1].Value = model.TakeNO;
			parameters[2].Value = model.CK_TypeID;
			parameters[3].Value = model.ProductID;
			parameters[4].Value = model.PeopleID;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Amount;

			DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_TakeGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_TakeGoods set ");
			strSql.Append("TakeNO=@TakeNO,");
			strSql.Append("CK_TypeID=@CK_TypeID,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("PeopleID=@PeopleID,");
			strSql.Append("Date=@Date,");
			strSql.Append("Amount=@Amount");
			strSql.Append(" where TakeGoodsID=@TakeGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TakeNO", DbType.String,2147483647),
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@ProductID", DbType.Int32,4),
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Amount", DbType.Decimal,8),
					new SQLiteParameter("@TakeGoodsID", DbType.Int32,4)};
			parameters[0].Value = model.TakeNO;
			parameters[1].Value = model.CK_TypeID;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.PeopleID;
			parameters[4].Value = model.Date;
			parameters[5].Value = model.Amount;
			parameters[6].Value = model.TakeGoodsID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int TakeGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_TakeGoods ");
			strSql.Append(" where TakeGoodsID=@TakeGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TakeGoodsID", DbType.Int32,4)};
			parameters[0].Value = TakeGoodsID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string TakeGoodsIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_TakeGoods ");
			strSql.Append(" where TakeGoodsID in ("+TakeGoodsIDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.CK_TakeGoods GetModel(int TakeGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TakeGoodsID,TakeNO,CK_TypeID,ProductID,PeopleID,Date,Amount from CK_TakeGoods ");
			strSql.Append(" where TakeGoodsID=@TakeGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@TakeGoodsID", DbType.Int32,4)};
			parameters[0].Value = TakeGoodsID;

			Maticsoft.Model.CK_TakeGoods model=new Maticsoft.Model.CK_TakeGoods();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TakeGoodsID"].ToString()!="")
				{
					model.TakeGoodsID=int.Parse(ds.Tables[0].Rows[0]["TakeGoodsID"].ToString());
				}
				model.TakeNO=ds.Tables[0].Rows[0]["TakeNO"].ToString();
				if(ds.Tables[0].Rows[0]["CK_TypeID"].ToString()!="")
				{
					model.CK_TypeID=int.Parse(ds.Tables[0].Rows[0]["CK_TypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PeopleID"].ToString()!="")
				{
					model.PeopleID=int.Parse(ds.Tables[0].Rows[0]["PeopleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
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
            strSql.Append(@"select TakeGoodsID
,TakeNO
,Date
,PeopleID
,CK_TakeGoods.CK_TypeID
,CK_TakeGoods.ProductID
,Amount
,CK_Product.Unit Unit ");
			strSql.Append(" FROM CK_TakeGoods ");
            strSql.Append("LEFT join CK_Product on CK_Product.ProductID = CK_TakeGoods.ProductID");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" ORDER BY Date ,PeopleID ASC");
             
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "CK_TakeGoods";
			parameters[1].Value = "TakeGoodsID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

