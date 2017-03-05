using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaleManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Cookies["UserName"] != null && Request.Cookies["PassWord"] != null)
            //{
            //    txtUserName.Text = Request.Cookies["UserName"].Value;
            //    txtPassWord.Attributes["value"] = Request.Cookies["PassWord"].Value;
            //}
        }
        //Nút đăng nhập
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginClass lc = new LoginClass();
            lc.UserName = txtUserName.Text.Trim();
            lc.Pass = txtPass.Text;
            try
            {
                DataTable dtUser = lc.LoginUser(lc);
                //kiểm tra user và pass trống
                if (string.IsNullOrEmpty(lc.UserName) || string.IsNullOrEmpty(lc.Pass))
                {
                    lblWarning.Text = "Tên đăng nhập hoặc mật khẩu để trống. Đề nghị nhập lại.";
                }
                else if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    Session["UserName"] = dtUser.Rows[0]["UserName"];
                    Session["RoleId"] = dtUser.Rows[0]["RoleId"];
                    Session["EmployeeName"] = dtUser.Rows[0]["EmployeeName"];
                    Response.Redirect("/Controls/Customer.aspx");
                }
                else
                    lblWarning.Text = "Tài khoản chưa kích hoạt hoặc sai thông tin tài khoản.";
            }
            catch (ArgumentNullException ex)
            {
                lblWarning.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
            }

        }
    }
}