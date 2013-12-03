using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类CK_Product 的摘要说明。
	/// </summary>
	public class CK_Product
	{
		private readonly TSM.DAL.CK_Product dal=new TSM.DAL.CK_Product();
		public CK_Product()
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
		public bool Exists(int CK_ProductID)
		{
			return dal.Exists(CK_ProductID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.CK_Product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.CK_Product model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_ProductID)
		{
			
			dal.Delete(CK_ProductID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_Product GetModel(int CK_ProductID)
		{
			
			return dal.GetModel(CK_ProductID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.CK_Product GetModelByCache(int CK_ProductID)
		{
			
			string CacheKey = "CK_ProductModel-" + CK_ProductID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_ProductID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_Product)objModel;
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
		public List<TSM.Model.CK_Product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.CK_Product> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_Product> modelList = new List<TSM.Model.CK_Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_Product model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_Product();
					if(dt.Rows[n]["CK_ProductID"].ToString()!="")
					{
						model.CK_ProductID=int.Parse(dt.Rows[n]["CK_ProductID"].ToString());
					}
					if(dt.Rows[n]["CK_ProductTypeID"].ToString()!="")
					{
						model.CK_ProductTypeID=int.Parse(dt.Rows[n]["CK_ProductTypeID"].ToString());
					}
					model.CK_ProductName=dt.Rows[n]["CK_ProductName"].ToString();
					if(dt.Rows[n]["CK_ProductPrice"].ToString()!="")
					{
						model.CK_ProductPrice=decimal.Parse(dt.Rows[n]["CK_ProductPrice"].ToString());
					}
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

		#endregion  成员方法
	}
}

