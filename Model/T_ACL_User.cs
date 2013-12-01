using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// T_ACL_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ACL_User
	{
		public T_ACL_User()
		{}
		#region Model
		private int _id;
		private int _pid=(-1);
		private string _name="";
		private string _password="";
		private string _fullname="";
		private bool _isexpire= false;
		private string _title="";
		private string _identitycard="";
		private string _mobilephone="";
		private string _officephone="";
		private string _homephone="";
		private string _email="";
		private string _address="";
		private string _customfield="";
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
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
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsExpire
		{
			set{ _isexpire=value;}
			get{return _isexpire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IdentityCard
		{
			set{ _identitycard=value;}
			get{return _identitycard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OfficePhone
		{
			set{ _officephone=value;}
			get{return _officephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomePhone
		{
			set{ _homephone=value;}
			get{return _homephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomField
		{
			set{ _customfield=value;}
			get{return _customfield;}
		}
		#endregion Model

	}
}

