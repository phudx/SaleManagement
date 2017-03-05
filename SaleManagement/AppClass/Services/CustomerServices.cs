using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;

namespace SaleManagement
{
    /// <author>
    /// Bkav Corp. - [EnterpriseTools]
    /// Create Date : [24062016]
    /// Author      : [PhuDX] 
    /// Description : ...
    /// *************************************************
    /// - [Email người sửa] - [yyyyMMdd]: [Lý do sửa ...]
    /// - [Email người sửa] - [yyyyMMdd]: [Lý do sửa...]
    /// </author>
    /// <summary>
    /// Webservice làm việc CSDL, dùng để thêm, sửa, xóa các chức năng.
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CustomerServices : WebService
    {
        public CustomerServices()
        {
            //TODO
        }
        /// <summary>
        /// Lấy thông tin của Tên nhóm địa chỉ đưa vào textbox Nhóm địa chỉ form Cập nhật thông tin khách hàng.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] SuggestionGroup()
        {
            Collection<string> group = new Collection<string>();
            ConnectionData data = new ConnectionData();
            SqlDataReader idr;
            try
            {
                string query = "SELECT g.GroupName,g.Id FROM [Group] g";
                idr = data.ExcuteDataReaderSql(query);
                while (idr.Read())
                {
                    group.Add(string.Format(CultureInfo.CurrentCulture, "{0},{1}", idr["Id"], idr["GroupName"]));
                }
                idr.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                data.CloseConnect();
                data = null;
            }
            return group.ToArray();
        }
        /// <author>
        /// PhuDX - [Email người sửa] - [2016-30-09]
        /// </author>
        /// <summary>
        /// Load toàn bộ dữ liệu thông tin khách hàng
        /// </summary>
        /// <returns></returns>
        [WebMethod(enableSession: true)]
        public string GetAllCustomer()
        {
            CustomerClass cc = new CustomerClass();
            DataTable dt = new DataTable();
            try
            {
                using (dt = cc.GetAllCustomer())
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        StringBuilder htmlText = new StringBuilder();
                        htmlText.AppendLine("<table width='100%' class='table table-striped table-bordered table-hover' id='dataTables-example'>");
                        htmlText.AppendLine("<thead><tr>");
                        htmlText.AppendLine(
                           "<th>Mã khách hàng</th>" +
                           "<th>Tên khách hàng</th>" +
                           "<th>Số điện thoại</th>" +
                           "<th>Địa chỉ</th>" +
                           "<th>Nhóm địa chỉ</th>" +
                           "<th>Công nợ</th>" +
                           "<th>Ghi chú</th>" +
                           "<th>Chọn</th>" +
                           "<th>Chức năng</th>");
                        htmlText.AppendLine("</tr></thead>");
                        htmlText.AppendLine("<tbody>");
                        foreach (DataRow dr in dt.Rows)
                        {
                            string btnSua = "<a data-toggle='modal' data-target='#InsertOrUpdate' href=\"javascript:void(0)\" style=\"text-decoration: none;\"><img src=\"../Images/edit.png\" id=\"imgEdit\" class=\"imgbtn\" title=\"Sửa thông tin\"alt=\"InsertOrUpdate\" onclick=\"InsertOrUpdate('" + dr["CustomerCode"] + "','" + dr["CustomerName"] + "','" + dr["Phone"] + "','" + dr["Address"] + "','" + dr["GroupName"] + "','" + dr["Note"] + "')\" /></a>";
                            string btnXoa = "<a data-toggle='modal' data-target='#Delete' href=\"javascript:void(0)\" style=\"text-decoration: none;\"><img src=\"../Images/delete.png\"  id=\"imgXoa\"   class=\"imgbtn\" title=\"Xóa khách hàng\"     alt=\"Delete\" onclick=\"Delete('" + dr["CustomerCode"] + "','" + dr["CustomerName"] + "')\" /></a>";
                            htmlText.AppendLine("<td>" + dr["CustomerCode"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["CustomerName"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Phone"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Address"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["GroupName"] + "</td>");
                            htmlText.AppendLine("<td>10.000.000 Đ</td>");
                            htmlText.AppendLine("<td>" + dr["Note"] + "</td>");
                            htmlText.AppendLine("<td style='text-align:center'><input id='tick-choose-customer' type='checkbox' value='" + dr["CustomerCode"] + "'/></td>");
                            htmlText.AppendLine("<td style='text-align:center'>" + btnSua + btnXoa + "</td>");
                            htmlText.AppendLine("</tr>");
                        }
                        htmlText.AppendLine("</tbody>");
                        htmlText.AppendLine("</table>");
                        return ResultObject.ReturnResult(htmlText.ToString(), true);
                    }
                    return ResultObject.ReturnResult("Không có bản ghi nào phù hợp với bộ lọc, hãy kiểm tra lại.", false);
                }
            }
            catch (SqlException ex)
            {
                return ResultObject.ReturnResult("GetAllCustomer-SqlException:" + ex.Message, false);
            }
            catch (ArgumentException ex)
            {
                return ResultObject.ReturnResult("GetAllCustomer-ArgumentException:" + ex.Message, false);
            }
        }
        /// <summary>
        /// Service lấy ra mã khách hàng để Thêm mới
        /// </summary>
        /// <returns>CustomerCode mới</returns>
        [WebMethod]
        public string GetCustomerCodeInsert()
        {
            try
            {
                CustomerClass cc = new CustomerClass();
                return ResultObject.ReturnResult(cc.GetCustomerCodeInsert(), true);
            }
            catch (SqlException ex)
            {
                return ResultObject.ReturnResult("GetCustomerCodeInsert-SqlException:" + ex.Message, false);
            }
            catch (ArgumentException ex)
            {
                return ResultObject.ReturnResult("GetCustomerCodeInsert-ArgumentException:" + ex.Message, false);
            }
        }
        /// <summary>
        /// Thông báo cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="cc">CustomerClass</param>
        /// <returns></returns>
        [WebMethod(enableSession: true)]
        public string InsertOrUpdateCustomer(CustomerClass cc)
        {
            if (string.IsNullOrEmpty(Context.Session["UserName"].ToString()))
                return ResultObject.ReturnResult("Phiên làm việc kết thúc, mời bạn đăng nhập lại", false);
            else
            {
                string mess = "Cập nhật thông tin khách hàng thất bại. Mời thao tác lại!";
                try
                {
                    if (cc.InsertOrUpdateCustomer(cc) > 0)
                        mess = "Ok";
                }
                catch (SqlException ex)
                {
                    return ResultObject.ReturnResult("InsertOrUpdateCustomer-SqlException:" + ex.Message, false);
                }
                catch (ArgumentException ex)
                {
                    return ResultObject.ReturnResult("InsertOrUpdateCustomer-ArgumentException:" + ex.Message, false);
                }
                return ResultObject.ReturnResult(mess, true);
            }
        }

        /// <summary>
        /// Thông báo xóa thông tin khách hàng
        /// </summary>
        /// <param name="cc">CustomerClass: CustomerCode</param>
        /// <returns></returns>
        [WebMethod(enableSession: true)]
        public string DeleteCustomer(CustomerClass cc)
        {
            if (string.IsNullOrEmpty(Context.Session["UserName"].ToString()))
                return ResultObject.ReturnResult("Phiên làm việc kết thúc, mời bạn đăng nhập lại", false);
            else
            {
                string mess = "Xóa thông tin khách hàng thất bại. Mời thao tác lại!";
                try
                {
                    if (cc.CustomerDelete(cc) > 0)
                        mess = "Ok";
                }
                catch (SqlException ex)
                {
                    return ResultObject.ReturnResult("DeleteCustomer-SqlException:" + ex.Message, false);
                }
                catch (ArgumentException ex)
                {
                    return ResultObject.ReturnResult("DeleteCustomer-ArgumentException:" + ex.Message, false);
                }
                return ResultObject.ReturnResult(mess, true);
            }
        }
    }
}