using System;
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

            notesDataGrid.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            notesDataGrid.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            notesDataGrid.Columns["Note"].DefaultCellStyle.Font = new Font("Microsoft Sans Serif ", 10);
            notesDataGrid.Columns["Subject"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            notesDataGrid.Columns["Subject"].DefaultCellStyle.Font = new Font("Microsoft Sans Serif ", 10);
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

        private void notesDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (notesDataGrid.Columns[e.ColumnIndex].Name == "Note")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString().Replace("\n", Environment.NewLine);
                    e.FormattingApplied = true;
                }
            }
        }

        private void notesDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    dataGridView.RowHeadersWidth - 4,
                    e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                    dataGridView.RowHeadersDefaultCellStyle.Font,
                    rectangle,
                    dataGridView.RowHeadersDefaultCellStyle.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int noteId;
            if (!int.TryParse(noteIdTxt.Text, out noteId))
            {
                MessageBox.Show("Please enter a valid Note ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string subject = subjectTxt.Text;
            string note = noteTxt.Text;

            if (subject == "" || note == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (subject.Length > 20)
            {
                MessageBox.Show("Subject is too long. Maximum 20 characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (note.Length > 50)
            {
                MessageBox.Show("Note is too long. Maximum 50 characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            try
            {
                using (OleDbCommand command = new OleDbCommand("UPDATE notes SET user_subject = @subject, user_note = @note WHERE note_id = @noteId AND user_id = @currentID", dbConnection))
                {
                    command.Parameters.AddWithValue("@subject", subject);
                    command.Parameters.AddWithValue("@note", note);
                    command.Parameters.AddWithValue("@noteId", noteId);
                    command.Parameters.AddWithValue("@currentID", currentID);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Note updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FetchNoteRecords();
                        noteIdTxt.Text = "";
                        subjectTxt.Text = "";
                        noteTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Failed to update note.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error updating note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            int noteId;
            if (!int.TryParse(noteIdTxt.Text, out noteId))
            {
                MessageBox.Show("Please enter a valid Note ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            try
            {
                using (OleDbCommand command = new OleDbCommand("DELETE FROM notes WHERE note_id = @noteId AND user_id = @currentID", dbConnection))
                {
                    command.Parameters.AddWithValue("@noteId", noteId);
                    command.Parameters.AddWithValue("@currentID", currentID);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Note deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FetchNoteRecords();
                        noteIdTxt.Text = "";
                        subjectTxt.Text = "";
                        noteTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete note.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error deleting note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
