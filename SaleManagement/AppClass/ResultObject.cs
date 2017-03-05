using System;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Globalization;

namespace SaleManagement
{
    /// <author>
    /// Bkav Corp. - [EnterpriseTools]
    /// Create Date : [23062016]
    /// Author      : [PhuDX] 
    /// Description : ...
    /// *************************************************
    /// - [Email người sửa] - [yyyyMMdd]: [Lý do sửa ...]
    /// - [Email người sửa] - [yyyyMMdd]: [Lý do sửa...]
    /// </author>
    /// <summary>
    /// Lớp đối tượng kết quả trả về
    /// </summary>
    public class ResultObject
    {
        /// <summary>
        /// <para>Kết quả trả về</para>
        /// <para>value1: [Chú thích ý nghĩa các giá trị nếu có…]</para>
        /// </summary>
        public object Message { get; set; }
        /// <summary>
        /// <para>Trạng thái</para>
        /// <para>value1: True: Không lỗi; False: Lỗi</para>
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// <para>Trạng thái debug</para>
        /// <para>value1: True: Debug; False: Không</para>
        /// </summary>
        public bool Debug { get; set; }

        private bool debug = Convert.ToBoolean(ConfigurationManager.AppSettings["Debug"], CultureInfo.CurrentCulture);

        public ResultObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <author>
        /// PhuDX - [Email người sửa] - [yyyyMMdd]: [Lý do sửa ...]
        /// </author>
        /// <summary>
        /// <para>Khới tạo đối tượng</para>
        /// <para> Email - yyyyMMdd</para>
        /// </summary>
        /// <remarks>
        /// - [Chú thích cặn kẽ để người sử dụng hiểu cách sử dụng và mối tương quan của phương thức này trong hệ thống... Sử dụng thẻ para để xuống dòng nếu có]
        /// </remarks>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <exception cref="InvalidCastException">[Chú thích lỗi...]</exception>
        public ResultObject(object message, bool status)
        {
            try
            {
                this.Message = message;
                this.Debug = debug;
                this.Status = status;
            }
            catch
            {
                throw;
            }
        }

        /// <author>
        /// - [PhuDX] - [20160920]: [Lý do sửa ...]
        /// </author>
        /// <summary>
        /// <para>Chuyển kết quả sang đối tượng trả về sau đó trả về dưới dạng JSON</para>
        /// <para> Email - yyyyMMdd</para>
        /// </summary>
        /// <remarks>
        /// - [Chú thích cặn kẽ để người sử dụng hiểu cách sử dụng và mối tương quan của phương thức này trong hệ thống... Sử dụng thẻ para để xuống dòng nếu có]
        /// </remarks>
        /// <param name="message">Đối tượng trả về</param>
        /// <param name="status">Trạng thái lỗi</param>
        /// <exception cref="InvalidCastException">[Chú thích lỗi...]</exception>
        /// <returns></returns>
        public static string ReturnResult(object message, bool status)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(new ResultObject(message, status));
            }
            catch (ArgumentException ex)
            {
                return new JavaScriptSerializer().Serialize(new ResultObject("ArgumentException in ReturnResult: " + ex.Message, false));
            }
            catch (InvalidOperationException ex)
            {
                return new JavaScriptSerializer().Serialize(new ResultObject("InvalidOperationException in ReturnResult:" + ex.Message, false));
            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer().Serialize(new ResultObject("Exception in ReturnResult:" + ex.Message, false));
            }
        }
    }
}