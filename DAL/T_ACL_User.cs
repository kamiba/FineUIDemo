using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:T_ACL_User
	/// </summary>
	public partial class T_ACL_User
	{
		public T_ACL_User()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "T_ACL_User"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_ACL_User");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.T_ACL_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_ACL_User(");
			strSql.Append("ID,PID,Name,Password,FullName,IsExpire,Title,IdentityCard,MobilePhone,OfficePhone,HomePhone,Email,Address,CustomField)");
			strSql.Append(" values (");
			strSql.Append("@ID,@PID,@Name,@Password,@FullName,@IsExpire,@Title,@IdentityCard,@MobilePhone,@OfficePhone,@HomePhone,@Email,@Address,@CustomField)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4),
					new SQLiteParameter("@PID", DbType.Int32,4),
					new SQLiteParameter("@Name", DbType.String),
					new SQLiteParameter("@Password", DbType.String),
					new SQLiteParameter("@FullName", DbType.String),
                    new SQLiteParameter("@IsExpire", DbType.Boolean,1),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@IdentityCard", DbType.String),
					new SQLiteParameter("@MobilePhone", DbType.String),
					new SQLiteParameter("@OfficePhone", DbType.String),
					new SQLiteParameter("@HomePhone", DbType.String),
					new SQLiteParameter("@Email", DbType.String),
					new SQLiteParameter("@Address", DbType.String),
					new SQLiteParameter("@CustomField", DbType.String)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.PID;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.FullName;
			parameters[5].Value = model.IsExpire;
			parameters[6].Value = model.Title;
			parameters[7].Value = model.IdentityCard;
			parameters[8].Value = model.MobilePhone;
			parameters[9].Value = model.OfficePhone;
			parameters[10].Value = model.HomePhone;
			parameters[11].Value = model.Email;
			parameters[12].Value = model.Address;
			parameters[13].Value = model.CustomField;

			DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.T_ACL_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_ACL_User set ");
			strSql.Append("PID=@PID,");
			strSql.Append("Name=@Name,");
			strSql.Append("Password=@Password,");
			strSql.Append("FullName=@FullName,");
			strSql.Append("IsExpire=@IsExpire,");
			strSql.Append("Title=@Title,");
			strSql.Append("IdentityCard=@IdentityCard,");
			strSql.Append("MobilePhone=@MobilePhone,");
			strSql.Append("OfficePhone=@OfficePhone,");
			strSql.Append("HomePhone=@HomePhone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Address=@Address,");
			strSql.Append("CustomField=@CustomField");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@PID", DbType.Int32,4),
					new SQLiteParameter("@Name", DbType.String),
					new SQLiteParameter("@Password", DbType.String),
					new SQLiteParameter("@FullName", DbType.String),
					new SQLiteParameter("@IsExpire", DbType.Boolean,1),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@IdentityCard", DbType.String),
					new SQLiteParameter("@MobilePhone", DbType.String),
					new SQLiteParameter("@OfficePhone", DbType.String),
					new SQLiteParameter("@HomePhone", DbType.String),
					new SQLiteParameter("@Email", DbType.String),
					new SQLiteParameter("@Address", DbType.String),
					new SQLiteParameter("@CustomField", DbType.String),
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.FullName;
			parameters[4].Value = model.IsExpire;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.IdentityCard;
			parameters[7].Value = model.MobilePhone;
			parameters[8].Value = model.OfficePhone;
			parameters[9].Value = model.HomePhone;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.Address;
			parameters[12].Value = model.CustomField;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from T_ACL_User ");
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
			strSql.Append("delete from T_ACL_User ");
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
		public Maticsoft.Model.T_ACL_User GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PID,Name,Password,FullName,IsExpire,Title,IdentityCard,MobilePhone,OfficePhone,HomePhone,Email,Address,CustomField from T_ACL_User ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)};
			parameters[0].Value = ID;

			Maticsoft.Model.T_ACL_User model=new Maticsoft.Model.T_ACL_User();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PID"].ToString()!="")
				{
					model.PID=int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.FullName=ds.Tables[0].Rows[0]["FullName"].ToString();
				if(ds.Tables[0].Rows[0]["IsExpire"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsExpire"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsExpire"].ToString().ToLower()=="true"))
					{
						model.IsExpire=true;
					}
					else
					{
						model.IsExpire=false;
					}
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.IdentityCard=ds.Tables[0].Rows[0]["IdentityCard"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.OfficePhone=ds.Tables[0].Rows[0]["OfficePhone"].ToString();
				model.HomePhone=ds.Tables[0].Rows[0]["HomePhone"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.CustomField=ds.Tables[0].Rows[0]["CustomField"].ToString();
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
			strSql.Append("select ID,PID,Name,Password,FullName,IsExpire,Title,IdentityCard,MobilePhone,OfficePhone,HomePhone,Email,Address,CustomField ");
			strSql.Append(" FROM T_ACL_User ");
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
			parameters[0].Value = "T_ACL_User";
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

