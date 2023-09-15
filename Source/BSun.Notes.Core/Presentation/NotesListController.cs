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
         // new notecontroller
         // new note model ?
         // trigger event through Model for UI to show new form.
         throw new NotImplementedException();
      }
   }
}
