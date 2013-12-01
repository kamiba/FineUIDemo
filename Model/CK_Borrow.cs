using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_Borrow:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_Borrow
	{
		public CK_Borrow()
		{}
		#region Model
		private int _id;
		private int? _accountid;
		private int? _workmanid;
		private int? _buildingid;
		private decimal? _money;
		private DateTime? _date;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
		public int? AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WorkmanID
		{
			set{ _workmanid=value;}
			get{return _workmanid;}
		}
		public int? BuildingID
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
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

