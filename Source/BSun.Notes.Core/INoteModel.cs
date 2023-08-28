using System;

namespace BSun.Notes.Core
{
   public interface INoteModel
   {
      event EventHandler TextChanged;
      event EventHandler TitleChanged;
      event EventHandler Saved;

      string Text { get; }

      string Title { get; }
   }
}
