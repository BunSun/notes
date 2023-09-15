using System;
using System.Collections.Generic;
using System.Text;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListController
   {
      private readonly NotesListModel _model;
      private readonly IRepository<Note> _repository;

      public NotesListController(NotesListModel model, IRepository<Note> repository)
      {
         _model = model;
         _repository = repository;
      }

      public NotesListModel Model => _model;

      public void LoadNotes(string path) => _model.LoadNotes(path);

      public void NewNote()
      {
         var note = new Note();
         var model = new NoteModel(note);
         var controller = new NoteController(model, _repository);

         Model.RaiseNewNoteClicked(controller);
      }
   }
}
