using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaleManagement
{
    public partial class Site : System.Web.UI.MasterPage
    {
        /// <summary>
        ///  <para>Câu chào mừng account đăng nhập ở phía trên bên phải website</para>
        /// </summary>
        protected string GetUserName { get { return "Chào mừng <b>" + Session["UserName"] + "</b>"; } }
        protected string GetFullName { get { return (Session["EmployeeName"] == null) ? " Mời đăng nhập lại" : Session["EmployeeName"].ToString(); } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            //Redirect về trang Đăng nhập
            Response.Redirect("~/Login.aspx", true);
        }

    }
}