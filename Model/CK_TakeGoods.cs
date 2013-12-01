using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_TakeGoods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_TakeGoods
	{
		public CK_TakeGoods()
		{}
		#region Model
		private int _takegoodsid;
		private string _takeno;
		private int? _ck_typeid;
		private int? _productid;
		private int? _peopleid;
		private DateTime? _date;
		private decimal? _amount;
		/// <summary>
		/// 
		/// </summary>
		public int TakeGoodsID
		{
			set{ _takegoodsid=value;}
			get{return _takegoodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TakeNO
		{
			set{ _takeno=value;}
			get{return _takeno;}
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
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PeopleID
		{
			set{ _peopleid=value;}
			get{return _peopleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		#endregion Model

	}
}

