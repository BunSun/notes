using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListModel
   {
      public event EventHandler<NewNoteEventArgs> NewNoteClicked;

      public event EventHandler NotesUpdated;

      public List<string> NoteFiles { get; private set; }

      public NotesListModel() => NoteFiles = new List<string>();

      public void LoadNotes(string path)
      {
         NoteFiles = new List<string>(Directory.GetFiles(path, "*.txt"));
         NotesUpdated?.Invoke(this, EventArgs.Empty);
      }

      public void RaiseNewNoteClicked(Core.IRepository<Core.Note> repository)
      {
         var note = new Note();
         var model = new NoteModel(note);
         var controller = new NoteController(model, repository);
         var e = new NewNoteEventArgs(controller);
         NewNoteClicked?.Invoke(this, e);
      }
   }

   public sealed class NewNoteEventArgs : EventArgs
   {
      public NewNoteEventArgs(NoteController controller)
      {
         Controller = controller;
      }

      public NoteController Controller { get; }
   }
}
