using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CK_People
	/// </summary>
	public partial class CK_People
	{
		public CK_People()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("PeopleID", "CK_People"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PeopleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_People");
			strSql.Append(" where PeopleID=@PeopleID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PeopleID", DbType.Int32,4)};
			parameters[0].Value = PeopleID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CK_People model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_People(");
			strSql.Append("PeopleID,PeopleName,Mobile,Comment,obligate,obligate2,obligate3,obligate4)");
			strSql.Append(" values (");
			strSql.Append("@PeopleID,@PeopleName,@Mobile,@Comment,@obligate,@obligate2,@obligate3,@obligate4)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PeopleID", DbType.Int32,4),
					new SQLiteParameter("@PeopleName", DbType.String,2147483647),
					new SQLiteParameter("@Mobile", DbType.String,2147483647),
					new SQLiteParameter("@Comment", DbType.String,2147483647),
					new SQLiteParameter("@obligate", DbType.Int32,4),
					new SQLiteParameter("@obligate2", DbType.DateTime),
					new SQLiteParameter("@obligate3", DbType.String,2147483647),
					new SQLiteParameter("@obligate4", DbType.Decimal,8)};
			parameters[0].Value = model.PeopleID;
			parameters[1].Value = model.PeopleName;
			parameters[2].Value = model.Mobile;
			parameters[3].Value = model.Comment;
			parameters[4].Value = model.obligate;
			parameters[5].Value = model.obligate2;
			parameters[6].Value = model.obligate3;
			parameters[7].Value = model.obligate4;

            object obj = DbHelperSQLite.GetSingle(strSql.ToString(), parameters);
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
		public bool Update(Maticsoft.Model.CK_People model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_People set ");
			strSql.Append("PeopleName=@PeopleName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Comment=@Comment,");
			strSql.Append("obligate=@obligate,");
			strSql.Append("obligate2=@obligate2,");
			strSql.Append("obligate3=@obligate3,");
			strSql.Append("obligate4=@obligate4");
			strSql.Append(" where PeopleID=@PeopleID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PeopleName", DbType.String,2147483647),
					new SQLiteParameter("@Mobile", DbType.String,2147483647),
					new SQLiteParameter("@Comment", DbType.String,2147483647),
					new SQLiteParameter("@obligate", DbType.Int32,4),
					new SQLiteParameter("@obligate2", DbType.DateTime),
					new SQLiteParameter("@obligate3", DbType.String,2147483647),
					new SQLiteParameter("@obligate4", DbType.Decimal,8),
					new SQLiteParameter("@PeopleID", DbType.Int32,4)};
			parameters[0].Value = model.PeopleName;
			parameters[1].Value = model.Mobile;
			parameters[2].Value = model.Comment;
			parameters[3].Value = model.obligate;
			parameters[4].Value = model.obligate2;
			parameters[5].Value = model.obligate3;
			parameters[6].Value = model.obligate4;
			parameters[7].Value = model.PeopleID;

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
		public bool Delete(int PeopleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_People ");
			strSql.Append(" where PeopleID=@PeopleID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PeopleID", DbType.Int32,4)};
			parameters[0].Value = PeopleID;

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
		public bool DeleteList(string PeopleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_People ");
			strSql.Append(" where PeopleID in ("+PeopleIDlist + ")  ");
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
		public Maticsoft.Model.CK_People GetModel(int PeopleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PeopleID,PeopleName,Mobile,Comment,obligate,obligate2,obligate3,obligate4 from CK_People ");
			strSql.Append(" where PeopleID=@PeopleID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PeopleID", DbType.Int32,4)};
			parameters[0].Value = PeopleID;

			Maticsoft.Model.CK_People model=new Maticsoft.Model.CK_People();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PeopleID"].ToString()!="")
				{
					model.PeopleID=int.Parse(ds.Tables[0].Rows[0]["PeopleID"].ToString());
				}
				model.PeopleName=ds.Tables[0].Rows[0]["PeopleName"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.Comment=ds.Tables[0].Rows[0]["Comment"].ToString();
				if(ds.Tables[0].Rows[0]["obligate"].ToString()!="")
				{
					model.obligate=int.Parse(ds.Tables[0].Rows[0]["obligate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["obligate2"].ToString()!="")
				{
					model.obligate2=DateTime.Parse(ds.Tables[0].Rows[0]["obligate2"].ToString());
				}
				model.obligate3=ds.Tables[0].Rows[0]["obligate3"].ToString();
				if(ds.Tables[0].Rows[0]["obligate4"].ToString()!="")
				{
					model.obligate4=decimal.Parse(ds.Tables[0].Rows[0]["obligate4"].ToString());
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
        /// </summary>,Comment,obligate,obligate2,obligate3,obligate4
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PeopleID,PeopleName,Mobile ");
			strSql.Append(" FROM CK_People ");
            strSql.Append(" where PeopleID != 0 ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" and " + strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

        public DataSet GetOnlyList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PeopleID,PeopleName");
            strSql.Append(" FROM CK_People ");
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
			parameters[0].Value = "CK_People";
			parameters[1].Value = "PeopleID";
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

