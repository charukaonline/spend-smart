﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace spend_smart
{
    public partial class noteForm : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;
        public noteForm()
        {
            InitializeComponent();
            SubscribeToAddNoteEvent();

            //ThemeManage.AddControlToColor(guna2Panel2);
            //ThemeManage.AddControlToColor(label1);

            //this.Load += noteForm_Load;
        }

        private void OnNoteAdded(object sender, EventArgs e)
        {
            // Refresh the DataGridView
            FetchNoteRecords();
        }

        public void SubscribeToAddNoteEvent()
        {
            dashboard note = new dashboard();
            note.NoteAdded += OnNoteAdded;
        }

        private void noteForm_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
            InitializeDBConnection();
            FetchNoteRecords();

            currentID = UserSession.CurrentUserID;
        }

        private void InitializeDBConnection()
        {
            try
            {
                if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                {
                    dbConnection = new OleDbConnection(dbConn.Instance.connString);
                    dbConnection.Open();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshData()
        {
            // Refresh the DataGridView
            FetchNoteRecords();
        }

        private void FetchNoteRecords()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT note_id AS [Note ID], user_subject AS [Subject], user_note AS [Note], created_on AS [Added Date] FROM notes WHERE user_id = @currentID";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    da.Fill(dt);

                    notesDataGrid.DataSource = dt;
                }
                catch(OleDbException ex)
                {
                    MessageBox.Show("Error fetching notes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
