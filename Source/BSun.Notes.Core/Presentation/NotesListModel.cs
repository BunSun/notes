using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListModel : INotesListModel
   {
      public event EventHandler<NewNoteEventArgs> NewNoteClicked;
      public event EventHandler<NeedNotesEventArgs> NeedNotes;
      public event EventHandler NotesUpdated;
      public event EventHandler NotesDataSourceChanged;

      private BindingList<Note> _notes;

      public IList NotesDataSource
      {
         get
         {
            var results = new BindingList<Note>();
            var e = new NeedNotesEventArgs();
            NeedNotes?.Invoke(this, e);
            if (e.Notes != null)
            {
               foreach (var note in e.Notes)
               {
                  results.Add(note);
               }
            }
            return results;
         }
      }

      public List<string> NoteFiles { get; private set; }

      public NotesListModel()
      {
         _notes = new BindingList<Note>();
         NoteFiles = new List<string>();
      }

      public void LoadNotes(string path)
      {
         NoteFiles = new List<string>(Directory.GetFiles(path, "*.txt"));
         NotesUpdated?.Invoke(this, EventArgs.Empty);
      }

      public void RaiseNewNoteClicked(NoteController controller)
      {
         var e = new NewNoteEventArgs(controller);
         NewNoteClicked?.Invoke(this, e);
      }

      public void SetNotes(IEnumerable<Core.Note> notes)
      {
         _notes.Clear();
         foreach (var note in notes)
         {
            _notes.Add(note);
         }
      }
   }
}
