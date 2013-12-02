using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类CK_Payment 的摘要说明。
	/// </summary>
	public class CK_Payment
	{
		private readonly TSM.DAL.CK_Payment dal=new TSM.DAL.CK_Payment();
		public CK_Payment()
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
		public bool Exists(int CK_PaymentID)
		{
			return dal.Exists(CK_PaymentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.CK_Payment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.CK_Payment model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CK_PaymentID)
		{
			
			dal.Delete(CK_PaymentID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.CK_Payment GetModel(int CK_PaymentID)
		{
			
			return dal.GetModel(CK_PaymentID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.CK_Payment GetModelByCache(int CK_PaymentID)
		{
			
			string CacheKey = "CK_PaymentModel-" + CK_PaymentID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_PaymentID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_Payment)objModel;
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
		public List<TSM.Model.CK_Payment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.CK_Payment> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_Payment> modelList = new List<TSM.Model.CK_Payment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_Payment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_Payment();
					if(dt.Rows[n]["CK_PaymentID"].ToString()!="")
					{
						model.CK_PaymentID=int.Parse(dt.Rows[n]["CK_PaymentID"].ToString());
					}
					if(dt.Rows[n]["CK_PeopleID"].ToString()!="")
					{
						model.CK_PeopleID=int.Parse(dt.Rows[n]["CK_PeopleID"].ToString());
					}
					if(dt.Rows[n]["CK_SendGoodsID"].ToString()!="")
					{
						model.CK_SendGoodsID=int.Parse(dt.Rows[n]["CK_SendGoodsID"].ToString());
					}
					if(dt.Rows[n]["CK_PayDate"].ToString()!="")
					{
						model.CK_PayDate=DateTime.Parse(dt.Rows[n]["CK_PayDate"].ToString());
					}
					if(dt.Rows[n]["CK_PayMoney"].ToString()!="")
					{
						model.CK_PayMoney=decimal.Parse(dt.Rows[n]["CK_PayMoney"].ToString());
					}
					model.CK_PayComment=dt.Rows[n]["CK_PayComment"].ToString();
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

