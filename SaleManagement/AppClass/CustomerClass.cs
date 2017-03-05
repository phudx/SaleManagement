using System.Collections;
using System.Data;

namespace SaleManagement
{
    public class CustomerClass
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { set; get; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustomerName { set; get; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// Nhóm địa chỉ ID khách hàng
        /// </summary>
        public int GroupId { set; get; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { set; get; }

        /// <summary>
        /// Tên nhóm địa chỉ khách hàng
        /// </summary>
        public string GroupName { set; get; }

        /// <summary>
        /// Hàm lấy ra bảng dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCustomer()
        {
            DataTable dt = new DataTable();
            var data = new ConnectionData();
            try
            {
                dt = data.ExcuteDataTableStore("sp_Customer_GetAllCustomer");
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
            return dt;
        }

        /// <summary>
        /// Hàm lấy ra Mã khách hàng cho lần insert tiếp theo
        /// </summary>
        /// <returns></returns>
        public string GetCustomerCodeInsert()
        {
            DataTable dt = new DataTable();
            string customerCode = "KH00999";
            var data = new ConnectionData();
            try
            {
                dt = data.ExcuteDataTableStore("sp_Customer_GetCustomerCode");
                customerCode = "KH00" + dt.Rows[0]["STTNext"];
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
            return customerCode;
        }

        /// <summary>
        /// Hàm xóa thông tin khách hàng
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public int CustomerDelete(CustomerClass cc)
        {
            ConnectionData data = null;
            Hashtable ht = null;
            try
            {
                data = new ConnectionData();
                ht = new Hashtable();
                ht.Add("CustomerCode", cc.CustomerCode);
                int result = data.ExcNonQuery("sp_Customer_Delete", ht);
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                data.CloseConnect();//Đóng kết nối
                ht = null;
            }
        }

        /// <summary>
        /// Hàm cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="cc">CustomerClass</param>
        /// <returns></returns>
        public int InsertOrUpdateCustomer(CustomerClass cc)
        {
            ConnectionData data = null;
            Hashtable ht = null;
            try
            {
                data = new ConnectionData();
                ht = new Hashtable();
                ht.Add("CustomerCode", cc.CustomerCode);
                ht.Add("CustomerName", cc.CustomerName);
                ht.Add("Address", cc.Address);
                ht.Add("Phone", cc.Phone);
                ht.Add("GroupId", cc.GroupId);
                ht.Add("Note", cc.Note);
                int result = data.ExcNonQuery("sp_Customer_InsertOrUpdate", ht);
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                data.CloseConnect();//Đóng kết nối
                ht = null;
            }
        }
    }
}