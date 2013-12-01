using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// T_ACL_User
	/// </summary>
	public partial class T_ACL_User
	{
		private readonly Maticsoft.DAL.T_ACL_User dal=new Maticsoft.DAL.T_ACL_User();
		public T_ACL_User()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.T_ACL_User model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.T_ACL_User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.T_ACL_User GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.T_ACL_User GetModelByCache(int ID)
		{
			
			string CacheKey = "T_ACL_UserModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.T_ACL_User)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.T_ACL_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.T_ACL_User> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.T_ACL_User> modelList = new List<Maticsoft.Model.T_ACL_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.T_ACL_User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.T_ACL_User();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["PID"].ToString()!="")
					{
						model.PID=int.Parse(dt.Rows[n]["PID"].ToString());
					}
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.FullName=dt.Rows[n]["FullName"].ToString();
					if(dt.Rows[n]["IsExpire"].ToString()!="")
					{
						if((dt.Rows[n]["IsExpire"].ToString()=="1")||(dt.Rows[n]["IsExpire"].ToString().ToLower()=="true"))
						{
						model.IsExpire=true;
						}
						else
						{
							model.IsExpire=false;
						}
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.IdentityCard=dt.Rows[n]["IdentityCard"].ToString();
					model.MobilePhone=dt.Rows[n]["MobilePhone"].ToString();
					model.OfficePhone=dt.Rows[n]["OfficePhone"].ToString();
					model.HomePhone=dt.Rows[n]["HomePhone"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.Address=dt.Rows[n]["Address"].ToString();
					model.CustomField=dt.Rows[n]["CustomField"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

