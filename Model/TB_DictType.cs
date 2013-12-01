using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// TB_DictType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TB_DictType
	{
		public TB_DictType()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _remark;
		private string _seq;
		private int? _editor;
        private DateTime? _lastupdated;
		private string _pid;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Editor
		{
			set{ _editor=value;}
			get{return _editor;}
		}
		/// <summary>
		/// 
		/// </summary>
        public DateTime? LastUpdated
        {
            set { _lastupdated = value; }
            get { return _lastupdated; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		#endregion Model

	}
}

