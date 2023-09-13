using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListModel
   {
      public event EventHandler NotesUpdated;

      public List<string> NoteFiles { get; private set; }

      public NotesListModel() => NoteFiles = new List<string>();

      public void LoadNotes(string path)
      {
         NoteFiles = new List<string>(Directory.GetFiles(path, "*.txt"));
         NotesUpdated?.Invoke(this, EventArgs.Empty);
      }
   }
}
