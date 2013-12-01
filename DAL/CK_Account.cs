using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CK_Account
	/// </summary>
	public partial class CK_Account
	{
		public CK_Account()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("AccountID", "CK_Account"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AccountID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_Account");
			strSql.Append(" where AccountID=@AccountID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AccountID", DbType.Int32,4)};
			parameters[0].Value = AccountID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_Account(");
			strSql.Append("AccountID,PeopleID,Money,SendGoodsID,Date,Comment)");
			strSql.Append(" values (");
			strSql.Append("@AccountID,@PeopleID,@Money,@SendGoodsID,@Date,@Comment)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AccountID", DbType.Int32,4),
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@Money", DbType.Decimal,8),
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Comment", DbType.String,2147483647)};
			parameters[0].Value = model.AccountID;
			parameters[1].Value = model.PeopleID;
			parameters[2].Value = model.Money;
			parameters[3].Value = model.SendGoodsID;
			parameters[4].Value = model.Date;
			parameters[5].Value = model.Comment;

			DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_Account set ");
			strSql.Append("PeopleID=@PeopleID,");
			strSql.Append("Money=@Money,");
			strSql.Append("SendGoodsID=@SendGoodsID,");
			strSql.Append("Date=@Date,");
			strSql.Append("Comment=@Comment");
			strSql.Append(" where AccountID=@AccountID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@Money", DbType.Decimal,8),
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Comment", DbType.String,2147483647),
					new SQLiteParameter("@AccountID", DbType.Int32,4)};
			parameters[0].Value = model.PeopleID;
			parameters[1].Value = model.Money;
			parameters[2].Value = model.SendGoodsID;
			parameters[3].Value = model.Date;
			parameters[4].Value = model.Comment;
			parameters[5].Value = model.AccountID;

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
		public bool Delete(int AccountID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Account ");
			strSql.Append(" where AccountID=@AccountID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AccountID", DbType.Int32,4)};
			parameters[0].Value = AccountID;

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
		public bool DeleteList(string AccountIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Account ");
			strSql.Append(" where AccountID in ("+AccountIDlist + ")  ");
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
		public Maticsoft.Model.CK_Account GetModel(int AccountID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AccountID,PeopleID,Money,SendGoodsID,Date,Comment from CK_Account ");
			strSql.Append(" where AccountID=@AccountID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AccountID", DbType.Int32,4)};
			parameters[0].Value = AccountID;

			Maticsoft.Model.CK_Account model=new Maticsoft.Model.CK_Account();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AccountID"].ToString()!="")
				{
					model.AccountID=int.Parse(ds.Tables[0].Rows[0]["AccountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PeopleID"].ToString()!="")
				{
					model.PeopleID=int.Parse(ds.Tables[0].Rows[0]["PeopleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendGoodsID"].ToString()!="")
				{
					model.SendGoodsID=int.Parse(ds.Tables[0].Rows[0]["SendGoodsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
				}
				model.Comment=ds.Tables[0].Rows[0]["Comment"].ToString();
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
            strSql.Append("select AccountID,Money,PeopleID,SendGoodsID,Date,Comment ");
			strSql.Append(" FROM CK_Account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

        public DataSet GetMoneyList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tab1.peopleid 姓名,PayMoney 应付加工费,coalesce(PayedMoney,0) 已付加工费,(PayMoney - coalesce(PayedMoney,0)) 未付加工费
from (select peopleid,sum(CK_Product.Price*Amount) PayMoney from ck_Sendgoods
LEFT join CK_Product on CK_Product.ProductID = CK_SendGoods.ProductID
 group by peopleid) tab1
left join 
(select peopleid,sum(money) PayedMoney from ck_account group by peopleid) tab2
on tab1.[peopleid] = tab2.peopleid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
			parameters[0].Value = "CK_Account";
			parameters[1].Value = "AccountID";
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

