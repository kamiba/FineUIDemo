using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类CK_People 的摘要说明。
	/// </summary>
	public class CK_People
	{
		private readonly TSM.DAL.CK_People dal=new TSM.DAL.CK_People();
		public CK_People()
		{}
		#region  成员方法

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
		public bool Exists(int CK_PeopleID)
		{
			return dal.Exists(CK_PeopleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.CK_People model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.CK_People model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_PeopleID)
		{
			
			dal.Delete(CK_PeopleID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_People GetModel(int CK_PeopleID)
		{
			
			return dal.GetModel(CK_PeopleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.CK_People GetModelByCache(int CK_PeopleID)
		{
			
			string CacheKey = "CK_PeopleModel-" + CK_PeopleID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_PeopleID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_People)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.CK_People> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.CK_People> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_People> modelList = new List<TSM.Model.CK_People>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_People model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_People();
					if(dt.Rows[n]["CK_PeopleID"].ToString()!="")
					{
						model.CK_PeopleID=int.Parse(dt.Rows[n]["CK_PeopleID"].ToString());
					}
					model.CK_PeopleName=dt.Rows[n]["CK_PeopleName"].ToString();
					model.CK_PhoneNo=dt.Rows[n]["CK_PhoneNo"].ToString();
					model.CK_Comment=dt.Rows[n]["CK_Comment"].ToString();
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
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

