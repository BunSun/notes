using System;
using System.Collections.Generic;
using System.Text;
using BSun.Notes.Core;

namespace BSun.Notes.Core
{
   public sealed class NoteController
   {
      private NoteModel _model;

      public NoteController(NoteModel model)
      {
         _model = model;
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
         _model.Save();
      }
   }
}
