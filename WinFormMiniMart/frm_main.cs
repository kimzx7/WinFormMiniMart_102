﻿using Microsoft.Data.SqlClient;
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
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
        }
        //------------property------------

        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string status { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (status == "insert")
            {
                insertCategory();
            }
            else if (status == "update")
            {
                UpdateCategory();
            }
        }

        private void UpdateCategory()
        {


            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
                return;
            }
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("ชื่อประเภทสินค้าต้องว่าง");
                return;
            }

            string sql = "Update Categories set CategoryName = @categroyName, Description = @Description where CategoryID = @categoryID";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@categoryID", txtCategoryID.Text.Trim());
            cmd.Parameters.AddWithValue("@categroyName", txtCategoryName.Text.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            cmd.ExecuteNonQuery();
            this.Close();



        }

        private void insertCategory()
        {



            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("ชื่อประเภทสินค้าต้องว่าง");
                return;
            }

            string sql = "Insert into Categories values (@categroyName,@Description)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@categroyName", txtCategoryName.Text.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            cmd.ExecuteNonQuery();
            this.Close();

        }

        SqlConnection conn;
        SqlDataAdapter da;
        SqlCommand cmd;
        private void frm_main_Load(object sender, EventArgs e)
        {
            conn = connDB.ConnectMinimart();
            txtCategoryID.Text = categoryID.ToString();
            txtCategoryName.Text = categoryName;
            txtDescription.Text = description;
            this.Text += "(" + status + ")";
            txtCategoryName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
