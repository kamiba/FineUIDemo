using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类CK_SendGoods 的摘要说明。
	/// </summary>
	public class CK_SendGoods
	{
		private readonly TSM.DAL.CK_SendGoods dal=new TSM.DAL.CK_SendGoods();
		public CK_SendGoods()
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
		public bool Exists(int CK_SendGoodsID)
		{
			return dal.Exists(CK_SendGoodsID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.CK_SendGoods model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.CK_SendGoods model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_SendGoodsID)
		{
			
			dal.Delete(CK_SendGoodsID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_SendGoods GetModel(int CK_SendGoodsID)
		{
			
			return dal.GetModel(CK_SendGoodsID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.CK_SendGoods GetModelByCache(int CK_SendGoodsID)
		{
			
			string CacheKey = "CK_SendGoodsModel-" + CK_SendGoodsID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_SendGoodsID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_SendGoods)objModel;
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
		public List<TSM.Model.CK_SendGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.CK_SendGoods> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_SendGoods> modelList = new List<TSM.Model.CK_SendGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_SendGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_SendGoods();
					if(dt.Rows[n]["CK_SendGoodsID"].ToString()!="")
					{
						model.CK_SendGoodsID=int.Parse(dt.Rows[n]["CK_SendGoodsID"].ToString());
					}
					if(dt.Rows[n]["CK_PeopleID"].ToString()!="")
					{
						model.CK_PeopleID=int.Parse(dt.Rows[n]["CK_PeopleID"].ToString());
					}
					if(dt.Rows[n]["CK_ProductID"].ToString()!="")
					{
						model.CK_ProductID=int.Parse(dt.Rows[n]["CK_ProductID"].ToString());
					}
					model.CK_SendGoodsNo=dt.Rows[n]["CK_SendGoodsNo"].ToString();
					if(dt.Rows[n]["CK_SendGoodsAmount"].ToString()!="")
					{
						model.CK_SendGoodsAmount=int.Parse(dt.Rows[n]["CK_SendGoodsAmount"].ToString());
					}
					if(dt.Rows[n]["CK_SendGoodsDate"].ToString()!="")
					{
						model.CK_SendGoodsDate=DateTime.Parse(dt.Rows[n]["CK_SendGoodsDate"].ToString());
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

