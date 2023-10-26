using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Forms;
using BSun.Notes.Core;
using BSun.Notes.Core.Presentation;
using BSun.Notes.FileSystem;

namespace BSun.Notes.WindowsApp
{
   public partial class NotesListForm : Form
   {
      private List<string> _noteFiles;
      private ListBox listBoxNotes;
      private readonly NotesListController _controller;

      public NotesListForm(NotesListController controller)
      {
         // External dependencies.
         _controller = controller;

         // Fields
         _noteFiles = LoadNoteFiles();

         InitializeComponent();
      }

      private void NotesListForm_Load(object sender, EventArgs e)
      {
         listBoxNotes.DisplayMember = nameof(Core.Note.Title);

         _controller.Model.NewNoteClicked += HandleNewNoteClicked;
         _controller.Model.NotesUpdated += (sender2, e2) => PopulateNoteList();

         PopulateNoteList();
      }

      private void HandleNewNoteClicked(object sender, NewNoteEventArgs e)
      {
         var dialog = new NewNoteForm(e.Controller);

         if (dialog.ShowDialog() == DialogResult.OK)
         {
            _noteFiles = LoadNoteFiles();
            PopulateNoteList();
         }
      }
      string notesFolderPath;

      private List<string> LoadNoteFiles()
      {
         string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         notesFolderPath = Path.Combine(desktopPath, "Notes");

         Directory.CreateDirectory(notesFolderPath);

         return new List<string>(Directory.GetFiles(notesFolderPath, "*.txt"));
      }

      private void PopulateNoteList()
      {
         // Erneutes Binden der Datenquelle
         listBoxNotes.DataSource = null;
         listBoxNotes.DataSource = _controller.Model.NotesDataSource;
         listBoxNotes.DisplayMember = nameof(Core.Note.Title); // Setzen Sie den DisplayMember nach der DataSource erneut.
      }

      private void OpenNoteForm(string noteFilePath)
      {
         var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         var notesFolderPath = Path.Combine(desktopPath, "Notes");
         Directory.CreateDirectory(notesFolderPath);

         var repository = new FileSystemRepository(notesFolderPath);
         // FIXME
         var noteModel = new NoteModel(new Note());
         noteModel.Load(noteFilePath);
         // FIXME
         var noteController = new NoteController(noteModel, repository);

         var noteEditForm = new NewNoteForm(noteController);

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
            FileSystemNote Note = (FileSystemNote)listBoxNotes.SelectedItem;
            string selectedNoteFilePath = Note.Path;
            OpenNoteForm(selectedNoteFilePath);
         }
      }

      private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _controller.NewNote();
         //OpenNoteForm(null);
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         if (listBoxNotes.SelectedItem != null)
         {
            FileSystemNote Note = (FileSystemNote)listBoxNotes.SelectedItem;
            string selectedNoteFilePath = Note.Path;
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
         else
         {
            MessageBox.Show("The note file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}
