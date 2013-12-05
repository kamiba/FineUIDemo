using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;

namespace FineUIDemo
{
    public partial class CK_SendGoods_new : Page
    {

        private TSM.BLL.CK_SendGoods m_bllCK_SendGoods = new TSM.BLL.CK_SendGoods();
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
        }

        #endregion

        #region Events
        private string GetTGNumber()
        {
            string strNo = "";
            int nMaxID = m_bllCK_SendGoods.GetMaxId();
            string strDate = System.DateTime.Now.Year.ToString()
                   + System.DateTime.Now.Month.ToString().PadLeft(2, '0')
                   + System.DateTime.Now.Day.ToString().PadLeft(2, '0');

            strNo = "QH" + strDate + nMaxID.ToString().PadLeft(8, '0');
            return strNo;
        }

        private void SaveSendGoods()
        {
            TSM.Model.CK_SendGoods modelCK_SendGoods = new TSM.Model.CK_SendGoods();
            modelCK_SendGoods.CK_ProductID = int.Parse(DropDownListProduct.SelectedValue);
            modelCK_SendGoods.CK_PeopleID = int.Parse(DropDownListPeople.SelectedValue);
            modelCK_SendGoods.CK_SendGoodsAmount = int.Parse(tbxCount.Text.Trim());
            modelCK_SendGoods.CK_SendGoodsDate = (DateTime)DatePicker1.SelectedDate;
            modelCK_SendGoods.CK_SendGoodsNo = GetTGNumber();
            m_bllCK_SendGoods.Add(modelCK_SendGoods);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveSendGoods();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
