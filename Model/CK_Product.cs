using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类CK_Product 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CK_Product
	{
		public CK_Product()
		{}
		#region Model
		private int _ck_productid;
		private int _ck_producttypeid;
		private string _ck_productname;
		private decimal _ck_productprice;
		/// <summary>
		/// 
		/// </summary>
		public int CK_ProductID
		{
			set{ _ck_productid=value;}
			get{return _ck_productid;}
		}
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
		public string CK_ProductName
		{
			set{ _ck_productname=value;}
			get{return _ck_productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CK_ProductPrice
		{
			set{ _ck_productprice=value;}
			get{return _ck_productprice;}
		}
		#endregion Model

	}
}

