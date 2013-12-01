using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_Borrow
	/// </summary>
	public partial class CK_Borrow
	{
		private readonly Maticsoft.DAL.CK_Borrow dal=new Maticsoft.DAL.CK_Borrow();
		public CK_Borrow()
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
		public void Add(Maticsoft.Model.CK_Borrow model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_Borrow model)
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
		public Maticsoft.Model.CK_Borrow GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CK_Borrow GetModelByCache(int ID)
		{
			
			string CacheKey = "CK_BorrowModel-" + ID;
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
			return (Maticsoft.Model.CK_Borrow)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public decimal GetSumBorror(string strWhere)
        {
            return dal.GetSumBorror(strWhere);
        }

        public DataTable GetListTable(string strWhere, string strWhere2)
		{
            return dal.GetListTable(strWhere, strWhere2);
		}

        
        public DataSet GetListT(string strWhere)
        {
            return dal.GetListT(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_Borrow> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_Borrow> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_Borrow> modelList = new List<Maticsoft.Model.CK_Borrow>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_Borrow model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_Borrow();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["AccountID"].ToString()!="")
					{
						model.AccountID=int.Parse(dt.Rows[n]["AccountID"].ToString());
					}
					if(dt.Rows[n]["WorkmanID"].ToString()!="")
					{
						model.WorkmanID=int.Parse(dt.Rows[n]["WorkmanID"].ToString());
					}
					if(dt.Rows[n]["BuildingID"].ToString()!="")
					{
						model.BuildingID=int.Parse(dt.Rows[n]["BuildingID"].ToString());
					}
					if(dt.Rows[n]["Money"].ToString()!="")
					{
						model.Money=decimal.Parse(dt.Rows[n]["Money"].ToString());
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

