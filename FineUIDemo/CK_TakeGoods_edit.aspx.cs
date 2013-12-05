using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;


namespace FineUIDemo
{
    public partial class CK_TakeGoods_edit : Page
    {

        private TSM.BLL.CK_TakeGoods m_bllCK_TakeGoods = new TSM.BLL.CK_TakeGoods();
        private TSM.BLL.CK_Product m_bllCK_Product = new TSM.BLL.CK_Product();
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


            DataSet ds = m_bllCK_People.GetList("");
            DropDownListPeople.DataTextField = "CK_PeopleName";
            DropDownListPeople.DataValueField = "CK_PeopleID";
            DropDownListPeople.DataSource = ds.Tables[0];
            DropDownListPeople.DataBind();
            DropDownListPeople.SelectedIndex = 0;

            ds = m_bllCK_Product.GetList("");
            DropDownListProduct.DataTextField = "CK_ProductName";
            DropDownListProduct.DataValueField = "CK_ProductID";
            DropDownListProduct.DataSource = ds.Tables[0];
            DropDownListProduct.DataBind();
            DropDownListProduct.SelectedIndex = 0;

            int id = GetQueryIntValue("id");
            TSM.Model.CK_TakeGoods modelCK_TakeGoods = m_bllCK_TakeGoods.GetModel(id);

            if (modelCK_TakeGoods == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }
            DropDownListProduct.SelectedValue = modelCK_TakeGoods.CK_ProductID.ToString();
            DropDownListPeople.SelectedValue = modelCK_TakeGoods.CK_PeopleID.ToString();
            tbxCount.Text = modelCK_TakeGoods.CK_TakeGoodsAmount.ToString();
            DatePicker1.SelectedDate = modelCK_TakeGoods.CK_TakeGoodsDate;
            //tbxName.Text = modelCK_TakeGoods.CK_TakeGoodsName;
            //tbxPhoneNo.Text = modelCK_TakeGoods.CK_PhoneNo;
            //tbxNote.Text = modelCK_TakeGoods.CK_Comment;

        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.CK_TakeGoods modelCK_TakeGoods = m_bllCK_TakeGoods.GetModel(id);
            modelCK_TakeGoods.CK_ProductID = int.Parse(DropDownListProduct.SelectedValue);
            modelCK_TakeGoods.CK_PeopleID = int.Parse(DropDownListPeople.SelectedValue);
            modelCK_TakeGoods.CK_TakeGoodsAmount = int.Parse(tbxCount.Text.Trim());
            modelCK_TakeGoods.CK_TakeGoodsDate = (DateTime)DatePicker1.SelectedDate;


            m_bllCK_TakeGoods.Update(modelCK_TakeGoods);

            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
