using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:TB_DictType
	/// </summary>
	public partial class TB_DictType
	{
		public TB_DictType()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_DictType");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String)};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.TB_DictType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_DictType(");
			strSql.Append("ID,Name,Remark,Seq,Editor,LastUpdated,PID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Name,@Remark,@Seq,@Editor,@LastUpdated,@PID)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String),
					new SQLiteParameter("@Name", DbType.String),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@Seq", DbType.String),
					new SQLiteParameter("@Editor", DbType.Int32,4),
					new SQLiteParameter("@LastUpdated", DbType.DateTime),
					new SQLiteParameter("@PID", DbType.String)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Seq;
			parameters[4].Value = model.Editor;
			parameters[5].Value = model.LastUpdated;
			parameters[6].Value = model.PID;

			DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.TB_DictType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_DictType set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Seq=@Seq,");
			strSql.Append("Editor=@Editor,");
			strSql.Append("LastUpdated=@LastUpdated,");
			strSql.Append("PID=@PID");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Name", DbType.String),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@Seq", DbType.String),
					new SQLiteParameter("@Editor", DbType.Int32,4),
					new SQLiteParameter("@LastUpdated", DbType.DateTime),
					new SQLiteParameter("@PID", DbType.String),
					new SQLiteParameter("@ID", DbType.String)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Remark;
			parameters[2].Value = model.Seq;
			parameters[3].Value = model.Editor;
			parameters[4].Value = model.LastUpdated;
			parameters[5].Value = model.PID;
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
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_DictType ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String)};
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
			strSql.Append("delete from TB_DictType ");
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
		public Maticsoft.Model.TB_DictType GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,Remark,Seq,Editor,LastUpdated,PID from TB_DictType ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String)};
			parameters[0].Value = ID;

			Maticsoft.Model.TB_DictType model=new Maticsoft.Model.TB_DictType();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Seq=ds.Tables[0].Rows[0]["Seq"].ToString();
				if(ds.Tables[0].Rows[0]["Editor"].ToString()!="")
				{
					model.Editor=int.Parse(ds.Tables[0].Rows[0]["Editor"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastUpdated"].ToString()!="")
				{
					model.LastUpdated=DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdated"].ToString());
				}
				model.PID=ds.Tables[0].Rows[0]["PID"].ToString();
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
			strSql.Append("select ID,Name,Remark,Seq,Editor,LastUpdated,PID ");
			strSql.Append(" FROM TB_DictType ");
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
			parameters[0].Value = "TB_DictType";
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

