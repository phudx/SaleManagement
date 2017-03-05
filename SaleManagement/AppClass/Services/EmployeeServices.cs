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
    public class EmployeeServices : WebService
    {
        public EmployeeServices()
        {
            //TODO
        }

    }
}