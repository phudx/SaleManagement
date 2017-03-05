using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaleManagement.Controls
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] + "" == "")
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                //string userid = Session["user_id"].ToString();
                //hdnChiefID.Value = user.getChiefByUserID(userid);
                //if (hdnChiefID.Value == "0")//chiefID: ID PCT phụ trách của acc đăng nhập; 0: Nếu không tính được
                //    pnShowCheckboxReport.Visible = false;//Ẩn panel chứa checkbox báo cáo với PCT

                //hdnAccount.Value = Session["UserName"].ToString();
                //hdnUserId.Value = Session["user_id"].ToString();
                //LoadInitData();
            }
        }

    }
}