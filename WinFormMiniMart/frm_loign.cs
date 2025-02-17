using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMiniMart
{
    public partial class frm_loign : Form
    {
        public frm_loign()
        {
            InitializeComponent();
        }


        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public string Position { get; set; }
        public string UserName { get; set; }

        SqlConnection conn;
        SqlDataAdapter da;
        SqlCommand cmd;

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_loign_Load(object sender, EventArgs e)
        {
            conn = connDB.ConnectMinimart();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmployeeID = 0;
            EmpName = string.Empty;
            Position = string.Empty;
            UserName = string.Empty;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "select EmployeeID , EmpName = Title + FirstName + '  ' + LastName,Position , UserName from Employees where UserName = @username and Password = @password";
            cmd = new SqlCommand(sql,conn);
            cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            da = new SqlDataAdapter (cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count == 1)
            {
                EmployeeID = Convert.ToInt16(ds.Tables[0].Rows[0]["EmployeeID"]);
                EmpName = ds.Tables[0].Rows[0]["EmpName"].ToString();
                Position = ds.Tables[0].Rows[0]["Position"].ToString();
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                MessageBox.Show(EmployeeID+Environment.NewLine+EmpName + Environment.NewLine+Position,"ยินดีตอนรับ");
            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง", "เกิดข้อผิดพลาด");
                //txtUserName.Text = string.Empty;
                //txtPassword.Text = string.Empty;
                //txtUserName.Focus();
                //
                EmployeeID = 0;
                EmpName = string.Empty;
                Position = string.Empty;
                UserName = string.Empty;
            }
            this.Close();
        }
    }
}
