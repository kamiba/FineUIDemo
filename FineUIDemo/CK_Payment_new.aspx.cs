using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;

namespace FineUIDemo
{
    public partial class CK_Payment_new : Page
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

        private void LoadData()
        {
    

            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            DataSet ds = m_bllCK_People.GetList("");
            DropDownListPeople.DataTextField = "CK_PeopleName";
            DropDownListPeople.DataValueField = "CK_PeopleID";
            DropDownListPeople.DataSource = ds.Tables[0];
            DropDownListPeople.DataBind();
            DropDownListPeople.SelectedIndex = 0;

        }

        #endregion

        #region Events
        private string GetTGNumber()
        {
            string strNo = "";
            int nMaxID = m_bllCK_Payment.GetMaxId();
            string strDate = System.DateTime.Now.Year.ToString()
                   + System.DateTime.Now.Month.ToString().PadLeft(2, '0')
                   + System.DateTime.Now.Day.ToString().PadLeft(2, '0');

            strNo = "QH" + strDate + nMaxID.ToString().PadLeft(8, '0');
            return strNo;
        }

        private void SavePayment()
        {
            TSM.Model.CK_Payment modelCK_Payment = new TSM.Model.CK_Payment();
            modelCK_Payment.CK_PeopleID = int.Parse(DropDownListPeople.SelectedValue);
            modelCK_Payment.CK_PayMoney = decimal.Parse(tbxCount.Text.Trim());
            modelCK_Payment.CK_PayDate = (DateTime)DatePicker1.SelectedDate;
            modelCK_Payment.CK_PayComment = tbxNote.Text.Trim();
            m_bllCK_Payment.Add(modelCK_Payment);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SavePayment();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
