using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类CK_ProductType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CK_ProductType
	{
		public CK_ProductType()
		{}
		#region Model
		private int _ck_producttypeid;
		private string _ck_producttypename;
		/// <summary>
		/// 
		/// </summary>
		public int CK_ProductTypeID
		{
			set{ _ck_producttypeid=value;}
			get{return _ck_producttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_ProductTypeName
		{
			set{ _ck_producttypename=value;}
			get{return _ck_producttypename;}
		}
		#endregion Model

	}
}

