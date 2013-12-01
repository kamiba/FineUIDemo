using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CK_Borrow
	/// </summary>
	public partial class CK_Borrow
	{
		public CK_Borrow()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "CK_Borrow"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_Borrow");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_Borrow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_Borrow(");
			strSql.Append("ID,AccountID,WorkmanID,BuildingID,Money,Date,Comment)");
			strSql.Append(" values (");
			strSql.Append("@ID,@AccountID,@WorkmanID,@BuildingID,@Money,@Date,@Comment)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4),
					new SQLiteParameter("@AccountID", DbType.Int32,4),
					new SQLiteParameter("@WorkmanID", DbType.Int32,4),
					new SQLiteParameter("@BuildingID", DbType.Int32,4),
					new SQLiteParameter("@Money", DbType.Decimal,8),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Comment", DbType.String,2147483647)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.AccountID;
			parameters[2].Value = model.WorkmanID;
			parameters[3].Value = model.BuildingID;
			parameters[4].Value = model.Money;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Comment;

			DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_Borrow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_Borrow set ");
			strSql.Append("AccountID=@AccountID,");
			strSql.Append("WorkmanID=@WorkmanID,");
			strSql.Append("BuildingID=@BuildingID,");
			strSql.Append("Money=@Money,");
			strSql.Append("Date=@Date,");
			strSql.Append("Comment=@Comment");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@AccountID", DbType.Int32,4),
					new SQLiteParameter("@WorkmanID", DbType.Int32,4),
					new SQLiteParameter("@BuildingID", DbType.Int32,4),
					new SQLiteParameter("@Money", DbType.Decimal,8),
					new SQLiteParameter("@Date", DbType.DateTime),
					new SQLiteParameter("@Comment", DbType.String,2147483647),
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = model.AccountID;
			parameters[1].Value = model.WorkmanID;
			parameters[2].Value = model.BuildingID;
			parameters[3].Value = model.Money;
			parameters[4].Value = model.Date;
			parameters[5].Value = model.Comment;
			parameters[6].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Borrow ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Borrow ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.CK_Borrow GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,AccountID,WorkmanID,BuildingID,Money,Date,Comment from CK_Borrow ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = ID;

			Maticsoft.Model.CK_Borrow model=new Maticsoft.Model.CK_Borrow();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AccountID"].ToString()!="")
				{
					model.AccountID=int.Parse(ds.Tables[0].Rows[0]["AccountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WorkmanID"].ToString()!="")
				{
					model.WorkmanID=int.Parse(ds.Tables[0].Rows[0]["WorkmanID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuildingID"].ToString()!="")
				{
					model.BuildingID=int.Parse(ds.Tables[0].Rows[0]["BuildingID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
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
			strSql.Append("select ID,AccountID,WorkmanID,BuildingID,Money,Date,Comment ");
			strSql.Append(" FROM CK_Borrow ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

        public decimal GetSumBorror(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Money) sum");
            strSql.Append(" FROM CK_Borrow ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQLite.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["sum"].ToString() != "")
                {
                    return Convert.ToDecimal(ds.Tables[0].Rows[0]["sum"].ToString());
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public DataTable GetListTable(string strWhere, string strWhere2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,AccountID,WorkmanID 姓名,Money 借支金额,Date 日期,BuildingID 借支工地,Comment 备注 ");
            strSql.Append(" FROM CK_Borrow ");
            strSql.Append(" where  WorkmanID in (select CK_Salary.WorkmanID ");
            strSql.Append(" FROM CK_Salary ");
            strSql.Append(" join CK_Workman on CK_Workman.WorkmanID = CK_Salary.WorkmanID ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(" where " + strWhere2);
            }

            if (strWhere.Trim() != "")
            {
                strSql.Append(") and " + strWhere);
            }
            return DbHelperSQLite.Query1(strSql.ToString());
        }

        public DataSet GetListT(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,WorkmanID,Money,Date,BuildingID,Comment,strftime('%m',Date) 月份,strftime('%Y',Date) 年份 ");
            strSql.Append(" FROM CK_Borrow ");
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
			parameters[0].Value = "CK_Borrow";
			parameters[1].Value = "ID";
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

