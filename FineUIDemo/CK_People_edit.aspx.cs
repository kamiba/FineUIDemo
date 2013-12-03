using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;


namespace FineUIDemo
{
    public partial class CK_People_edit : Page
    {

        private TSM.BLL.CK_People m_bllCK_People = new TSM.BLL.CK_People();



        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        protected int GetQueryIntValue(string queryKey)
        {
            int queryIntValue = -1;
            try
            {
                queryIntValue = Convert.ToInt32(Request.QueryString[queryKey]);
            }
            catch (Exception)
            {
                // TODO
            }

            return queryIntValue;
        }
        private void LoadData()
        {
 

            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            TSM.Model.CK_People modelCK_People = m_bllCK_People.GetModel(id);

            if (modelCK_People == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            tbxName.Text = modelCK_People.CK_PeopleName;
            tbxPhoneNo.Text = modelCK_People.CK_PhoneNo;
            tbxNote.Text = modelCK_People.CK_Comment;

        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.CK_People modelCK_People = m_bllCK_People.GetModel(id);
            modelCK_People.CK_PeopleName = tbxName.Text.Trim();
            modelCK_People.CK_PhoneNo = tbxPhoneNo.Text.Trim();
            modelCK_People.CK_Comment = tbxNote.Text.Trim();


            m_bllCK_People.Update(modelCK_People);

            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
