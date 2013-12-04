using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类CK_TakeGoods 的摘要说明。
	/// </summary>
	public class CK_TakeGoods
	{
		private readonly TSM.DAL.CK_TakeGoods dal=new TSM.DAL.CK_TakeGoods();
		public CK_TakeGoods()
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
		public bool Exists(int CK_TakeGoodsID)
		{
			return dal.Exists(CK_TakeGoodsID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.CK_TakeGoods model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.CK_TakeGoods model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_TakeGoodsID)
		{
			
			dal.Delete(CK_TakeGoodsID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_TakeGoods GetModel(int CK_TakeGoodsID)
		{
			
			return dal.GetModel(CK_TakeGoodsID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.CK_TakeGoods GetModelByCache(int CK_TakeGoodsID)
		{
			
			string CacheKey = "CK_TakeGoodsModel-" + CK_TakeGoodsID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_TakeGoodsID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_TakeGoods)objModel;
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
		public List<TSM.Model.CK_TakeGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.CK_TakeGoods> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_TakeGoods> modelList = new List<TSM.Model.CK_TakeGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_TakeGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_TakeGoods();
					if(dt.Rows[n]["CK_TakeGoodsID"].ToString()!="")
					{
						model.CK_TakeGoodsID=int.Parse(dt.Rows[n]["CK_TakeGoodsID"].ToString());
					}
					if(dt.Rows[n]["CK_ProductTypeID"].ToString()!="")
					{
						model.CK_ProductTypeID=int.Parse(dt.Rows[n]["CK_ProductTypeID"].ToString());
					}
					if(dt.Rows[n]["CK_PeopleID"].ToString()!="")
					{
						model.CK_PeopleID=int.Parse(dt.Rows[n]["CK_PeopleID"].ToString());
					}
					if(dt.Rows[n]["CK_ProductID"].ToString()!="")
					{
						model.CK_ProductID=int.Parse(dt.Rows[n]["CK_ProductID"].ToString());
					}
					model.CK_TakeGoodsNo=dt.Rows[n]["CK_TakeGoodsNo"].ToString();
					if(dt.Rows[n]["CK_TakeGoodsAmount"].ToString()!="")
					{
						model.CK_TakeGoodsAmount=int.Parse(dt.Rows[n]["CK_TakeGoodsAmount"].ToString());
					}
					if(dt.Rows[n]["CK_TakeGoodsDate"].ToString()!="")
					{
						model.CK_TakeGoodsDate=DateTime.Parse(dt.Rows[n]["CK_TakeGoodsDate"].ToString());
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

