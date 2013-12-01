using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_Account
	{
		public CK_Account()
		{}
		#region Model
		private int _accountid;
		private int? _peopleid;
		private decimal? _money;
		private int? _sendgoodsid;
		private DateTime? _date;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
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
		public decimal? Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SendGoodsID
		{
			set{ _sendgoodsid=value;}
			get{return _sendgoodsid;}
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
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		#endregion Model

	}
}

