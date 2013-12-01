using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CK_Type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CK_Type
	{
		public CK_Type()
		{}
		#region Model
		private int _ck_typeid;
		private string _ck_typename;
		/// <summary>
		/// 
		/// </summary>
		public int CK_TypeID
		{
			set{ _ck_typeid=value;}
			get{return _ck_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_TypeName
		{
			set{ _ck_typename=value;}
			get{return _ck_typename;}
		}
		#endregion Model

	}
}

