using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类CK_SendGoods 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CK_SendGoods
	{
		public CK_SendGoods()
		{}
		#region Model
		private int _ck_sendgoodsid;
		private int _ck_peopleid;
		private int _ck_productid;
		private string _ck_sendgoodsno;
		private int _ck_sendgoodsamount;
		private DateTime _ck_sendgoodsdate;
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
		public int CK_PeopleID
		{
			set{ _ck_peopleid=value;}
			get{return _ck_peopleid;}
		}
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
		public string CK_SendGoodsNo
		{
			set{ _ck_sendgoodsno=value;}
			get{return _ck_sendgoodsno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CK_SendGoodsAmount
		{
			set{ _ck_sendgoodsamount=value;}
			get{return _ck_sendgoodsamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CK_SendGoodsDate
		{
			set{ _ck_sendgoodsdate=value;}
			get{return _ck_sendgoodsdate;}
		}
		#endregion Model

	}
}

