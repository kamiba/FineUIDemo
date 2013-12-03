using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;

namespace FineUIDemo
{
    public partial class CK_Product_new : Page
    {

        private TSM.BLL.CK_Product m_bllCK_Product = new TSM.BLL.CK_Product();
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

            DataSet ds = m_bllCK_ProductType.GetList("");
            DropDownListProductType.DataTextField = "CK_ProductTypeName";
            DropDownListProductType.DataValueField = "CK_ProductTypeID";
            DropDownListProductType.DataSource = ds.Tables[0];
            DropDownListProductType.DataBind();
            DropDownListProductType.SelectedIndex = 0;
        }

        #endregion

        #region Events

        private void SaveProduct()
        {
            TSM.Model.CK_Product modelCK_Product = new TSM.Model.CK_Product();
            modelCK_Product.CK_ProductName = tbxName.Text.Trim();
            modelCK_Product.CK_ProductPrice = Convert.ToDecimal(tbxPrice.Text.Trim());
            //modelCK_Product.CK_Comment = tbxNote.Text.Trim();
            modelCK_Product.CK_ProductTypeID = int.Parse(DropDownListProductType.SelectedValue);
            m_bllCK_Product.Add(modelCK_Product);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveProduct();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
