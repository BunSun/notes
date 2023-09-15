using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BSun.Notes.Core.Presentation
{
   public class NotesListModel : INotesListModel
   {
      public event EventHandler<NewNoteEventArgs> NewNoteClicked;

      public event EventHandler<NeedNotesEventArgs> NeedNotes;

      public event EventHandler NotesUpdated;

      public event EventHandler NotesDataSourceChanged;

      private List<Note> _notes;

      // Schritt 2 - Wenn Databinding die Eigenschaft aufruft.
      public IList NotesDataSource
      {
         get
         {
            // Schritt 2.1 Leere Liste erstellen, damit nie ein Fehler auftritt
            var results = new List<Note>();
            // Schritt 2.2 EventArgs erzeugen
            var e = new NeedNotesEventArgs();
            // Schritt 2.3 Event auslösen UND AUF ERGEBNIS WARTEN
            NeedNotes?.Invoke(this, e);
            if (e.Notes != null)
            {
               // Schritt 2.4 Daten aus Event-Behandlung in Liste übernehmen
               results.AddRange(e.Notes);
            }

            // Ergebnis in erwartetem Datentyp liefern.
            return (IList)results;
         }
      }

      public List<string> NoteFiles { get; private set; }

      public NotesListModel()
      {
         _notes = new List<Note>();

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
         _notes = new List<Note>(notes);
      }
   }
}
