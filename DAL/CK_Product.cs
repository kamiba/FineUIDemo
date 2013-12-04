using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类CK_Product。
	/// </summary>
	public class CK_Product
	{
		public CK_Product()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CK_ProductID", "CK_Product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CK_ProductID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_Product");
			strSql.Append(" where CK_ProductID=@CK_ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4)};
			parameters[0].Value = CK_ProductID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.CK_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_Product(");
			strSql.Append("CK_ProductTypeID,CK_ProductName,CK_ProductPrice)");
			strSql.Append(" values (");
			strSql.Append("@CK_ProductTypeID,@CK_ProductName,@CK_ProductPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductName", SqlDbType.VarChar,100),
					new SqlParameter("@CK_ProductPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CK_ProductTypeID;
			parameters[1].Value = model.CK_ProductName;
			parameters[2].Value = model.CK_ProductPrice;

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
		public void Update(TSM.Model.CK_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_Product set ");
			strSql.Append("CK_ProductTypeID=@CK_ProductTypeID,");
			strSql.Append("CK_ProductName=@CK_ProductName,");
			strSql.Append("CK_ProductPrice=@CK_ProductPrice");
			strSql.Append(" where CK_ProductID=@CK_ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@CK_ProductName", SqlDbType.VarChar,100),
					new SqlParameter("@CK_ProductPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CK_ProductID;
			parameters[1].Value = model.CK_ProductTypeID;
			parameters[2].Value = model.CK_ProductName;
			parameters[3].Value = model.CK_ProductPrice;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Product ");
			strSql.Append(" where CK_ProductID=@CK_ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4)};
			parameters[0].Value = CK_ProductID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_Product GetModel(int CK_ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CK_ProductID,CK_ProductTypeID,CK_ProductName,CK_ProductPrice from CK_Product ");
			strSql.Append(" where CK_ProductID=@CK_ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CK_ProductID", SqlDbType.Int,4)};
			parameters[0].Value = CK_ProductID;

			TSM.Model.CK_Product model=new TSM.Model.CK_Product();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_ProductID"].ToString()!="")
				{
					model.CK_ProductID=int.Parse(ds.Tables[0].Rows[0]["CK_ProductID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_ProductTypeID"].ToString()!="")
				{
					model.CK_ProductTypeID=int.Parse(ds.Tables[0].Rows[0]["CK_ProductTypeID"].ToString());
				}
				model.CK_ProductName=ds.Tables[0].Rows[0]["CK_ProductName"].ToString();
				if(ds.Tables[0].Rows[0]["CK_ProductPrice"].ToString()!="")
				{
					model.CK_ProductPrice=decimal.Parse(ds.Tables[0].Rows[0]["CK_ProductPrice"].ToString());
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
			strSql.Append("select * ");
            strSql.Append(" FROM v_listProductInfo ");
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
			strSql.Append(" CK_ProductID,CK_ProductTypeID,CK_ProductName,CK_ProductPrice ");
			strSql.Append(" FROM CK_Product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        
         //<summary>
         //分页获取数据列表
         //</summary>
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
            parameters[0].Value = "v_listProductInfo";
            parameters[1].Value = "CK_ProductID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

		#endregion  成员方法
	}
}

