using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_TakeGoods
	/// </summary>
	public partial class CK_TakeGoods
	{
		private readonly Maticsoft.DAL.CK_TakeGoods dal=new Maticsoft.DAL.CK_TakeGoods();
		public CK_TakeGoods()
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
		public bool Exists(int TakeGoodsID)
		{
			return dal.Exists(TakeGoodsID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_TakeGoods model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_TakeGoods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TakeGoodsID)
		{
			
			return dal.Delete(TakeGoodsID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TakeGoodsIDlist )
		{
			return dal.DeleteList(TakeGoodsIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CK_TakeGoods GetModel(int TakeGoodsID)
		{
			
			return dal.GetModel(TakeGoodsID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CK_TakeGoods GetModelByCache(int TakeGoodsID)
		{
			
			string CacheKey = "CK_TakeGoodsModel-" + TakeGoodsID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TakeGoodsID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CK_TakeGoods)objModel;
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
		public List<Maticsoft.Model.CK_TakeGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_TakeGoods> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_TakeGoods> modelList = new List<Maticsoft.Model.CK_TakeGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_TakeGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_TakeGoods();
					if(dt.Rows[n]["TakeGoodsID"].ToString()!="")
					{
						model.TakeGoodsID=int.Parse(dt.Rows[n]["TakeGoodsID"].ToString());
					}
					model.TakeNO=dt.Rows[n]["TakeNO"].ToString();
					if(dt.Rows[n]["CK_TypeID"].ToString()!="")
					{
						model.CK_TypeID=int.Parse(dt.Rows[n]["CK_TypeID"].ToString());
					}
					if(dt.Rows[n]["ProductID"].ToString()!="")
					{
						model.ProductID=int.Parse(dt.Rows[n]["ProductID"].ToString());
					}
					if(dt.Rows[n]["PeopleID"].ToString()!="")
					{
						model.PeopleID=int.Parse(dt.Rows[n]["PeopleID"].ToString());
					}
					if(dt.Rows[n]["Date"].ToString()!="")
					{
						model.Date=DateTime.Parse(dt.Rows[n]["Date"].ToString());
					}
					if(dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
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
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

