using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using FineUI;
using System.Security.Principal;
using System.Text;


namespace FineUIDemo
{
    public partial class _default : Page
    {

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

            // 如果用户已经登录，则重定向到管理首页
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

            Window1.Title = String.Format("系统登录（取送货管理系统）");

        }

        #endregion

        #region Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = tbxUserName.Text.Trim();
            string password = tbxPassword.Text.Trim();




            if (userName=="admin"&&password=="admin")
            {
                LoginSuccess();

                return;
            }
            else
            {
                Alert.Show("用户名或密码错误！");
                return;
            }

        }


        private void LoginSuccess()
        {


            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, 
                "admin", 
                DateTime.Now,
                DateTime.Now.AddMinutes(120), 
                true,
                "", 
                FormsAuthentication.FormsCookiePath);
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
            userCookie.HttpOnly = true;
            userCookie.Expires = DateTime.Now.AddMinutes(120);
            Response.Cookies.Add(userCookie);
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }


        #endregion
    }
}
