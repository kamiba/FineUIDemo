using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CK_SendGoods
	/// </summary>
	public partial class CK_SendGoods
	{
		public CK_SendGoods()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("SendGoodsID", "CK_SendGoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SendGoodsID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_SendGoods");
			strSql.Append(" where SendGoodsID=@SendGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4)};
			parameters[0].Value = SendGoodsID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_SendGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_SendGoods(");
			strSql.Append("SendGoodsID,SendNO,CK_TypeID,ProductID,Price,PeopleID,Date,Amount,Money)");
			strSql.Append(" values (");
			strSql.Append("@SendGoodsID,@SendNO,@CK_TypeID,@ProductID,@Price,@PeopleID,@Date,@Amount,@Money)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4),
					new SQLiteParameter("@SendNO", DbType.String,2147483647),
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@ProductID", DbType.Int32,4),
					new SQLiteParameter("@Price", DbType.Decimal,8),
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Amount", DbType.Decimal,8),
					new SQLiteParameter("@Money", DbType.Decimal,8)};
			parameters[0].Value = model.SendGoodsID;
			parameters[1].Value = model.SendNO;
			parameters[2].Value = model.CK_TypeID;
			parameters[3].Value = model.ProductID;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.PeopleID;
			parameters[6].Value = model.Date;
			parameters[7].Value = model.Amount;
			parameters[8].Value = model.Money;

			DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_SendGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_SendGoods set ");
			strSql.Append("SendNO=@SendNO,");
			strSql.Append("CK_TypeID=@CK_TypeID,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("Price=@Price,");
			strSql.Append("PeopleID=@PeopleID,");
			strSql.Append("Date=@Date,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("Money=@Money");
			strSql.Append(" where SendGoodsID=@SendGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@SendNO", DbType.String,2147483647),
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@ProductID", DbType.Int32,4),
					new SQLiteParameter("@Price", DbType.Decimal,8),
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Amount", DbType.Decimal,8),
					new SQLiteParameter("@Money", DbType.Decimal,8),
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4)};
			parameters[0].Value = model.SendNO;
			parameters[1].Value = model.CK_TypeID;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.PeopleID;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Amount;
			parameters[7].Value = model.Money;
			parameters[8].Value = model.SendGoodsID;

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
		public bool Delete(int SendGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_SendGoods ");
			strSql.Append(" where SendGoodsID=@SendGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4)};
			parameters[0].Value = SendGoodsID;

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
		public bool DeleteList(string SendGoodsIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_SendGoods ");
			strSql.Append(" where SendGoodsID in ("+SendGoodsIDlist + ")  ");
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
		public Maticsoft.Model.CK_SendGoods GetModel(int SendGoodsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SendGoodsID,SendNO,CK_TypeID,ProductID,Price,PeopleID,Date,Amount,Money from CK_SendGoods ");
			strSql.Append(" where SendGoodsID=@SendGoodsID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@SendGoodsID", DbType.Int32,4)};
			parameters[0].Value = SendGoodsID;

			Maticsoft.Model.CK_SendGoods model=new Maticsoft.Model.CK_SendGoods();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SendGoodsID"].ToString()!="")
				{
					model.SendGoodsID=int.Parse(ds.Tables[0].Rows[0]["SendGoodsID"].ToString());
				}
				model.SendNO=ds.Tables[0].Rows[0]["SendNO"].ToString();
				if(ds.Tables[0].Rows[0]["CK_TypeID"].ToString()!="")
				{
					model.CK_TypeID=int.Parse(ds.Tables[0].Rows[0]["CK_TypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
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
            strSql.Append(@"select SendGoodsID
,SendNO
,Date
,PeopleID
,CK_SendGoods.CK_TypeID
,CK_SendGoods.ProductID
,CK_Product.Price
,Amount
,CK_Product.Unit Unit
,CK_Product.Price*Amount Money 
");
			strSql.Append(" FROM CK_SendGoods ");
            strSql.Append("LEFT join CK_Product on CK_Product.ProductID = CK_SendGoods.ProductID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" ORDER BY Date,PeopleID ASC");
			return DbHelperSQLite.Query(strSql.ToString());
		}


        public DataSet GetInGoods(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append(@" select CK_People.PeopleName 姓名,CK_Type.CK_TypeName 类别
,CK_Product.ProductName 货物名称,tab1.sum 取走数量,coalesce(tab2.sum,0) 已送回数量,tab1.sum - coalesce(tab2.sum,0) 未送回数量 from
(select peopleid,productid,sum(Amount) sum from ck_takegoods group by productid,peopleid) tab1
left join 
(select peopleid,productid,sum(Amount) sum from ck_sendgoods group by productid,peopleid) tab2
on tab2.peopleid =tab1.peopleid and tab2.productid = tab1.productid 
left join CK_Product on CK_Product.ProductID = tab1.productid 
left join CK_Type on CK_Type.CK_TypeID =  CK_Product.CK_TypeID
left join CK_People on CK_People.Peopleid = tab1.peopleid ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "CK_SendGoods";
			parameters[1].Value = "SendGoodsID";
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

