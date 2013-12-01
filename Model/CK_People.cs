using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_People:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_People
	{
		public CK_People()
		{}
		#region Model
		private int _peopleid;
		private string _peoplename;
		private string _mobile;
		private string _comment;
		private int? _obligate;
		private DateTime? _obligate2;
		private string _obligate3;
		private decimal? _obligate4;
		/// <summary>
		/// 
		/// </summary>
		public int PeopleID
		{
			set{ _peopleid=value;}
			get{return _peopleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PeopleName
		{
			set{ _peoplename=value;}
			get{return _peoplename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? obligate
		{
			set{ _obligate=value;}
			get{return _obligate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? obligate2
		{
			set{ _obligate2=value;}
			get{return _obligate2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string obligate3
		{
			set{ _obligate3=value;}
			get{return _obligate3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? obligate4
		{
			set{ _obligate4=value;}
			get{return _obligate4;}
		}
		#endregion Model

	}
}

