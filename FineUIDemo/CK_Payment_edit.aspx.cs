using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;


namespace FineUIDemo
{
    public partial class CK_Payment_edit : Page
    {

        private TSM.BLL.CK_Payment m_bllCK_Payment = new TSM.BLL.CK_Payment();
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


            int id = GetQueryIntValue("id");
            TSM.Model.CK_Payment modelCK_Payment = m_bllCK_Payment.GetModel(id);

            if (modelCK_Payment == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }
            tbxNote.Text = modelCK_Payment.CK_PayComment;
            DropDownListPeople.SelectedValue = modelCK_Payment.CK_PeopleID.ToString();
            tbxCount.Text = modelCK_Payment.CK_PayMoney.ToString();
            DatePicker1.SelectedDate = modelCK_Payment.CK_PayDate;
            //tbxName.Text = modelCK_Payment.CK_PaymentName;
            //tbxPhoneNo.Text = modelCK_Payment.CK_PhoneNo;
            //tbxNote.Text = modelCK_Payment.CK_Comment;

        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.CK_Payment modelCK_Payment = m_bllCK_Payment.GetModel(id);
            modelCK_Payment.CK_PeopleID = int.Parse(DropDownListPeople.SelectedValue);
            modelCK_Payment.CK_PayMoney = decimal.Parse(tbxCount.Text.Trim());
            modelCK_Payment.CK_PayDate = (DateTime)DatePicker1.SelectedDate;
            modelCK_Payment.CK_PayComment = tbxNote.Text.Trim();

            m_bllCK_Payment.Update(modelCK_Payment);

            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
