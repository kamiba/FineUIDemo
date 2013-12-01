using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_Product
	{
		public CK_Product()
		{}
		#region Model
		private int _productid;
		private int? _ck_typeid;
		private string _productname;
		private decimal? _price;
		private string _unit;
		/// <summary>
		/// 
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CK_TypeID
		{
			set{ _ck_typeid=value;}
			get{return _ck_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		#endregion Model

	}
}

