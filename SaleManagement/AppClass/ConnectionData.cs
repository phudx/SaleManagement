using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace SaleManagement
{
    /// <author>
    /// Bkav Corp. - [BPTHT]
    /// Project: []
    /// Create Date : []
    /// Author      : [LongLTb] 
    /// Description : ...
    /// ************************************************* 
    /// - [Email người sửa] - [yyyyMMdd]: [Lý do sửa ...]
    /// - [Email người sửa] - [yyyyMMdd]: [Lý do sửa...]
    /// </author>
    /// <summary>
    /// Lớp kết nối cơ sở dữ liệu
    /// </summary>
    public class ConnectionData
    {
        public static string strConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        /// <summary>
        /// <para>[Biến chứa chuỗi kết nối]</para>
        /// </summary>
        SqlConnection conn;

        /// <authors> 
        /// [longltb@bkav.com] - [2014-05-15]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Contructor lấy chuỗi kết nối từ file config
        /// </summary>
        /// <remarks>
        /// </remarks>     
        /// <exception cref="ConfigurationErrorsException">ConfigurationErrorsException</exception>        
        /// <returns>
        /// </returns>
        public ConnectionData()
        {
            try
            {
                conn = new SqlConnection(strConnect);
            }
            catch
            {
                throw;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Mở kết nối
        /// </summary>
        /// <remarks>
        /// </remarks>    
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <returns>  
        /// void
        /// </returns>
        public void OpenConnect()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Đóng kết nối
        /// </summary>
        /// <remarks>
        /// </remarks>      
        /// <returns>  
        /// <exception cref="SqlException">SqlException</exception>
        /// void
        /// </returns>
        public void CloseConnect()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Dispose();
            }
        }

        /// <authors> 
        /// - [LongLTbp@kav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Tạo SqlCommand cho store có tham số
        /// </summary>
        /// <remarks>
        /// </remarks>     
        /// <param name="hstbl">Bảng băm tham số</param>
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// SqlCommand
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private SqlCommand CreateSqlCommand(string storeName, Hashtable ht)
        {
            using (SqlCommand scmCmdToExecute = new SqlCommand())
            {
                scmCmdToExecute.Connection = conn;
                scmCmdToExecute.CommandType = CommandType.StoredProcedure;
                scmCmdToExecute.CommandText = storeName;
                foreach (DictionaryEntry Item in ht)
                {
                    scmCmdToExecute.Parameters.AddWithValue("@" + Item.Key.ToString(), (Item.Value == null) ? System.DBNull.Value : Item.Value);
                }
                scmCmdToExecute.CommandTimeout = 60;
                return scmCmdToExecute;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Tạo SqlCommand cho lệnh T-SQL
        /// </summary>
        /// <remarks>
        /// </remarks>   
        /// <param name="sql">Lệnh T-SQL</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <returns>  
        /// SqlCommand
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private SqlCommand CreateSqlCommandSQL(string sql)
        {
            using (SqlCommand scmCmdToExecute = new SqlCommand())
            {
                scmCmdToExecute.Connection = conn;
                scmCmdToExecute.CommandText = sql;
                //scmCmdToExecute.CommandTimeout = 10000;
                return scmCmdToExecute;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Tạo SqlCommand cho store không tham số
        /// </summary>
        /// <remarks>
        /// </remarks>        
        /// <param name="storeName">Tên store</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <returns>  
        /// SqlCommand
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private SqlCommand CreateSqlCommand(string storeName)
        {
            using (SqlCommand scmCmdToExecute = new SqlCommand())
            {
                scmCmdToExecute.Connection = conn;
                scmCmdToExecute.CommandType = CommandType.StoredProcedure;
                scmCmdToExecute.CommandText = storeName;
                scmCmdToExecute.CommandTimeout = 60;
                return scmCmdToExecute;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy đối tượng trả về bởi store có tham số
        /// </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="hstbl">Bảng băm tham số</param>
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// Object
        /// </returns>
        public object ExcScalar(string storeName, Hashtable htbl)
        {
            try
            {
                this.OpenConnect();
                SqlCommand cmd = CreateSqlCommand(storeName, htbl);
                return cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy đối tượng trả về bởi store không tham số
        /// </summary>
        /// <remarks>
        /// </remarks>       
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// Object
        /// </returns>
        public object ExcScalar(string storeName)
        {
            object obj;
            try
            {
                this.OpenConnect();
                SqlCommand cmd = CreateSqlCommand(storeName);
                obj = cmd.ExecuteScalar();
                this.CloseConnect();
            }
            catch
            {
                this.CloseConnect();
                throw;
            }
            return obj;
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy đối tượng trả về bởi T-SQL
        /// </summary>
        /// <remarks>
        /// </remarks>  
        /// <param name="sql">Lệnh T-SQL</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// Object
        /// </returns>
        public object ExcScalarSql(string sql)
        {
            object obj;
            try
            {
                this.OpenConnect();
                SqlCommand cmd = CreateSqlCommandSQL(sql);
                obj = cmd.ExecuteScalar();
                this.CloseConnect();
            }
            catch
            {
                this.CloseConnect();
                throw;
            }
            return obj;
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về đối tượng datareader từ store co tham số
        /// </summary>
        /// <remarks>
        /// </remarks>      
        /// <param name="hstbl">Bảng băm tham số</param>
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// SqlDataReader
        /// </returns>
        public SqlDataReader ExcuteDataReader(string storeName, Hashtable hstbl)
        {
            SqlDataReader idr;
            try
            {
                this.CloseConnect();
                this.OpenConnect();
                SqlCommand mycommand = CreateSqlCommand(storeName, hstbl);
                idr = mycommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return idr;
            }
            catch
            {
                this.CloseConnect();
                throw;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về đối tượng datareader từ store không tham số
        /// </summary>
        /// <remarks>
        /// </remarks>          
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// SqlDataReader
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Excute")]
        public SqlDataReader ExcuteDataReader(string storeName)
        {
            SqlDataReader Idr;
            try
            {
                this.CloseConnect();
                this.OpenConnect();
                SqlCommand mycommand = CreateSqlCommand(storeName);
                mycommand.CommandType = CommandType.StoredProcedure;
                Idr = mycommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return Idr;
            }
            catch
            {
                this.CloseConnect();
                throw;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về đối tượng datareader từ lệnh T-SQL
        /// </summary>
        /// <remarks>
        /// </remarks>    
        /// <param name="sql">Lệnh T-SQL</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// SqlDataReader
        /// </returns>
        public SqlDataReader ExcuteDataReaderSql(string sql)
        {
            SqlDataReader Idr;
            try
            {
                this.CloseConnect();
                this.OpenConnect();
                SqlCommand mycommand = CreateSqlCommandSQL(sql);
                Idr = mycommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return Idr;
            }
            catch
            {
                this.CloseConnect();
                throw;
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về 1 dataset từ lệnh t-SQL
        /// </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="sql">Lệnh T-SQL</param>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// DataSet
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataSet ExcuteDatasetSql(string sql)
        {
            using (DataSet ds = new DataSet())
            {
                ds.Locale = CultureInfo.InvariantCulture;
                try
                {
                    using (SqlDataAdapter mda = new SqlDataAdapter())
                    {
                        mda.SelectCommand = new SqlCommand(sql, conn);
                        mda.Fill(ds);
                        this.CloseConnect();
                        return ds;
                    }
                }
                catch
                {
                    this.CloseConnect();
                    throw;
                }
                finally
                {
                    this.CloseConnect();
                }
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về 1 dataset từ store không tham số
        /// </summary>
        /// <remarks>
        /// </remarks>      
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>        
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// DataSet
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataSet ExcuteDatasetStore(string storeName)
        {
            using (DataSet ds = new DataSet())
            {
                ds.Locale = CultureInfo.InvariantCulture;
                try
                {
                    using (SqlDataAdapter mda = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(storeName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            mda.SelectCommand = cmd;
                            mda.Fill(ds);
                            this.CloseConnect();
                            return ds;
                        }
                    }
                }
                catch
                {
                    this.CloseConnect();
                    throw;
                }
                finally
                {
                    this.CloseConnect();
                }
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về 1 dataset từ store có tham số
        /// </summary>
        /// <remarks>
        /// </remarks>  
        /// <param name="hstbl">Bảng băm tham số</param>
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>        
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// DataSet
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataSet ExcuteDatasetStore(string storeName, Hashtable htbl)
        {
            using (DataSet ds = new DataSet())
            {
                ds.Locale = CultureInfo.InvariantCulture;
                try
                {
                    using (SqlDataAdapter mda = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(storeName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (htbl != null)
                            {
                                foreach (DictionaryEntry Item in htbl)
                                {
                                    cmd.Parameters.AddWithValue("@" + Item.Key.ToString(), (Item.Value == null) ? System.DBNull.Value : Item.Value);
                                }
                            }
                            mda.SelectCommand = cmd;
                            mda.Fill(ds);
                            this.CloseConnect();
                            return ds;
                        }
                    }
                }
                catch
                {
                    this.CloseConnect();
                    throw;
                }
                finally
                {
                    this.CloseConnect();
                }
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về 1 datatable từ store không tham số
        /// </summary>
        /// <remarks>
        /// </remarks>         
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// DataTable
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataTable ExcuteDataTableStore(string storeName)
        {
            using (DataTable dt = new DataTable())
            {
                dt.Locale = CultureInfo.InvariantCulture;
                try
                {
                    using (SqlDataAdapter mda = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(storeName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            mda.SelectCommand = cmd;
                            mda.Fill(dt);
                            this.CloseConnect();
                            return dt;
                        }
                    }
                }
                catch
                {
                    this.CloseConnect();
                    throw;
                }
                finally
                {
                    this.CloseConnect();
                }
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về 1 datatable từ store có tham số
        /// </summary>
        /// <remarks>
        /// </remarks>   
        /// <param name="hstbl">Bảng băm tham số</param>
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// DataTable
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataTable ExcuteDataTableStore(string storeName, Hashtable htbl)
        {
            using (DataTable dt = new DataTable())
            {
                dt.Locale = CultureInfo.InvariantCulture;
                try
                {
                    using (SqlDataAdapter mda = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(storeName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (htbl != null)
                            {
                                foreach (DictionaryEntry Item in htbl)
                                {
                                    cmd.Parameters.AddWithValue("@" + Item.Key.ToString(), (Item.Value == null) ? System.DBNull.Value : Item.Value);
                                }
                            }
                            this.OpenConnect();
                            mda.SelectCommand = cmd;
                            mda.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    this.CloseConnect();
                }
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Lấy về 1 datatable từ lệnh T-SQL
        /// </summary>
        /// <remarks>
        /// </remarks>     
        /// <param name="sql">Lệnh T-SQL</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// DataTable
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataTable ExcuteDatatableSQL(string sql)
        {
            using (DataTable dt = new DataTable())
            {
                dt.Locale = CultureInfo.InvariantCulture;
                try
                {
                    using (SqlDataAdapter mda = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            mda.SelectCommand = cmd;
                            mda.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    this.CloseConnect();
                }
            }
        }

        /// <authors> 
        /// - [LongLtb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Thực thi store có tham số
        /// </summary>
        /// <remarks>
        /// </remarks>  
        /// <param name="hstbl">Bảng băm tham số</param>
        /// <param name="storeName">Tên store</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// Số bản ghi bị tác động
        /// </returns>
        public int ExcNonQuery(string storeName, Hashtable hstbl)
        {
            try
            {
                this.OpenConnect();
                SqlCommand mycommand = CreateSqlCommand(storeName, hstbl);
                return mycommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        /// <authors> 
        /// - [LongLTb@bkav.com] - [2014--]: [Tạo mới]
        /// </authors> 
        /// <summary>
        /// Thực thi lệnh T-SQL
        /// </summary>
        /// <remarks>
        /// </remarks>      
        /// <param name="sql">Lệnh T-SQL</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <exception cref="SqlException">SqlException</exception>
        /// <returns>  
        /// Số bản ghi bị tác động
        /// </returns>
        public int ExcNonQuery(string sql)
        {
            int i = -1;
            try
            {
                this.OpenConnect();
                SqlCommand mycommand = CreateSqlCommandSQL(sql);
                i = mycommand.ExecuteNonQuery();
                this.CloseConnect();
            }
            catch
            {
                this.CloseConnect();
                throw;
            }
            finally
            {
                this.CloseConnect();
            }
            return i;
        }
    }
}