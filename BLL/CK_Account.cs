using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_Account
	/// </summary>
	public partial class CK_Account
	{
		private readonly Maticsoft.DAL.CK_Account dal=new Maticsoft.DAL.CK_Account();
		public CK_Account()
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
		public bool Exists(int AccountID)
		{
			return dal.Exists(AccountID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.CK_Account model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_Account model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AccountID)
		{
			
			return dal.Delete(AccountID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string AccountIDlist )
		{
			return dal.DeleteList(AccountIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CK_Account GetModel(int AccountID)
		{
			
			return dal.GetModel(AccountID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CK_Account GetModelByCache(int AccountID)
		{
			
			string CacheKey = "CK_AccountModel-" + AccountID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AccountID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CK_Account)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataSet GetMoneyList(string strWhere)
        {
            return dal.GetMoneyList(strWhere);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_Account> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_Account> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_Account> modelList = new List<Maticsoft.Model.CK_Account>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_Account model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_Account();
					if(dt.Rows[n]["AccountID"].ToString()!="")
					{
						model.AccountID=int.Parse(dt.Rows[n]["AccountID"].ToString());
					}
					if(dt.Rows[n]["PeopleID"].ToString()!="")
					{
						model.PeopleID=int.Parse(dt.Rows[n]["PeopleID"].ToString());
					}
					if(dt.Rows[n]["Money"].ToString()!="")
					{
						model.Money=decimal.Parse(dt.Rows[n]["Money"].ToString());
					}
					if(dt.Rows[n]["SendGoodsID"].ToString()!="")
					{
						model.SendGoodsID=int.Parse(dt.Rows[n]["SendGoodsID"].ToString());
					}
					if(dt.Rows[n]["Date"].ToString()!="")
					{
						model.Date=DateTime.Parse(dt.Rows[n]["Date"].ToString());
					}
					model.Comment=dt.Rows[n]["Comment"].ToString();
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

