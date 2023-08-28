using System;
using System.Collections.Generic;
using System.Text;
using BSun.Notes.Core;

namespace BSun.Notes.Core
{
   public sealed class NoteController
   {
      private readonly IRepository<Note> _repository;
      private readonly NoteModel _model;

      public NoteController(NoteModel model, IRepository<Note> repository)
      {
         _model = model;
         _repository = repository;
      }

      public INoteModel Model { get { return _model; } }

      public void ChangeText(string text)
      {
         _model.Text = text;
      }

      public void ChangeTitle(string title)
      {
         _model.Title = title;
      }

      public void SaveNote()
      {
         var succeeded = _repository.Write(_model.Note);
         if (!succeeded)
         {
            // TODO Trigger model?
         }
      }
   }
}
