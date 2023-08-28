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
         Console.WriteLine("Model title set to: " + _model.Title);
      }

      public void SaveNote()
      {
         Console.WriteLine("SaveNote method called in NoteController");
         _model.Save();
      }
   }
}
