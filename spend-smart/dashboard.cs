﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public partial class dashboard : UserControl
    {
        private OleDbConnection dbConnection;
        public int UserID { get; set; }
        public string Username { get; set; }

        public dashboard()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel7);
            ThemeManage.AddControlToColor(guna2Panel8);
            ThemeManage.AddControlToColor(guna2Panel9);
            ThemeManage.AddControlToColor(guna2Panel11);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label2);
            ThemeManage.AddControlToColor(label4);
            ThemeManage.AddControlToColor(label6);
            ThemeManage.AddControlToColor(totBalancelbl);
            ThemeManage.AddControlToColor(incomelbl);
            ThemeManage.AddControlToColor(explbl);
            ThemeManage.AddControlToColor(savinglbl);

            ThemeManage.AddControlToColor(guna2Panel14);
            ThemeManage.AddControlToColor(guna2Panel15);
            ThemeManage.AddControlToColor(label3);
            ThemeManage.AddControlToColor(label5);

            ThemeManage.AddControlToColor(guna2Panel18);
            ThemeManage.AddControlToColor(guna2Panel19);
            ThemeManage.AddControlToColor(label7);
            ThemeManage.AddControlToColor(label8);
            ThemeManage.AddControlToColor(label9);
            ThemeManage.AddControlToColor(label10);
            ThemeManage.AddControlToColor(label11);
            ThemeManage.AddControlToColor(label12);
            ThemeManage.AddControlToColor(label13);
            ThemeManage.AddControlToColor(label14);
            ThemeManage.AddControlToColor(label15);
            ThemeManage.AddControlToColor(label16);

            this.Load += dashboard_Load;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();

            InitializeDBConnection();

            FetchUserIncomes();
        }

        private void InitializeDBConnection()
        {
            try
            {
                dbConnection = new OleDbConnection(dbConn.Instance.connString);
                dbConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void FetchUserIncomes()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalIncome FROM income WHERE user_id = @UserID";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalIncome = Convert.ToDecimal(result);
                        incomelbl.Text = totalIncome.ToString("C"); // Display as currency
                    }
                    else
                    {
                        incomelbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching income data: " + ex.Message);
                }
            }
        }
    }
}
