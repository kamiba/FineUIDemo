using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_SendGoods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_SendGoods
	{
		public CK_SendGoods()
		{}
		#region Model
		private int _sendgoodsid;
		private string _sendno;
		private int? _ck_typeid;
		private int? _productid;
		private decimal? _price;
		private int? _peopleid;
		private DateTime? _date;
		private decimal? _amount;
		private decimal? _money;
		/// <summary>
		/// 
		/// </summary>
		public int SendGoodsID
		{
			set{ _sendgoodsid=value;}
			get{return _sendgoodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendNO
		{
			set{ _sendno=value;}
			get{return _sendno;}
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
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
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
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		#endregion Model

	}
}

