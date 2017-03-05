using System;

namespace SaleManagement
{
    public class EmployeeClass
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { set; get; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { set; get; }

        /// <summary>
        /// Chức vụ
        /// </summary>
        public string Position { set; get; }

        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime BirthDate { set; get; }

        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        public bool Sex { set; get; }

        /// <summary>
        /// ID nhân viên
        /// </summary>
        public int UserId { set; get; }
    }
}