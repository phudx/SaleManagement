using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SaleManagement
{
    public class LoginClass
    {
        Hashtable ht = null;
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string Pass { set; get; }
        public int RoleId { set; get; }
        /// <summary>
        /// Hàm mã hóa MD5
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        /// <summary>
        /// Hàm trả về thông tin của người đăng nhập
        /// </summary>
        /// <param name="lc">LoginClass</param>
        /// <returns></returns>
        public DataTable LoginUser(LoginClass lc)
        {
            DataTable dt = new DataTable();
            var data = new ConnectionData();
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hashPass = GetMd5Hash(md5Hash, lc.Pass);
                    ht = new Hashtable();
                    ht.Add("UserName", lc.UserName);
                    ht.Add("Pass", hashPass);
                    dt = data.ExcuteDataTableStore("sp_Login_LoginUser", ht);
                }
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
    }
}