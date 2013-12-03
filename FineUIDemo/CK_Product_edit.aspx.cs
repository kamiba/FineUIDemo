using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;


namespace FineUIDemo
{
    public partial class CK_Product_edit : Page
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

            DataSet ds = m_bllCK_ProductType.GetList("");
            DropDownListProductType.DataTextField = "CK_ProductTypeName";
            DropDownListProductType.DataValueField = "CK_ProductTypeID";
            DropDownListProductType.DataSource = ds.Tables[0];
            DropDownListProductType.DataBind();
            DropDownListProductType.SelectedIndex = 0;

            int id = GetQueryIntValue("id");
            TSM.Model.CK_Product modelCK_Product = m_bllCK_Product.GetModel(id);

            if (modelCK_Product == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            tbxName.Text = modelCK_Product.CK_ProductName;
            tbxPrice.Text = modelCK_Product.CK_ProductPrice.ToString();
            DropDownListProductType.SelectedValue = modelCK_Product.CK_ProductTypeID.ToString();

        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.CK_Product modelCK_Product = m_bllCK_Product.GetModel(id);
            modelCK_Product.CK_ProductName = tbxName.Text.Trim();
            modelCK_Product.CK_ProductPrice = Convert.ToDecimal(tbxPrice.Text.Trim());

            modelCK_Product.CK_ProductTypeID = int.Parse(DropDownListProductType.SelectedValue);


            m_bllCK_Product.Update(modelCK_Product);

            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
