using System;

namespace BSun.Notes.Core.Presentation
{
   public sealed class NewNoteEventArgs : EventArgs
   {
      public NewNoteEventArgs(NoteController controller)
      {
         Controller = controller;
      }

      public NoteController Controller { get; }
   }
}
