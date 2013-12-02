using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类CK_Payment 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CK_Payment
	{
		public CK_Payment()
		{}
		#region Model
		private int _ck_paymentid;
		private int _ck_peopleid;
		private int _ck_sendgoodsid;
		private DateTime _ck_paydate;
		private decimal _ck_paymoney;
		private string _ck_paycomment;
		/// <summary>
		/// 
		/// </summary>
		public int CK_PaymentID
		{
			set{ _ck_paymentid=value;}
			get{return _ck_paymentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CK_PeopleID
		{
			set{ _ck_peopleid=value;}
			get{return _ck_peopleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CK_SendGoodsID
		{
			set{ _ck_sendgoodsid=value;}
			get{return _ck_sendgoodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CK_PayDate
		{
			set{ _ck_paydate=value;}
			get{return _ck_paydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CK_PayMoney
		{
			set{ _ck_paymoney=value;}
			get{return _ck_paymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_PayComment
		{
			set{ _ck_paycomment=value;}
			get{return _ck_paycomment;}
		}
		#endregion Model

	}
}

