using System;
using System.Collections;
using System.Data;

namespace SaleManagement
{
    public class ProductClass
    {
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public string ProductCode { set; get; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { set; get; }

        /// <summary>
        /// Id của loại sản phẩm
        /// </summary>
        public int CategoryId { set; get; }

        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        public string ProviderCode { set; get; }

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public string Unit { set; get; }

        /// <summary>
        /// Nhà sản xuất
        /// </summary>
        public string Producer { set; get; }

        /// <summary>
        /// Hạn sử dụng sản phẩm
        /// </summary>
        public DateTime Expiry { set; get; }

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public int Price { set; get; }

        /// <summary>
        /// Số lượng sản phẩm còn trong kho
        /// </summary>
        public int Number { set; get; }

        /// <summary>
        /// Trạng thái Sản phẩm
        /// </summary>
        public bool Status { set; get; }

        /// <summary>
        /// Hàm xử lý lấy dữ liệu hiển thị cho bảng sản phẩm
        /// </summary>
        /// <param name="pc"> Đối tượng sản phẩm</param>
        /// <returns></returns>
        public DataTable GetAllProduct(ProductClass pc)
        {
            DataTable dt = new DataTable();
            ConnectionData data = new ConnectionData();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("ProductName", pc.ProductName);
                ht.Add("CategoryId", pc.CategoryId);
                dt = data.ExcuteDataTableStore("sp_Product_GetAllProduct", ht);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                ht = null;
            }
        }
        /// <summary>
        /// Hàm thực hiện chức năng xóa Sản phẩm
        /// </summary>
        /// <param name="pc">Đối tượng Sản phẩm</param>
        /// <returns>[Số bản ghi bị xóa]</returns>
        public int Delete(ProductClass pc)
        {
            ConnectionData data = new ConnectionData();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("ProductCode", pc.ProductCode);
                int result = data.ExcNonQuery("sp_Product_Delete", ht);//số bản ghi trong CSDL bị tác động
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                ht = null;
            }
        }
    }
}