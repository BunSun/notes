using System;

namespace BSun.Notes.Core
{
   public interface INoteModel
   {
      event EventHandler Saved;
      string Title { get; }
      string Text { get; }
   }
}
