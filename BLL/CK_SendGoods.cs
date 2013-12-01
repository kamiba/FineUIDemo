using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_SendGoods
	/// </summary>
	public partial class CK_SendGoods
	{
		private readonly Maticsoft.DAL.CK_SendGoods dal=new Maticsoft.DAL.CK_SendGoods();
		public CK_SendGoods()
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
		public bool Exists(int SendGoodsID)
		{
			return dal.Exists(SendGoodsID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_SendGoods model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_SendGoods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SendGoodsID)
		{
			
			return dal.Delete(SendGoodsID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SendGoodsIDlist )
		{
			return dal.DeleteList(SendGoodsIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CK_SendGoods GetModel(int SendGoodsID)
		{
			
			return dal.GetModel(SendGoodsID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CK_SendGoods GetModelByCache(int SendGoodsID)
		{
			
			string CacheKey = "CK_SendGoodsModel-" + SendGoodsID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SendGoodsID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CK_SendGoods)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataSet GetInGoods(string strWhere)
        {
            return dal.GetInGoods(strWhere);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_SendGoods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_SendGoods> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_SendGoods> modelList = new List<Maticsoft.Model.CK_SendGoods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_SendGoods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_SendGoods();
					if(dt.Rows[n]["SendGoodsID"].ToString()!="")
					{
						model.SendGoodsID=int.Parse(dt.Rows[n]["SendGoodsID"].ToString());
					}
					model.SendNO=dt.Rows[n]["SendNO"].ToString();
					if(dt.Rows[n]["CK_TypeID"].ToString()!="")
					{
						model.CK_TypeID=int.Parse(dt.Rows[n]["CK_TypeID"].ToString());
					}
					if(dt.Rows[n]["ProductID"].ToString()!="")
					{
						model.ProductID=int.Parse(dt.Rows[n]["ProductID"].ToString());
					}
					if(dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
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
					if(dt.Rows[n]["Money"].ToString()!="")
					{
						model.Money=decimal.Parse(dt.Rows[n]["Money"].ToString());
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

