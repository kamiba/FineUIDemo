using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_People
	/// </summary>
	public partial class CK_People
	{
		private readonly Maticsoft.DAL.CK_People dal=new Maticsoft.DAL.CK_People();
		public CK_People()
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
		public bool Exists(int PeopleID)
		{
			return dal.Exists(PeopleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CK_People model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CK_People model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PeopleID)
		{
			
			return dal.Delete(PeopleID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PeopleIDlist )
		{
			return dal.DeleteList(PeopleIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CK_People GetModel(int PeopleID)
		{
			
			return dal.GetModel(PeopleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CK_People GetModelByCache(int PeopleID)
		{
			
			string CacheKey = "CK_PeopleModel-" + PeopleID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PeopleID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CK_People)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataSet GetOnlyList(string strWhere)
        {
            return dal.GetOnlyList(strWhere);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_People> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CK_People> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_People> modelList = new List<Maticsoft.Model.CK_People>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_People model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_People();
					if(dt.Rows[n]["PeopleID"].ToString()!="")
					{
						model.PeopleID=int.Parse(dt.Rows[n]["PeopleID"].ToString());
					}
					model.PeopleName=dt.Rows[n]["PeopleName"].ToString();
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					model.Comment=dt.Rows[n]["Comment"].ToString();
					if(dt.Rows[n]["obligate"].ToString()!="")
					{
						model.obligate=int.Parse(dt.Rows[n]["obligate"].ToString());
					}
					if(dt.Rows[n]["obligate2"].ToString()!="")
					{
						model.obligate2=DateTime.Parse(dt.Rows[n]["obligate2"].ToString());
					}
					model.obligate3=dt.Rows[n]["obligate3"].ToString();
					if(dt.Rows[n]["obligate4"].ToString()!="")
					{
						model.obligate4=decimal.Parse(dt.Rows[n]["obligate4"].ToString());
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

