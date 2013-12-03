using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;

namespace FineUIDemo
{
    public partial class CK_People_new : Page
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

        private void LoadData()
        {
    

            btnClose.OnClientClick = ActiveWindow.GetHideReference();

        }

        #endregion

        #region Events

        private void SavePeople()
        {
            TSM.Model.CK_People modelCK_People = new TSM.Model.CK_People();
            modelCK_People.CK_PeopleName = tbxName.Text.Trim();
            modelCK_People.CK_PhoneNo = tbxPhoneNo.Text.Trim();
            modelCK_People.CK_Comment = tbxNote.Text.Trim();

            m_bllCK_People.Add(modelCK_People);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SavePeople();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
