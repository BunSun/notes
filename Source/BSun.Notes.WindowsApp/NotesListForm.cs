using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Forms;
using BSun.Notes.Core;

namespace BSun.Notes.WindowsApp
{
   public partial class NotesListForm : Form
   {
      private List<string> _noteFiles;
      private ListBox listBoxNotes;

      public NotesListForm()
      {
         InitializeComponent();
         _noteFiles = LoadNoteFiles();
         PopulateNoteList();
      }

      private List<string> LoadNoteFiles()
      {
         string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         string notesFolderPath = Path.Combine(desktopPath, "Notes");

         Directory.CreateDirectory(notesFolderPath);

         return new List<string>(Directory.GetFiles(notesFolderPath, "*.txt"));
      }

      private void PopulateNoteList()
      {
         listBoxNotes.DataSource = null;
         listBoxNotes.DataSource = _noteFiles;
      }

      private void OpenNoteForm(string noteFilePath)
      {
         var noteModel = new NoteModel();
         noteModel.Load(noteFilePath);
         var noteController = new NoteController(noteModel);

         var noteEditForm = new MainForm(noteController);

         noteEditForm.FormClosed += (sender, e) =>
         {
            if (noteEditForm.DialogResult == DialogResult.OK)
            {
               _noteFiles = LoadNoteFiles();
               PopulateNoteList();
            }
         };

         // Fülle den Titel und Text im Bearbeitungsfenster
         noteEditForm.PrepopulateNoteFields(noteModel.Title, noteModel.Text);

         noteEditForm.ShowDialog();
      }


      private void openNoteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (listBoxNotes.SelectedItem != null)
         {
            string selectedNoteFilePath = listBoxNotes.SelectedItem.ToString();
            OpenNoteForm(selectedNoteFilePath);
         }
      }

      private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenNoteForm(null);
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         if (listBoxNotes.SelectedItem != null)
         {
            string selectedNoteFilePath = listBoxNotes.SelectedItem.ToString();
            DeleteNote(selectedNoteFilePath);
         }
      }
      private void DeleteNote(string noteFilePath)
      {
         if (File.Exists(noteFilePath))
         {
            DialogResult result = MessageBox.Show("Do you want to delete this note?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               File.Delete(noteFilePath);
               _noteFiles.Remove(noteFilePath);
               PopulateNoteList();
            }
         }
      }
   }
}
