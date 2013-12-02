using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;

namespace FineUIDemo
{
    public partial class CK_ProductType_new : Page
    {

        private TSM.BLL.CK_ProductType m_bllCK_ProductType = new TSM.BLL.CK_ProductType();


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

        private void SaveJobTitle()
        {
            TSM.Model.CK_ProductType modelCK_ProductType = new TSM.Model.CK_ProductType();
            modelCK_ProductType.CK_ProductTypeName = tbxName.Text.Trim();


            m_bllCK_ProductType.Add(modelCK_ProductType);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveJobTitle();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
