using System;
using System.IO;
using System.Windows.Forms;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListController
   {
      private readonly NotesListModel _model;
      private readonly IRepository<Note> _repository;
      private string _notesFolderPath;
      public event Action<NoteController> OpenNoteRequested;
      public event Action<NoteController> DeleteNoteRequested;


      public NotesListController(NotesListModel model, IRepository<Note> repository)
      {
         _model = model;
         // Schritt 3 - Auf Ereignis reagieren.
         _model.NeedNotes += HandleNeedNotes;
         _repository = repository;
         InitializeNotesFolderPath();
      }

      private void InitializeNotesFolderPath()
      {
         string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         _notesFolderPath = Path.Combine(desktopPath, "Notes");
         Directory.CreateDirectory(_notesFolderPath);
      }

      // Schritt 3 - Implementierung.
      private void HandleNeedNotes(object sender, NeedNotesEventArgs e)
      {
         e.Notes = _repository.ReadAll();
      }

      public NotesListModel Model => _model;

      //public void LoadNotes(string path) => _model.LoadNotes(path);
      public void LoadNotes()
      {
         _model.LoadNotes(_notesFolderPath);
      }

      public void NewNote()
      {
         var note = new Note();
         var model = new NoteModel(note);
         var controller = new NoteController(model, _repository);

         Model.RaiseNewNoteClicked(controller);
      }
       
      public void DeleteNote(string noteFilePath)
      {
         if (File.Exists(noteFilePath))
         {
            DialogResult result = MessageBox.Show("Do you want to delete this note?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               File.Delete(noteFilePath);
               LoadNotes(); // Refresh the notes list after deletion
            }
         }
         else
         {
            MessageBox.Show("The note file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      public void OpenNote(string noteFilePath)
      {
         var noteModel = new NoteModel(new Note());
         noteModel.Load(noteFilePath);
         var noteController = new NoteController(noteModel, _repository);

         OpenNoteRequested?.Invoke(noteController);
      }
   }
}
