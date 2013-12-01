using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// TB_DictData
	/// </summary>
	public partial class TB_DictData
	{
		private readonly Maticsoft.DAL.TB_DictData dal=new Maticsoft.DAL.TB_DictData();
		public TB_DictData()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.TB_DictData model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.TB_DictData model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
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
		public Maticsoft.Model.TB_DictData GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.TB_DictData GetModelByCache(string ID)
		{
			
			string CacheKey = "TB_DictDataModel-" + ID;
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
			return (Maticsoft.Model.TB_DictData)objModel;
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
		public List<Maticsoft.Model.TB_DictData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.TB_DictData> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.TB_DictData> modelList = new List<Maticsoft.Model.TB_DictData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.TB_DictData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.TB_DictData();
					model.ID=dt.Rows[n]["ID"].ToString();
					model.DictType_ID=dt.Rows[n]["DictType_ID"].ToString();
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Value=dt.Rows[n]["Value"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					model.Seq=dt.Rows[n]["Seq"].ToString();
					model.Editor=dt.Rows[n]["Editor"].ToString();
					if(dt.Rows[n]["LastUpdated"].ToString()!="")
					{
						model.LastUpdated=DateTime.Parse(dt.Rows[n]["LastUpdated"].ToString());
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

