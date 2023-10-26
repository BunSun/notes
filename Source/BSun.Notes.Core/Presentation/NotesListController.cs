using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListController
   {
      private readonly NotesListModel _model;
      private readonly IRepository<Note> _repository;

      public NotesListController(NotesListModel model, IRepository<Note> repository)
      {
         _model = model;
         // Schritt 3 - Auf Ereignis reagieren.
         _model.NeedNotes += HandleNeedNotes;
         _repository = repository;
      }

      // Schritt 3 - Implementierung.
      private void HandleNeedNotes(object sender, NeedNotesEventArgs e)
      {
         e.Notes = _repository.ReadAll();
      }

      public NotesListModel Model => _model;

      public void LoadNotes(string path) => _model.LoadNotes(path);
      public void DeleteNotes(string path) => _model.DeleteNotes(path);

      public void NewNote()
      {
         var note = new Note();
         var model = new NoteModel(note);
         var controller = new NoteController(model, _repository);

         Model.RaiseNewNoteClicked(controller);
      }

   }
}
