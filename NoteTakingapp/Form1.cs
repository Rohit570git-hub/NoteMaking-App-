using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingapp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Notes");

            PreviousNote.DataSource= notes;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PreviousNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (PreviousNote.CurrentCell != null)
            {
                titleBox.Text = notes.Rows[PreviousNote.CurrentCell.RowIndex].ItemArray[0].ToString();
                noteBox.Text = notes.Rows[PreviousNote.CurrentCell.RowIndex].ItemArray[1].ToString();
                editing = true;
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[PreviousNote.CurrentCell.RowIndex].Delete();
            }catch(Exception ex) { Console.WriteLine(ex.Message+" --Not a valid Note"); }
        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[PreviousNote.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[PreviousNote.CurrentCell.RowIndex]["Note"] = noteBox.Text;

            }
            else
            {
                notes.Rows.Add(titleBox.Text,noteBox.Text);

            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing= false;
        }

        private void PreviousNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[PreviousNote.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[PreviousNote.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;

        }
    }
}
