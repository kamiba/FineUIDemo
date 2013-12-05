using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类CK_TakeGoods 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CK_TakeGoods
	{
		public CK_TakeGoods()
		{}
		#region Model
		private int _ck_takegoodsid;
		private int _ck_peopleid;
		private int _ck_productid;
		private string _ck_takegoodsno;
		private int _ck_takegoodsamount;
		private DateTime _ck_takegoodsdate;
		/// <summary>
		/// 
		/// </summary>
		public int CK_TakeGoodsID
		{
			set{ _ck_takegoodsid=value;}
			get{return _ck_takegoodsid;}
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
		public string CK_TakeGoodsNo
		{
			set{ _ck_takegoodsno=value;}
			get{return _ck_takegoodsno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CK_TakeGoodsAmount
		{
			set{ _ck_takegoodsamount=value;}
			get{return _ck_takegoodsamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CK_TakeGoodsDate
		{
			set{ _ck_takegoodsdate=value;}
			get{return _ck_takegoodsdate;}
		}
		#endregion Model

	}
}

