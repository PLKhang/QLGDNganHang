using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLGDNganHang;
using System.Data;
using System.Data.SqlClient;

namespace QLGDNganHang
{
    static class Program
    {
        public static SqlConnection connection = new SqlConnection();
        public static string connectionString = "";
        public static string publisherConnection = "Data Source=KHANG;Initial Catalog=NGANHANG;User ID=sa;Password=abc;TrustServerCertificate=True";

        public static SqlDataReader sqlDataReader = null;
        
        //Infomation of cuurent logined user
        public static string mLoginName = "";
        public static string mUsername = "";
        public static string mPassword = "";
        public static string mRole = "";
        public static string mName = "";

        public static string serverName = "";
        public static string databaseName = "";
        public static string remoteLogin = "HTKN";
        public static string remotePassword = "123456";

        public static BindingSource bds = new BindingSource();

        public static int Connect()
        {
            if (connection != null && connection.State != ConnectionState.Open)
            {
                connection.Close();
            }
            try
            {
                connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";User ID=" + mLoginName + ";Password=" + mPassword;
                connection.ConnectionString = connectionString;
                connection.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối!\nServer: {serverName}\nDatabase: {databaseName}\nLogin name: {mLoginName}\n" + ex.Message, "Không thể kết nối", MessageBoxButtons.OK);
                return 0;
            }
        }
        public static void Login(string svName, string dbName,string mLoginName, string mUsername, string mPassword, string mRole)
        {
            Program.serverName = svName;
            Program.databaseName = dbName;
            Program.mUsername = mLoginName;
            Program.mLoginName = mUsername;
            Program.mPassword = mPassword;
            Program.mRole = mRole;
        }

        public static void Logout()
        {
            Program.serverName = "";
            Program.databaseName = "";
            Program.mUsername = "";
            Program.mLoginName = "";
            Program.mPassword = "";
            Program.mRole = "";
        }
        public static DataTable ExecStoredProcedureReturnTable(string command)
        {
            DataTable dt = new DataTable();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(command, connection);    
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("text\n" + ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OKCancel);
            }
            connection.Close();
            return dt;
        }
        public static int ExecStoredProcedureReturnInt(string spName, params SqlParameter[] parameters)
        {
            int result = -1;
            SqlCommand command = new SqlCommand(spName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 300;

            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(returnValue);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {
                command.ExecuteNonQuery();
                return (int)returnValue.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("text\n" + ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OKCancel);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static string ExecStoredProcedureReturnString(string command)
        {
            string result = "";
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            sqlCommand.CommandType = CommandType.Text;
                
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result = reader.GetString(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("text\n" + ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OKCancel);
            }
            connection.Close();
            return result;
        }
        public static int CreateLoginToSystem(string loginName, string username, string password, string role)
        {
            int result = 0;
            result = Program.ExecStoredProcedureReturnInt("sp_TaoLogin",
                                                       new SqlParameter("@LGNAME", loginName),
                                                       new SqlParameter("@PASS", password),
                                                       new SqlParameter("@USERNAME", username),
                                                       new SqlParameter("@ROLE", role));
            return result;
        }
        public static int DeleteLoginFromSystem(string username)
        {
            int result = 0;
            result = Program.ExecStoredProcedureReturnInt("sp_XoaLogin", new SqlParameter("@USRNAME", username));
            return result;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
