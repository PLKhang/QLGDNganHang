using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLGDNganHang;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using DevExpress.XtraReports.UI;

namespace QLGDNganHang
{
    static class Program
    {
        public static frmMain main;

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

        public static int currentBranch = 0;
        public static string serverName = "";
        public static string databaseName = "NGANHANG";
        public static string remoteLogin = "HTKN";
        public static string remotePassword = "123456";

        public static BindingSource bds = new BindingSource();

        public static int Connect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            try
            {
                connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";User ID=" + mLoginName + ";Password=" + mPassword;
                connection.ConnectionString = connectionString;
                Debug.WriteLine($"connection string: {connectionString}");
                connection.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối! Kiểm tra lại Username và Password\nServer: {serverName}\nDatabase: {databaseName}\nLogin name: {mLoginName}\nPassword: {mPassword}\n" + ex.Message, "Không thể kết nối", MessageBoxButtons.OK);
                //MessageBox.Show($"Connection string: {connection.ConnectionString}\n" + ex.Message, "Không thể kết nối", MessageBoxButtons.OK);
                return 0;
            }
        }
        public static void SelectBranchs()
        {
            if(connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }

            connection.ConnectionString = publisherConnection;
            connection.Open();
            DataTable dt = ExecStoredProcedureReturnTable("SELECT * FROM V_DS_PHANMANH");
            connection.Close();
            bds.DataSource = dt;
        }
        public static void Login(string mLoginName, string mUsername, string mName, string mRole)
        {
            Program.mLoginName = mLoginName;
            Program.mUsername = mUsername;
            Program.mName = mName;
            Program.mRole = mRole;
        }

        public static void Logout()
        {
            Program.serverName = "";
            Program.mLoginName = "";
            Program.mUsername = "";
            Program.mPassword = "";
            Program.mName = "";
            Program.mRole = "";

            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public static SqlDataReader ExecStoredProcedureReturnDataReader(string command)
        {
            SqlDataReader r = null;
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.CommandType = CommandType.Text;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                r = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("text\n" + ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OKCancel);
            }
            return r;
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
            finally
            {
                connection.Close();
            }
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
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
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
        public static bool ValidateKeyPress(char e)
        {
            if (!(char.IsDigit(e) || char.IsControl(e) || (char.IsLetter(e) && ((e >= 'A' && e <= 'Z') || (e >= 'a' && e <= 'z')))))
            {
                MessageBox.Show("Only letters and numbers are allowed.");
                return false;
            }
            return true;
        }

        public static void ExportReport(XtraReport report, string format)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (format == "PDF")
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                }
                else if (format == "Excel")
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                }

                // Hiển thị SaveFileDialog và kiểm tra nếu người dùng đã chọn vị trí và tên file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (format == "PDF")
                        {
                            report.ExportToPdf(saveFileDialog.FileName);
                            MessageBox.Show("Report exported to PDF successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (format == "Excel")
                        {
                            report.ExportToXlsx(saveFileDialog.FileName);
                            MessageBox.Show("Report exported to Excel successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SelectBranchs();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new frmMain();
            Application.Run(main);
        }
    }
}
