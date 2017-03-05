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
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProductServices : WebService
    {
        public ProductServices()
        {
            //TODO
        }

        /// <author>
        /// PhuDX - [Email người sửa] - [2016-30-09]
        /// </author>
        /// <summary>
        /// Load toàn bộ dữ liệu thông tin khách hàng
        /// </summary>
        /// <returns></returns>
        [WebMethod(enableSession: true)]
        public string GetAllProduct(ProductClass pc)
        {
            DataTable dt = new DataTable();
            try
            {
                using (dt = pc.GetAllProduct(pc))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        StringBuilder htmlText = new StringBuilder();
                        htmlText.AppendLine("<table width='100%' class='table table-striped table-bordered table-hover' id='dataTables-example'>");
                        htmlText.AppendLine("<thead><tr>");
                        htmlText.AppendLine(
                           "<th>Mã sản phẩm</th>" +
                           "<th>Tên sản phẩm</th>" +
                           "<th>Nhà cung cấp</th>" +
                           "<th>Loại</th>" +
                           "<th>Đơn vị</th>" +
                           "<th>Nhà sản xuất</th>" +
                           "<th>Hạn sử dụng</th>" +
                           "<th>Giá</th>" +
                           "<th>Số lượng</th>" +
                           "<th>Chức năng</th>");
                        htmlText.AppendLine("</tr></thead>");
                        htmlText.AppendLine("<tbody>");
                        foreach (DataRow dr in dt.Rows)//dt.Rows: Các đối tượng row trong DataTable
                        {
                            string btnSua = "<img src='../Images/edit.png'  title='Sửa thông tin' />";
                            string btnXoa = "<a data-toggle='modal' data-target='#Delete' href=\"javascript:void(0)\" style=\"text-decoration: none;\"><img src=\"../Images/delete.png\"  id=\"imgXoa\"   class=\"imgbtn\" title=\"Xóa sản phẩm\"     alt=\"Delete\" onclick=\"Delete('" + dr["ProductCode"] + "','" + dr["ProductName"] + "')\" /></a>";
                            htmlText.AppendLine("<tr>");
                            htmlText.AppendLine("<td>" + dr["ProductCode"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["ProductName"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["ProviderName"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["CategoryName"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Unit"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Producer"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Expiry"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Price"] + "</td>");
                            htmlText.AppendLine("<td>" + dr["Number"] + "</td>");
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
                return ResultObject.ReturnResult("GetAllProduct-SqlException:" + ex.Message, false);
            }
            catch (ArgumentException ex)
            {
                return ResultObject.ReturnResult("GetAllProduct-ArgumentException:" + ex.Message, false);
            }
        }
        /// <summary>
        /// Chuối thông báo xóa sản phẩm
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        [WebMethod]
        public string Delete(ProductClass pc)
        {
            string mess = "Xóa thông tin sản phẩm thất bại. Mời thao tác lại!";
            try
            {
                if (pc.Delete(pc) > 0)//Xóa thành công
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